namespace Cnc
{

    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Views;

    public partial class App : Application
    {

        #region Constructor
            public App()
            {
                InitializeComponent();

                this.MainPage = new NavigationPage( new InicioPage());
            }
        #endregion


        #region Metodos
        protected override void OnStart()
            {
            }

            protected override void OnSleep()
            {
            }

            protected override void OnResume()
            {
            }

        #endregion

    }
}
