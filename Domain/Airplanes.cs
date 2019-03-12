using System;
using System.Collections.Generic;

namespace Domain
{
    public partial class Airplanes
    {
        public long Id { get; set; }
        public string Modelo { get; set; }
        public int Passageiros { get; set; }
        public DateTime Criacao { get; set; }
    }
}
