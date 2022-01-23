using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace GestionComandas
{
    public partial class FrmComandas : Form
    {
        Archivo archivo;
        ArrayList platillos, pedidos;
        Pedido pedido;
        Comanda comanda;
        Configuracion configuracion;
        Dictionary<string, Comanda> comandas;

        decimal subtotal = 0;
        public string mesero, ruta = "comandas.bin";
        int mesa;

        public FrmComandas()
        {
            InitializeComponent();

            archivo = new Archivo();
            if (archivo.Leer("config.bin"))
                configuracion = (Configuracion)archivo.Objeto;

            platillos = new ArrayList();
            pedidos = new ArrayList();

            dgvMesas.ColumnCount = 10;
            GenerarMesas();

            comandas = new Dictionary<string, Comanda>();
        }

        //---------------------------------- EVENTOS -------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------

        // Evento Load del formulario.
        private void FrmComandas_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = 0;
            if (archivo.Leer(ruta))
            {
                comandas = (Dictionary<string, Comanda>)archivo.Objeto;

                foreach (Comanda comanda in comandas.Values)
                {
                    ReservarMesa(comanda.NumMesa);
                }
            }

            ActualizarTablaComanda(ref dgvComandas);
        }

        // Evento para el boton Agregar del DataGridView *Platillos*
        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPlatillos.Columns[5].Index && e.RowIndex >= 0)
            {
                

                if (dgvPlatillos.CurrentRow.Cells[3].Value != null)
                {
                    bool validado = int.TryParse(dgvPlatillos.CurrentRow.Cells[3].Value.ToString(), out int cantidad);

                    if (validado)
                    {
                        bool seleccion = (bool)dgvPlatillos.CurrentRow.Cells[4].Value;

                        if (seleccion)
                        {
                            pedido = new Pedido();
                            pedido.Platillo = (Platillo)platillos[e.RowIndex];
                            pedido.Cantidad = Convert.ToInt32(dgvPlatillos.CurrentRow.Cells[3].Value);

                            decimal subtotalPedido = pedido.Platillo.Precio * pedido.Cantidad;

                            pedido.Subtotal = subtotalPedido;
                            pedidos.Add(pedido);
                            ActualizarTablaPedido(ref dgvPedido);

                            subtotal += subtotalPedido;
                            txtSubTotal.Text = subtotal.ToString("C");
                        }
                        else
                            MessageBox.Show("Seleccione la casilla para agregar al pedido!");
                    }
                    else
                        MessageBox.Show("La cantidad introducida es incorrecta!");
                }
                else
                    MessageBox.Show("Ingrese la cantidad para agregar al pedido!");
            }
        }

        // Evento para boton Eliminar del DataGridView *Pedido*
        private void dgvPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPedido.Columns[5].Index && e.RowIndex >= 0)
            {
                DialogResult dialog = MessageBox.Show("Esta seguro de borrar el pedido? ", "Comanda",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dialog == DialogResult.OK)
                {
                    decimal subtotalPedido = (decimal)dgvPedido.CurrentRow.Cells[4].Value;
                    pedidos.RemoveAt(e.RowIndex);
                    ActualizarTablaPedido(ref dgvPedido);

                    subtotal -= subtotalPedido;
                    txtSubTotal.Text = subtotal.ToString();
                }
            }
        }

        // Evento para Boton *Pagar* del DataGridView *Comandas*
        private void dgvComandas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvComandas.Columns[4].Index && e.RowIndex >= 0)
            {
                string fecha = dgvComandas.CurrentRow.Cells[2].Value.ToString().Trim();
                GenerarFactura(fecha);
            }
        }

        // Evento para Seleccionar Mesas en el DatagridView *Mesas*
        private void dgvMesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string estadoMesa = dgvMesas.CurrentCell.Tag.ToString().Trim();
            int numMesa = (int)dgvMesas.CurrentCell.Value;
            if (estadoMesa.Equals("D"))
            {
                mesa = numMesa;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
        }

        // Evento Click para el Boton *Buscar*
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string tipo = cmbTipo.SelectedItem.ToString();
            dgvPlatillos.Rows.Clear();
            platillos.Clear();
            int indice = 0;
            if (archivo.Leer("platillos.bin"))
            {
                foreach (Platillo platillo in (ArrayList)archivo.Objeto)
                {
                    if (platillo.Tipo.Equals(tipo))
                    {
                        dgvPlatillos.Rows.Add(platillo.Tipo, platillo.Descripcion, platillo.Precio.ToString("C"));
                        dgvPlatillos.Rows[indice].Cells[4].Value = false;
                        indice++;
                        platillos.Add(platillo);
                    }
                }
                dgvPlatillos.ClearSelection();
            }
        }

        // Evento Click para el Boton *Guardar comanda*
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (pedidos.Count > 0)
            {
                comanda = new Comanda
                {
                    Mesero = mesero,
                    Fecha = DateTime.Now,
                    Detalles = pedidos,
                    NumMesa = mesa
                };
                decimal propina = subtotal - (subtotal / configuracion.Propina);
                decimal total = (propina + subtotal) * 1.13m;
                comanda.Total = total;

                comandas.Add(comanda.Fecha.ToString().Trim(), comanda);
                archivo.Guardar(ruta, comandas);
                ActualizarTablaComanda(ref dgvComandas);

                ReservarMesa(mesa);

                dgvPlatillos.Rows.Clear();
                pedidos.Clear();
                ActualizarTablaPedido(ref dgvPedido);
                subtotal = 0;
                txtSubTotal.ResetText();
                btnGuardar.Enabled = false;
            }
            else
                MessageBox.Show("El pedido esta vacio. Agregue platillos.");
        }


        //---------------------------------- FUNCIONES ------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------

        // Funcion para Actualizar los datos del DatagridView *Pedido*
        private void ActualizarTablaPedido(ref DataGridView gridView)
        {
            if (pedidos.Count >= 0)
            {
                gridView.Rows.Clear();
                foreach (Pedido pedido in pedidos)
                {
                    dgvPedido.Rows.Add(pedido.Platillo.Tipo, pedido.Platillo.Descripcion, pedido.Platillo.Precio.ToString("C"), 
                        pedido.Cantidad, pedido.Subtotal.ToString("C"));
                }
                gridView.ClearSelection();
            }            
        }

        // Funcion para Actualizar los datos del DatagridView *Comandas*
        private void ActualizarTablaComanda(ref DataGridView gridView)
        {
            if (comandas.Count >= 0)
            {
                dgvComandas.Rows.Clear();
                foreach (Comanda comanda in comandas.Values)
                {
                    dgvComandas.Rows.Add(comanda.Mesero, comanda.NumMesa, comanda.Fecha, comanda.Total.ToString("C"));
                }
                dgvComandas.ClearSelection();
            }
        }

        // Funcion para generar Mesas en DataGridView en tiempo de Ejecucion.
        private void GenerarMesas()
        {
            int numMesa = 0, rowCount = 6;
            for (int i = 0; i < rowCount; i++)
            {
                dgvMesas.Rows.Add();
                for (int j = 0; j < dgvMesas.ColumnCount; j++)
                {
                    numMesa++;
                    dgvMesas.Rows[i].Cells[j].Value = numMesa;
                    dgvMesas.Rows[i].Height = 81;
                    dgvMesas.Rows[i].Cells[j].Tag = "D";
                    dgvMesas.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                }
            }
        }

        // Funcion para Generar factura.
        private void GenerarFactura(string fecha)
        {
            FrmFactura factura = new FrmFactura();
            factura.MdiParent = this;
            factura.txtMesero.Text = comandas[fecha].Mesero;
            factura.txtMesa.Text = comandas[fecha].NumMesa.ToString();
            factura.txtFehaHora.Text = fecha;

            decimal total = comandas[fecha].Total;
            decimal iva = total - (total / 1.13m);
            decimal propina = total - ((total - iva) / configuracion.Propina);

            factura.lblPropina.Text = "Propina (" + (configuracion.Propina - 1).ToString("p0") + ") :";
            factura.txtPropina.Text = propina.ToString("C");
            factura.txtIVA.Text = iva.ToString("C");
            factura.txtSubTotal.Text = (total - iva - propina).ToString("C");
            factura.txtTotal.Text = total.ToString("C");

            if (factura.ShowDialog(this) == DialogResult.OK)
            {
                LimpiarMesa(comandas[fecha].NumMesa);
                comandas.Remove(fecha);
                archivo.Guardar(ruta, comandas);
                ActualizarTablaComanda(ref dgvComandas);
            }
        }

        // Funcion para reservar mesas.
        private void ReservarMesa(int numMesa)
        {
            for (int i = 0; i < dgvMesas.RowCount; i++)
            {
                for (int j = 0; j < dgvMesas.ColumnCount; j++)
                {
                    int numero = (int)dgvMesas.Rows[i].Cells[j].Value;
                    if (numero == numMesa)
                    {
                        dgvMesas.Rows[i].Cells[j].Tag = "O";
                        dgvMesas.Rows[i].Cells[j].Style.BackColor = Color.Salmon;
                    }
                }
            }
        }

        // Funcion para Limpiar mesas.
        private void LimpiarMesa(int numMesa)
        {
            for (int i = 0; i < dgvMesas.RowCount; i++)
            {
                for (int j = 0; j < dgvMesas.ColumnCount; j++)
                {
                    int numero = (int)dgvMesas.Rows[i].Cells[j].Value;
                    if (numero == numMesa)
                    {
                        dgvMesas.Rows[i].Cells[j].Tag = "D";
                        dgvMesas.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    }
                }
            }
        }
    }
}
