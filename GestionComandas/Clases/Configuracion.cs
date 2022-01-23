using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    [Serializable]
    public class Configuracion
    {
        private int nMesas;
        private decimal propina;
        private Usuario usuario;

        public Configuracion()
        {
            Usuario = new Usuario();
        }

        public int NMesas { get => nMesas; set => nMesas = value; }
        public decimal Propina { get => propina; set => propina = value; }
        internal Usuario Usuario { get => usuario; set => usuario = value; }
    }
}
