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

    public class GoleadoresViewModel : BaseViewModel
    {
        #region Servicios
        private Apiservice apiService;
        #endregion

        #region Atributos
        private int cod_torneo;
        private ObservableCollection<Goleadores> goleadores;
        //private List<Posiciones> PosicionesList;
        #endregion

        #region propiedades
        public ObservableCollection<Goleadores> Goleadores
        {
            get { return this.goleadores; }
            set { SetValue(ref this.goleadores, value); }
        }
        #endregion


        #region Constructor
        public GoleadoresViewModel(int cod_torneo)
        {
            this.cod_torneo = cod_torneo;
            this.apiService = new Apiservice();
            this.LoadGoleadores(this.cod_torneo);
        }
        #endregion
        #region Metodos
        private async void LoadGoleadores(int cod_torneo)
        {
            var response = await this.apiService.GetList<Goleadores>(
            "http://exacnc.com",
            "/rest",
            "/goleadores/" + cod_torneo,
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
            var list = (List<Goleadores>)response.Result;
            //this.ListTorn = (List<TorneoList>)objTorneos.TorneoList;

            //var list =(Torneo)response.Result;

            this.Goleadores = new ObservableCollection<Goleadores>(list);

            //this.IsRefreshing = false;
        }
        #endregion

    }
}
