using System;

namespace PruebaTecnicaAseproda
{
    public class Suministro
    {
        public Surtidor Surtidor { get; private set; }
        public DateTime FechaHora { get; private set; }
        public decimal ImporteSuministrado { get; private set; }

        public Suministro(Surtidor surtidor, DateTime fechaHora, decimal importeSuministrado)
        {
            Surtidor = surtidor;
            FechaHora = fechaHora;
            ImporteSuministrado = importeSuministrado;
        }
    }
}
