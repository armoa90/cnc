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

    public class VencidasViewModel : BaseViewModel
    {
        #region Servicios
        private Apiservice apiService;
        #endregion

        #region Atributos
        private int cod_torneo;
        private ObservableCollection<Vencidas> vencidas;
        //private List<Posiciones> PosicionesList;
        #endregion

        #region propiedades
        public ObservableCollection<Vencidas> Vencidas
        {
            get { return this.vencidas; }
            set { SetValue(ref this.vencidas, value); }
        }
        #endregion


        #region Constructor
        public VencidasViewModel(int cod_torneo)
        {
            this.cod_torneo = cod_torneo;
            this.apiService = new Apiservice();
            this.LoadVencidas();
        }
        #endregion
        #region Metodos
        private async void LoadVencidas()
        {
            var response = await this.apiService.GetList<Vencidas>(
            "http://exacnc.com",
            "/rest",
            "/vencidas/" + this.cod_torneo,
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
            var list = (List<Vencidas>)response.Result;
            //this.ListTorn = (List<TorneoList>)objTorneos.TorneoList;

            //var list =(Torneo)response.Result;

            this.Vencidas = new ObservableCollection<Vencidas>(list);

            //this.IsRefreshing = false;
        }
        #endregion
    }
}
