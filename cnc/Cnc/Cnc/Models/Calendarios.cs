namespace Cnc.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Calendarios
    {

        public int Semana { get; set; }
        public int Partido { get; set; }
        public string Estado { get; set; }
        public int Codigo_a { get; set; }
        public string Equipoa { get; set; }
        public string Imagena { get; set; }
        public int Gol_a { get; set; }
        public string Vs { get; set; }
        public int Codigob { get; set; }
        public string Equipob { get; set; }
        public string Imagenb { get; set; }
        public int Gol_b { get; set; }
        public string Hora_partido { get; set; }
    }
}
