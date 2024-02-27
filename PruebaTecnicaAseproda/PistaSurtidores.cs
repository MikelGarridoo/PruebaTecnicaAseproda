using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnicaAseproda
{
    public class PistaSurtidores
    {
        public List<Surtidor> Surtidores { get; private set; }

        public PistaSurtidores(int cantidadSurtidores)
        {
            Surtidores = Enumerable.Range(1, cantidadSurtidores).Select(_ => new Surtidor()).ToList();
        }

        public void PrefijarSurtidor(int numeroSurtidor, decimal importePrefijado)
        {
            if (numeroSurtidor < 1 || numeroSurtidor > Surtidores.Count)
            {
                throw new ArgumentException(MensajesError.NumeroSurtidorInvalido);
            }
            if (importePrefijado < 0)
            {
                throw new ArgumentException(MensajesError.ImporteNegativo);
            }

            Surtidores[numeroSurtidor - 1].PrefijarSurtidor(importePrefijado);
        }

        public void LiberarSurtidor(int numeroSurtidor, decimal importeSuministrado = 0)
        {
            if (numeroSurtidor < 1 || numeroSurtidor > Surtidores.Count)
            {
                throw new ArgumentException(MensajesError.NumeroSurtidorInvalido);
            }

            if (importeSuministrado < 0)
            {
                throw new ArgumentException(MensajesError.ImporteNegativo);
            }

            Surtidor surtidor = Surtidores[numeroSurtidor - 1];
            surtidor.LiberarSurtidor();

            if(surtidor.ImportePrefijado > 0 && surtidor.ImportePrefijado < importeSuministrado)
            {
                importeSuministrado = surtidor.ImportePrefijado;
            }

            Suministro suministro = new Suministro(surtidor, DateTime.Now, importeSuministrado);
            surtidor.RegistrarSuministro(suministro);
        }

        public void BloquearSurtidor(int numeroSurtidor)
        {
            if (numeroSurtidor < 1 || numeroSurtidor > Surtidores.Count)
            {
                throw new ArgumentException(MensajesError.NumeroSurtidorInvalido);
            }

            Surtidores[numeroSurtidor - 1].BloquearSurtidor();
        }

        public List<string> ObtenerEstado()
        {
            List<string> estados = new List<string>();
            foreach (var surtidor in Surtidores)
            {
                estados.Add($"Surtidor {(Surtidores.IndexOf(surtidor) + 1)}: {surtidor.Estado}");
            }
            return estados;
        }

        public List<Suministro> ObtenerHistorialSuministros()
        {
            List<Suministro> historial = new List<Suministro>();
            foreach (var surtidor in Surtidores)
            {
                historial.AddRange(surtidor.Suministros);
            }
            historial = historial.OrderByDescending(s => s.ImporteSuministrado)
                                 .ThenByDescending(s => s.FechaHora)
                                 .ToList();
            return historial;
        }
    }
}
