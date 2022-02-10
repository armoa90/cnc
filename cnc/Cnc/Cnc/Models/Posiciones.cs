

namespace Cnc.Models
{

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Posiciones
    {
       [JsonProperty(PropertyName = "Equipo")]
        public string Equipo { get; set; }
        [JsonProperty(PropertyName = "Puntos")]
        public int Puntos { get; set; }
        [JsonProperty(PropertyName = "PG")]
        public int PG { get; set; }
        [JsonProperty(PropertyName = "PE")]
        public int PE { get; set; }
        [JsonProperty(PropertyName = "PP")]
        public int PP { get; set; }
        [JsonProperty(PropertyName = "GF")]
        public double GF { get; set; }
        [JsonProperty(PropertyName = "GC")]
        public double GC { get; set; }
        [JsonProperty(PropertyName = "DIF")]
        public double DIF { get; set; }
    }
}
