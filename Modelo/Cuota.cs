using System;

namespace Modelo
{
    public class Cuota
    {
        public int Numero { get; set; }

        public decimal Capital { get; set; }
        public decimal InteresFinanciero { get; set; }
        public decimal InteresResarcitorio { get; set; }
        public DateTime Vencimiento { get; set; }


    }
}
