﻿namespace Cnc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    using Cnc.Views;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Xamarin.Forms;

    public class DetalleItemViewModel : Torneo
    {

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
            MainViewModel.GetInstance().TorneoDetalle = new TorneoDetalleViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new TorneoDetallePage());
        }
        #endregion
    }
}