
namespace Cnc.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    public class TorneoDetalleViewModel
    {
        #region propiedad
        public Torneo Torneo
        {
            get;
            set;
        }

        #endregion
        #region Constructor
            public TorneoDetalleViewModel(Torneo torneo)
            {
                this.Torneo = torneo;
            }
        #endregion


    }
}
