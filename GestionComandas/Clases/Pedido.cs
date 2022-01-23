using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    [Serializable]
    class Pedido
    {
        private decimal subtotal;
        private int cantidad;
        private Platillo platillo;

        public Pedido()
        {

        }

        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        internal Platillo Platillo { get => platillo; set => platillo = value; }
    }
}
