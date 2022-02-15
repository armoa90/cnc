
namespace Cnc.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Goleadores
    {

        [JsonProperty(PropertyName = "Id jugador")]
        public int IdJugador { get; set; }
        public string Jugador { get; set; }
        public int Goles { get; set; }
        public string Equipo { get; set; }

        public string Imagen { get; set; }
    }
}

