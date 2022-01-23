using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    [Serializable]
    class Platillo
    {
        private string descripcion, tipo;
        private decimal precio;

        public Platillo()
        {
            
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public decimal Precio { get => precio; set => precio = value; }
    }
}
