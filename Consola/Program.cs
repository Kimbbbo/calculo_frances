using Logica;
using Modelo;
using System;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {

            var plan = new PlanDePago();
            plan.CantidadCuotas = 12;
            plan.Tasa = 2;
            plan.FechaConsolidacion = DateTime.Now;

            Impuesto impuesto = new Impuesto();
            impuesto.ICS = "030019019";
            impuesto.Tipo = "IMPO";
            impuesto.Saldo = 100000;

            plan.AgregarImpuesto(impuesto);

            CalculoFrances calculo = new CalculoFrances();
            var planDePago = calculo.Calcular(plan);

            Console.WriteLine($"Monto consolidado: {plan.MontoConsolidado}");
            Console.WriteLine($"Cuotas solicitadas: {plan.CantidadCuotas}");
            Console.WriteLine($"Tasa mensual: {plan.Tasa}");
            Console.WriteLine();
            Console.WriteLine("Cuota\tCapital\t\tInteres Financiero\tInteres Resarcitorio");
            foreach (var cuota in planDePago.Cuotas)
            {
                Console.WriteLine($"{cuota.Numero}\t{cuota.Capital.ToString("0.00")}\t\t{cuota.InteresFinanciero.ToString("0.00")}\t\t\t{cuota.InteresResarcitorio.ToString("0.00")}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total capital pagado:\t{planDePago.TotalCapitalPagado}");
            Console.WriteLine($"Total interes pagado:\t{planDePago.TotalInteresPagado}");

            /**************/
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            plan = new PlanDePago();
            plan.CantidadCuotas = 12;
            plan.Tasa = 2;
            plan.FechaConsolidacion = new DateTime(2021, 4, 16);

            impuesto = new Impuesto();
            impuesto.ICS = "030019019";
            impuesto.Tipo = "IMPO";
            impuesto.Saldo = 100000;

            plan.AgregarImpuesto(impuesto);

            planDePago = calculo.Calcular(plan);

            Console.WriteLine($"Monto consolidado: {plan.MontoConsolidado}");
            Console.WriteLine($"Cuotas solicitadas: {plan.CantidadCuotas}");
            Console.WriteLine($"Tasa mensual: {plan.Tasa}");
            Console.WriteLine();
            Console.WriteLine("Cuota\tCapital\t\tInteres Financiero\tInteres Resarcitorio");
            foreach (var cuota in planDePago.Cuotas)
            {
                Console.WriteLine($"{cuota.Numero}\t{cuota.Capital.ToString("0.00")}\t\t{cuota.InteresFinanciero.ToString("0.00")}\t\t\t{cuota.InteresResarcitorio.ToString("0.00")}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total capital pagado:\t{planDePago.TotalCapitalPagado}");
            Console.WriteLine($"Total interes pagado:\t{planDePago.TotalInteresPagado}");
        }
    }
}
