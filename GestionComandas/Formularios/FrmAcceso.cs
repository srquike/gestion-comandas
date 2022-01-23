using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GestionComandas
{
    public partial class FrmAcceso : Form
    {
        Archivo archivo;
        Configuracion configuracion;
        Dictionary<string, Usuario> dictionay;
        private Acceso acceso;

        bool completado = true;

        internal Acceso Acceso { get => acceso; set => acceso = value; }

        //string nombre, acceso;

        public FrmAcceso()
        {
            InitializeComponent();

            archivo = new Archivo();
            acceso = new Acceso();

            if (archivo.Leer("usuarios.bin"))
                dictionay = (Dictionary<string, Usuario>)archivo.Objeto; 
        }

        //---------------------------------- EVENTOS -------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        
        // Evento Load del Formulario.
        private void FrmAcceso_Load(object sender, EventArgs e)
        {
            if (archivo.Leer("config.bin"))
            {
                configuracion = (Configuracion)archivo.Objeto;
            }
            else
            {
                MessageBox.Show("Gracias por adquirir nuestro software. Ahora administrar su restaurante sera " +
                    " mas facil. Pero primero debe hacer la configuracion inicial.","Bienvenido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FrmConfiguracion frmConfiguracion = new FrmConfiguracion();
                if (frmConfiguracion.ShowDialog(this) == DialogResult.OK) 
                {
                    configuracion = frmConfiguracion.GetConfiguracion();
                }
            }
        }

        // Evento Click para boton *Cancelar*
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Evento Click para boton *Ingresar*
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (rdAdminitrador.Checked)
            {
                ValidarEntradas();
                if (completado)
                {
                    VerificarDatos();
                }
            }
            else if (rdMesero.Checked)
            {
                ValidarEntradas();
                if (completado)
                {
                    VerificarDatos();
                }
            }
            else
            {
                MessageBox.Show("Seleccione el tipo de acceso (Administrador o Mesero)");
            }
        }


        //---------------------------------- FUNCIONES -----------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------

        // Funcion para verificar los datos ingresados.
        private void VerificarDatos()
        {
            string usuario = txtUsuario.Text.Trim(), password = txtContrasena.Text.Trim();

            if (rdAdminitrador.Checked)
            {
                if (usuario.Equals(configuracion.Usuario.User) == false)
                {
                    MessageBox.Show("El usuario es incorrecto.");
                    txtUsuario.SelectAll();
                }
                else
                {
                    if (password.Equals(configuracion.Usuario.Password) == false)
                    {
                        MessageBox.Show("La clave es incorrecta.");
                        txtContrasena.SelectAll();
                    }
                    else
                    {
                        acceso.Usuario = configuracion.Usuario;
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            else if (rdMesero.Checked)
            {
                if (dictionay.ContainsKey(usuario) == false)
                {
                    MessageBox.Show("El usuario es incorrecto.");
                    txtUsuario.SelectAll();
                }
                else
                {
                    if (password.Equals(dictionay[usuario].Password) == false)
                    {
                        MessageBox.Show("La clave es incorrecta.");
                        txtContrasena.SelectAll();
                    }
                    else
                    {
                        acceso.Usuario = dictionay[usuario];
                        DialogResult = DialogResult.OK;
                    }
                }
            }
        }

        // Funcion para validar las entradas.
        private void ValidarEntradas()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider.SetError(txtUsuario, "Ingrese el nombre de usuario registrado.");
                completado = false;
            }
            else
                errorProvider.Clear();

            if (string.IsNullOrEmpty(txtContrasena.Text))
            {
                errorProvider.SetError(txtContrasena, "Ingrese la clave para el usuario.");
                completado = false;
            }
            else
                errorProvider.Clear();
        }
    }
}
