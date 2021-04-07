using Logica;
using Modelo;
using NUnit.Framework;
using System;

namespace LogicaTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QueDeBienElCapitalAmortizado()
        {

            Assert.Pass();
        }
        [Test]
        public void QueElCalculoEsteBienHecho()
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

            var cuotaRandom = planDePago.Cuotas[4];

            Assert.IsTrue(cuotaRandom.Capital == (decimal)8070.57 && cuotaRandom.InteresFinanciero == (decimal)1385.39);
        }
    }
}