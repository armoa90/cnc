
namespace Cnc.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Torneo
    {
        [JsonProperty(PropertyName = "codigo")]
        public int Codigo { get; set; }
        [JsonProperty(PropertyName = "descripcion")]
        public string Descripcion { get; set; }
    }
}
