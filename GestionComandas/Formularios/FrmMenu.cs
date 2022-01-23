using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace GestionComandas
{
    public partial class FrmMenu : Form
    {
        Archivo archivo;
        Platillo platillo;
        ArrayList platillos;

        string ruta;
        public FrmMenu()
        {
            InitializeComponent();

            archivo = new Archivo();
            platillos = new ArrayList();
            ruta = "platillos.bin";
        }

        //----------------------------------------- EVENTOS ----------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------

        // Evento Load del Formulario.
        private void FrmMenu_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            if (archivo.Leer(ruta))
            {
                platillos = (ArrayList)archivo.Objeto;
                ActualizarTabla(ref dgvTabla);
            }

        }

        // Evento Click del Boton *agregar*
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool completado = true;
            if (string.IsNullOrEmpty(txtDescripcion.Text) || txtDescripcion.Text.Length < 3)
            {
                errorProvider.SetError(txtDescripcion, "Ingrese una descripcion (min 3 caracteres, max 30)");
                completado = false;
            }
            else
                errorProvider.Clear();
            if (completado)
            {
                platillo = new Platillo
                {
                    Descripcion = txtDescripcion.Text,
                    Precio = numericPrecio.Value,
                    Tipo = cmbTipo.SelectedItem.ToString()
                };

                platillos.Add(platillo);
                archivo.Guardar(ruta, platillos);
                ActualizarTabla(ref dgvTabla);
                txtDescripcion.Clear();
                numericPrecio.Refresh();
                txtDescripcion.Focus();
            }
        }

        // Evento para boton *Eliminar* del DatagridView *Tabla*
        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTabla.Columns[3].Index && e.RowIndex >= 0)
            {
                string menu = dgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar el menú " + menu, "Platillo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dialogResult == DialogResult.OK)
                {
                    platillos.RemoveAt(e.RowIndex);
                    archivo.Guardar(ruta, platillos);
                    ActualizarTabla(ref dgvTabla);
                }
            }
        }

        //----------------------------------------- FUNCIONES --------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------

        // Funcion para actualizar datos en DATAGRID.
        private void ActualizarTabla(ref DataGridView gridView)
        {
            if (platillos.Count >= 0)
            {
                gridView.Rows.Clear();
                foreach (Platillo item in platillos)
                {
                    gridView.Rows.Add(item.Tipo, item.Descripcion, item.Precio.ToString("C"));
                }
                gridView.ClearSelection();
            }
        }
    }
}
