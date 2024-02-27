using System.Collections.Generic;

namespace PruebaTecnicaAseproda
{
    public class Surtidor
    {
        public string Estado { get; private set; }
        public decimal ImportePrefijado { get; private set; }
        public List<Suministro> Suministros { get; private set; }

        public Surtidor()
        {
            Estado = "Bloqueado";
            ImportePrefijado = 0;
            Suministros = new List<Suministro>();
        }

        public void LiberarSurtidor()
        {
            Estado = "Libre";
        }

        public void PrefijarSurtidor(decimal importePrefijado)
        {
            ImportePrefijado = importePrefijado;
        }

        public void BloquearSurtidor()
        {
            Estado = "Bloqueado";
            ImportePrefijado = 0;
        }

        public void RegistrarSuministro(Suministro suministro)
        {
            Suministros.Add(suministro);
        }
    }
}
