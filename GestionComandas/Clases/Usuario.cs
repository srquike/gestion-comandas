using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    [Serializable]
    class Usuario
    {
        string nombre, password, user,acceso;
        public Usuario()
        {
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public string User { get => user; set => user = value; }
        public string Acceso { get => acceso; set => acceso = value; }
    }
}
