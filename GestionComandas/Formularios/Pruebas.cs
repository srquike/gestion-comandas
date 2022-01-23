using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionComandas
{
    public partial class Pruebas : Form
    {
        public Pruebas()
        {
            InitializeComponent();
        }

        private void Pruebas_Load(object sender, EventArgs e)
        {
            int mesas = 0, indiceFila = 0, config = 10;
            dataGridView1.ColumnCount = 5;
            do
            {
                dataGridView1.Rows.Add();
                for (int i = 0; i < 5; i++)
                {
                    dataGridView1.Rows[indiceFila].Height = 150;
                    mesas++;
                }
                indiceFila++;

            } while (mesas != config);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
