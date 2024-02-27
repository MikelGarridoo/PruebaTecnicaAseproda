using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaTecnicaAseproda;
using System;
using System.Collections.Generic;

namespace Testing
{
    [TestClass]
    public class TestPistaSurtidores
    {
        [TestMethod]
        public void TestPrefijarSurtidor_Invalido()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            Assert.ThrowsException<ArgumentException>(() => pista.PrefijarSurtidor(0, 10)); // Número de surtidor inválido
        }

        [TestMethod]
        public void TestPrefijarSurtidor_ConImporteNegativo()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            Assert.ThrowsException<ArgumentException>(() => pista.PrefijarSurtidor(0, -5)); // Número de surtidor inválido
        }

        [TestMethod]
        public void TestPrefijarSurtidor_Valido()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            pista.PrefijarSurtidor(1, 10);

            Assert.AreEqual(10, pista.Surtidores[0].ImportePrefijado); // Verifica que el surtidor tenga el importe prefijado
        }

        [TestMethod]
        public void TestLiberarSurtidor_Invalido()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            Assert.ThrowsException<ArgumentException>(() => pista.LiberarSurtidor(7)); // Número de surtidor inválido
        }

        [TestMethod]
        public void TestLiberarSurtidor_ConImporteNegativo()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            Assert.ThrowsException<ArgumentException>(() => pista.LiberarSurtidor(1, -5)); // Número de surtidor inválido
        }

        [TestMethod]
        public void TestLiberarSurtidor_SinImportePrefijado()
        {
            PistaSurtidores pista = new PistaSurtidores(5);
            decimal importeSuministrado = 20;

            pista.LiberarSurtidor(1, importeSuministrado);

            Assert.AreEqual($"Libre", pista.Surtidores[0].Estado); // Verifica que el surtidor esté libre
            Assert.AreEqual(1, pista.Surtidores[0].Suministros.Count); // Verifica que se haya registrado el suministro
            Assert.AreEqual(importeSuministrado, pista.Surtidores[0].Suministros[0].ImporteSuministrado); // Verifica el importe suministrado
        }

        [TestMethod]
        public void TestLiberarSurtidor_ConImportePrefijado()
        {
            PistaSurtidores pista = new PistaSurtidores(5);
            decimal importePrefijado = 30;

            pista.PrefijarSurtidor(1, importePrefijado);
            pista.LiberarSurtidor(1, 40);

            Assert.AreEqual($"Libre", pista.Surtidores[0].Estado); // Verifica que el surtidor esté libre
            Assert.AreEqual(1, pista.Surtidores[0].Suministros.Count); // Verifica que se haya registrado el suministro
            Assert.AreEqual(importePrefijado, pista.Surtidores[0].Suministros[0].ImporteSuministrado); // Verifica el importe suministrado
        }

        [TestMethod]
        public void TestBloquearSurtidor_Invalido()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            Assert.ThrowsException<ArgumentException>(() => pista.BloquearSurtidor(0)); // Número de surtidor inválido
        }

        [TestMethod]
        public void TestBloquearSurtidor_Valido()
        {
            PistaSurtidores pista = new PistaSurtidores(5);

            pista.BloquearSurtidor(1);

            Assert.AreEqual("Bloqueado", pista.Surtidores[0].Estado); // Verifica que el surtidor esté bloqueado
        }

        [TestMethod]
        public void TestObtenerEstado()
        {
            PistaSurtidores pista = new PistaSurtidores(3);

            var estados = pista.ObtenerEstado();

            CollectionAssert.AreEqual(new List<string> { "Surtidor 1: Bloqueado", "Surtidor 2: Bloqueado", "Surtidor 3: Bloqueado" }, estados); // Verifica los estados iniciales
        }

        [TestMethod]
        public void TestObtenerHistorialSuministros()
        {
            PistaSurtidores pista = new PistaSurtidores(2);

            var historial = pista.ObtenerHistorialSuministros();

            Assert.AreEqual(0, historial.Count); // Verifica que el historial esté vacío inicialmente
        }

        [TestMethod]
        public void TestOrdenHistorialSuministros()
        {
            PistaSurtidores pista = new PistaSurtidores(2);

            pista.PrefijarSurtidor(1, 20);
            pista.PrefijarSurtidor(2, 30);

            pista.LiberarSurtidor(1, 28);
            pista.LiberarSurtidor(2, 35);
            pista.BloquearSurtidor(1);
            pista.LiberarSurtidor(1, 20);

            var historial = pista.ObtenerHistorialSuministros();

            Assert.AreEqual(3, historial.Count); // Verifica que hay 3 suministros en el historial

            // Verifica el orden correcto del historial: primero por importe suministrado y luego por fecha
            Assert.AreEqual(30, historial[0].ImporteSuministrado);
            Assert.AreEqual(20, historial[1].ImporteSuministrado);
            Assert.AreEqual(20, historial[2].ImporteSuministrado);
        }
    }
}
