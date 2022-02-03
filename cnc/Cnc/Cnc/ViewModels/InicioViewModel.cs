
namespace Cnc.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    public class InicioViewModel : BaseViewModel
    {
        #region Propiedades
        public bool IsRunning
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        public InicioViewModel()
        {

        }
        #endregion
        #region Commands
        public ICommand TorneoCommand
        {
            get
            {
                return new RelayCommand(Torneo);
            }
            

        }

        private async void Torneo()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().Torneo = new TorneoViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new TorneoPage());

        }

        #endregion
    }
}
