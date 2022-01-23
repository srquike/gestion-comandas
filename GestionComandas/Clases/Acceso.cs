using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    class Acceso
    {
        private Usuario usuario;

        public Acceso()
        {
            Usuario = new Usuario();
        }

        internal Usuario Usuario { get => usuario; set => usuario = value; }
    }
}
