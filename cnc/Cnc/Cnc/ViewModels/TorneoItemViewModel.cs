namespace Cnc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Cnc.Servicios;
    using Cnc.Views;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Xamarin.Forms;

    public class TorneoItemViewModel : Torneo
    {

        #region Servicios
        private Apiservice apiService;
        #endregion
        #region commands

        public ICommand SelectTorneoCommand
        {
            get
            {
                return new RelayCommand(SelectTorneo);
            }
        }

        private async void SelectTorneo()
        {
            

            MainViewModel.GetInstance().Torneo = new TorneoViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new TorneoTabbedPage());

        }
        #endregion

    }
}
