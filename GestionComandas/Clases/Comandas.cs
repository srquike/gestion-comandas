using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionComandas
{
    [Serializable]
    class Comanda
    {
        private string mesero;
        private int numMesa;
        private decimal total;
        private DateTime fecha;
        private ArrayList detalles;

        public Comanda()
        {
        }
        
        public string Mesero { get => mesero; set => mesero = value; }
        public ArrayList Detalles { get => detalles; set => detalles = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public int NumMesa { get => numMesa; set => numMesa = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
