namespace Cnc.Servicios
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Cnc.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Plugin.Connectivity;

    public class Apiservice
    {
         public async Task<Response> CheckConnection()
         {
             if (!CrossConnectivity.Current.IsConnected)
             {
                 return new Response
                 {
                     IsSuccess = false,
                     Message = "Verifique las configuraciones de su internet" //"Please turn on your internet settings.",
                 };
             }

             var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
             if (!isReachable)
             {
                 return new Response
                 {
                     IsSuccess = false,
                     Message = "Verificar la conexión a internet .",
                 };
             }

             return new Response
             {
                 IsSuccess = true,
                 Message = "Ok",
             };
         }
        public async Task<TokenResponse> GetToken(string urlBase, string username, string password)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.PostAsync("Token",
                    new StringContent(string.Format(
                    "grant_type=password&username={0}&password={1}",
                    username, password),
                    Encoding.UTF8, "application/x-www-form-urlencoded"));
                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TokenResponse>(
                    resultJSON);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Response> Get<T>(string urlBase,
            string servicePrefix,
            string controller,
            string username,
            string pass)
        {
            try
            {
                var client = new HttpClient();
                var authData = string.Format("{0}:{1}", username, pass);
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var list = JsonConvert.DeserializeObject<T>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string username,
            string pass)
        {
            try
            {
                var client = new HttpClient();
                var authData = string.Format("{0}:{1}", username, pass);
                var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                { //ya vi el error, espero.
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }



                //var list = JsonConvert.DeserializeObject<T>(result);
                var list = JsonConvert.DeserializeObject<List<T>>(result);


                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<Response> GetList<T>(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            int id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenType, accessToken);
                client.BaseAddress = new Uri(urlBase);
                var url = string.Format(
                    "{0}{1}/{2}",
                    servicePrefix,
                    controller,
                    id);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = response.StatusCode.ToString(),
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
