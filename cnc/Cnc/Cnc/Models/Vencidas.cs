
namespace Cnc.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    public class Vencidas
    {
        [JsonProperty(PropertyName = "Equipo")]
        public string Equipo { get; set; }
        [JsonProperty(PropertyName = "Imagen")]
        public string Imagen { get; set; }
        [JsonProperty(PropertyName = "Goles")]
        public string Goles { get; set; }
    }   
}
