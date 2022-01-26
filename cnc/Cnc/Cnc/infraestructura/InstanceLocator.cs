
namespace Cnc.infraestructura
{
    using ViewModels;
     class InstanceLocator
    {
        #region Propiedades
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
