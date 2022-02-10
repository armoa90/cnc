
namespace Cnc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Servicios;
    using Models;
    using Xamarin.Forms;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;

    public class PosicionesViewModel : BaseViewModel
    {
        #region Servicios
        private Apiservice apiService;
        #endregion


        #region Atributos
        private int cod_torneo;
        private ObservableCollection<Posiciones> posiciones;
        //private List<Posiciones> PosicionesList;
        #endregion

        #region propiedades
        public ObservableCollection<Posiciones> Posiciones
        {
            get { return this.posiciones; }
            set { SetValue(ref this.posiciones, value); }
        }
        #endregion
        #region Constructor
        public PosicionesViewModel(int cod_torneo)
        {
            this.cod_torneo = cod_torneo;
            this.apiService = new Apiservice();
            this.LoadPosiciones( this.cod_torneo);
        }
        #endregion
        #region Metodos
            private async void LoadPosiciones(int cod_torneo)
            {
                var response = await this.apiService.GetList<Posiciones>(
                "http://exacnc.com",
                "/rest",
                "/posiciones/" + cod_torneo,
                "ApiUserAdmin",
                "ApiUserAdmin");
                if (!response.IsSuccess)
                {
                    //this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        response.Message,
                        "Accept");
                    await Application.Current.MainPage.Navigation.PopAsync();
                    return;
                }
                //this.PosicionesList = (List<Posiciones>)response.Result;
                var list = (List<Posiciones>)response.Result;
            //this.ListTorn = (List<TorneoList>)objTorneos.TorneoList;

            //var list =(Torneo)response.Result;

            this.Posiciones = new ObservableCollection<Posiciones>(list);

                //this.IsRefreshing = false;
            }

        #endregion

    }
}
