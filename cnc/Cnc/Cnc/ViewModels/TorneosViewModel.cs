
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
    public class TorneosViewModel: BaseViewModel
    {
        #region Servicios
        private Apiservice apiService;
        #endregion

        #region  Atributos
        private ObservableCollection<TorneoItemViewModel> torneos ;
        private bool isRefreshing;
        private string filter;
        private List<Torneo> torneoList;
        #endregion

        #region Propiedades
        public ObservableCollection<TorneoItemViewModel> Torneos
        {
            get { return this.torneos; }
            set { SetValue(ref this.torneos, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {

                SetValue(ref this.filter, value);
                this.Search();
            }
        }
        #endregion

        #region constructor
        public TorneosViewModel()
        {
            this.apiService = new Apiservice();
            this.LoadTorneos();
        }
        #endregion

        #region Metodos
        private async void LoadTorneos()
        {
            this.IsRefreshing = true;
            /*var coneccion = await this.apiService.CheckConnection();

            if (!coneccion.IsSuccess) {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    coneccion.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }*/
            var response = await this.apiService.GetList<Torneo>(
            "http://exacnc.com",
            "/rest",
            "/torneo",
            "ApiUserAdmin",
            "ApiUserAdmin");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            this.torneoList = (List<Torneo>)response.Result;
            //this.ListTorn = (List<TorneoList>)objTorneos.TorneoList;

            //var list =(Torneo)response.Result;

            this.Torneos = new ObservableCollection<TorneoItemViewModel>(this.toTorneoItemViewModel());

            this.IsRefreshing = false;
        }

        #endregion


        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadTorneos);

            }

        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                /*this.Torneo = new ObservableCollection<DetalleItemViewModel>(
                this.toDetalleItemViewModel());*/
                this.Torneos = new ObservableCollection<TorneoItemViewModel>(this.toTorneoItemViewModel());
            }
            else
            {
                /*this.Torneos = new ObservableCollection<DetalleItemViewModel>(
                    this.toDetalleItemViewModel().Where(
                        l => l.Descripcion.ToLower().Contains(this.Filter.ToLower())));*/

                this.Torneos = new ObservableCollection<TorneoItemViewModel>(this.toTorneoItemViewModel().Where(
                        l => l.Descripcion.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion

        #region Metodos
        private IEnumerable<TorneoItemViewModel> toTorneoItemViewModel()
        {
            return this.torneoList.Select(l => new TorneoItemViewModel
            {
                Codigo = l.Codigo,
                Descripcion = l.Descripcion
            });
        }

        #endregion

    }
}
