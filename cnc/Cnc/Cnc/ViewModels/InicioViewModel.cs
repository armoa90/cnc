
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
                return new RelayCommand(Torneos);
            }
            

        }

        private async void Torneos()
        {
            this.IsRunning = true;
            MainViewModel.GetInstance().Torneos = new TorneosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new TorneosPage());

        }

        #endregion
    }
}
