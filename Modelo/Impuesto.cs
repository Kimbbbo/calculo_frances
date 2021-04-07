using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Impuesto
    {
        public string ICS { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Saldo { get; set; }
        public string Tipo { get; set; }
    }
}
