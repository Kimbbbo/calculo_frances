using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class PlanDePago
    {
        public PlanDePago()
        {
            this._Impuestos = new List<Impuesto>();
            this.Cuotas = new List<Cuota>();
        }

        public DateTime FechaConsolidacion { get; set; }

        public decimal MontoConsolidado { get { return _MontoConsolidado; } } 
        private decimal _MontoConsolidado { get; set; }

        public int CantidadCuotas { get; set; }
        public double Tasa { get; set; }
        public List<Cuota> Cuotas { get; set; }


        public List<Impuesto> Impuestos { get { return _Impuestos; } }
        private List<Impuesto> _Impuestos { get; set; }



        public decimal TotalCapitalPagado { get; set; }
        public decimal TotalInteresPagado { get; set; }

        public void AgregarImpuesto(Impuesto impuesto)
        {
            this._Impuestos.Add(impuesto);
            this._MontoConsolidado += impuesto.Saldo;
        }
    }
}
