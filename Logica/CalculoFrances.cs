using Modelo;
using System;

namespace Logica
{
    public class CalculoFrances : Calculo
    {
        public PlanDePago Calcular(PlanDePago planDePago)
        {
            var planDePagoResultante = new PlanDePago();

            double deudaSaldo = Convert.ToDouble(planDePago.MontoConsolidado);

            double tasa = planDePago.Tasa / (double)100;
            double cuotas = planDePago.CantidadCuotas;

            double aux1 = Math.Pow((1 + tasa), cuotas);
            double aux2 = tasa * aux1;
            double aux3 = aux1 - (double)1;

            var montoPorCuota = deudaSaldo * (aux2 / aux3 );

            var fechaPrimeraCuota = new DateTime(planDePago.FechaConsolidacion.Year, planDePago.FechaConsolidacion.AddMonths(1).Month, 16);

            var cuota = new Cuota();
            cuota.Numero = 1;
            cuota.Capital = Math.Round(Convert.ToDecimal(montoPorCuota - (deudaSaldo * tasa)),2);
            cuota.InteresFinanciero = Math.Round(Convert.ToDecimal(deudaSaldo * (tasa * (fechaPrimeraCuota - planDePago.FechaConsolidacion).TotalDays / 30)),2);
            cuota.InteresResarcitorio = Math.Round(Convert.ToDecimal(deudaSaldo * (tasa * ((fechaPrimeraCuota - planDePago.FechaConsolidacion).TotalDays + 10) / 30)),2);
            planDePagoResultante.Cuotas.Add(cuota);
            planDePagoResultante.TotalCapitalPagado += Math.Round(cuota.Capital,2);
            planDePagoResultante.TotalInteresPagado += Math.Round(cuota.InteresFinanciero,2);

            deudaSaldo = Math.Round(deudaSaldo - Convert.ToDouble(cuota.Capital),2);

            for (int i = 2; i <= cuotas; i++)
            {
                cuota = new Cuota();
                cuota.Numero = i;
                cuota.Capital = Math.Round(Convert.ToDecimal(montoPorCuota - (deudaSaldo * tasa)),2);
                cuota.InteresFinanciero = Math.Round(Convert.ToDecimal(deudaSaldo * (tasa * 30 / 30)),2);
                cuota.InteresResarcitorio = Math.Round(Convert.ToDecimal(deudaSaldo * (tasa * 40 / 30)),2);
                planDePagoResultante.Cuotas.Add(cuota);

                planDePagoResultante.TotalCapitalPagado += Math.Round(cuota.Capital,2);
                planDePagoResultante.TotalInteresPagado += Math.Round(cuota.InteresFinanciero,2);

                deudaSaldo = Math.Round(deudaSaldo - Convert.ToDouble(cuota.Capital), 2);
            }

            return planDePagoResultante;
        }
    }
}
