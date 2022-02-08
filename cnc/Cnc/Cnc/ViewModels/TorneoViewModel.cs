
namespace Cnc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public class TorneoViewModel :BaseViewModel
    {
        #region propiedad
        public Torneo Torneo
        {
            get;
            set;
        }

        #endregion
        #region Constructor
            public TorneoViewModel(Torneo torneo)
            {
                this.Torneo = torneo;
            }
        #endregion


    }
}