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
    public class CalendarioViewModel : BaseViewModel
    {
        #region Servicios
        private Apiservice apiService;
        #endregion


        #region Atributos
        private int cod_torneo;
        private ObservableCollection<Calendarios> calendarios;
        private bool isRefreshing;
        //private List<Posiciones> PosicionesList;
        #endregion

        #region propiedades
        public ObservableCollection<Calendarios> Calendarios
        {
            get { return this.calendarios; }
            set { SetValue(ref this.calendarios, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }
        #endregion
        #region Constructor
        public CalendarioViewModel(int cod_torneo)
        {
            this.cod_torneo = cod_torneo;
            this.apiService = new Apiservice();
            this.LoadCalendario();
        }
        #endregion
        #region Metodos
        private async void LoadCalendario()
        {
            this.IsRefreshing = true;
            var response = await this.apiService.GetList<Calendarios>(
            "http://exacnc.com",
            "/rest",
            "/fixture/" + this.cod_torneo,
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
            var list = (List<Calendarios>)response.Result;
            //this.ListTorn = (List<TorneoList>)objTorneos.TorneoList;

            //var list =(Torneo)response.Result;

            this.Calendarios = new ObservableCollection<Calendarios>(list);

            this.IsRefreshing = false;
        }

        #endregion
        #region Commands
        public ICommand RefreshCommand
        {

            get
            {
                return new RelayCommand(LoadCalendario);

            }

        }
        #endregion
    }
}
