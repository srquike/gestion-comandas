using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace GestionComandas
{
    public partial class FrmUsuarios : Form
    {

        string patronNombre, ruta;
        Dictionary<string, Usuario> dictionary;
        Archivo archivo;
        Usuario usuario;

        public FrmUsuarios()
        {
            InitializeComponent();

            dictionary = new Dictionary<string, Usuario>();
            archivo = new Archivo();
            patronNombre = @"^[a-zA-Z ]*$";
            ruta = "usuarios.bin";
        }

        // ---------------------------------------------- EVENTOS -------------------------------------------------
        //---------------------------------------------------------------------------------------------------------

        // Evento Load para el formulario.
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            if (archivo.Leer(ruta))
            {
                dictionary = (Dictionary<string, Usuario>)archivo.Objeto;
                ActualizarTabla(ref dgvTabla);
            }
        }

        // Evento Click para el boton agregar.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool completado = true;
            if (Regex.IsMatch(txtNombre.Text, patronNombre) == false || txtNombre.Text.Length < 3)
            {
                errorProvider.SetError(txtNombre, "Ingrese un nombre (min 3 caracteres, max 50)");
                completado = false;
            }
            else
                errorProvider.Clear();
            if (string.IsNullOrEmpty(txtUsuario.Text) || txtUsuario.Text.Length < 3)
            {
                errorProvider.SetError(txtUsuario, "Ingrese un usuario (min 3 caracteres, max 10)");
                completado = false;
            }
            else
                errorProvider.Clear();
            if (string.IsNullOrEmpty(txtContrasena.Text) || txtContrasena.Text.Length < 5)
            {
                errorProvider.SetError(txtContrasena, "Ingrese una clave (min 5 digitos, max 8)");
                completado = false;
            }
            else
                errorProvider.Clear();
            if (completado)
            {
                usuario = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    User = txtUsuario.Text.Trim(),
                    Password = txtContrasena.Text.Trim(),
                    Acceso = "user"
                };

                if (dictionary.ContainsKey(usuario.User))
                {
                    MessageBox.Show("El usuario ya esta registrado", "Usuarios",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    dictionary.Add(usuario.User, usuario);
                    archivo.Guardar(ruta, dictionary);

                    dgvTabla.Rows.Add(usuario.Nombre, usuario.User, usuario.Password);
                    dgvTabla.ClearSelection();
                    txtNombre.Clear();
                    txtUsuario.Clear();
                    txtContrasena.Clear();
                    txtNombre.Focus();
                }
            }
        }

        // Evento para boton elminar dentro del datagrid    
        private void dgvTabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTabla.Columns[3].Index && e.RowIndex >= 0)
            {
                string usuario = dgvTabla.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();

                DialogResult dialogResult = MessageBox.Show("Esta seguro de eliminar al usuario " + usuario, "Usuarios",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (dialogResult == DialogResult.OK)
                {
                    dictionary.Remove(usuario);
                    archivo.Guardar(ruta, dictionary);
                    ActualizarTabla(ref dgvTabla);
                }
            }
        }

        // Funcion para actualizar tabla.
        private void ActualizarTabla(ref DataGridView gridView)
        {
            if (dictionary.Count >= 0)
            {
                gridView.Rows.Clear();
                foreach (Usuario item in dictionary.Values)
                {
                    gridView.Rows.Add(item.Nombre, item.User, item.Password);
                }
                gridView.ClearSelection();
            }
            else
                MessageBox.Show("No hay usuarios registrados.");
        }
    }
}
