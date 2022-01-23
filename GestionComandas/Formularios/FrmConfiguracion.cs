using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionComandas
{
    public partial class FrmConfiguracion : Form
    {
        string ruta = "config.bin";
        bool completado = true;
        private Archivo archivo;
        private Configuracion configuracion;
        
        public FrmConfiguracion()
        {
            InitializeComponent();

            archivo = new Archivo();
        }

        //---------------------------------- EVENTOS ---------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------

        // Evento Load del Formulario.
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            if (archivo.Leer(ruta))
            {
                configuracion = (Configuracion)archivo.Objeto;
                txtUsuario.Text = configuracion.Usuario.User;
                txtPassword.Text = configuracion.Usuario.Password;
                numericMesas.Value = configuracion.NMesas;
                numericPropina.Value = configuracion.Propina;
            }            
        }

        // Evento Click para el boton *Actualizar*
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ValidarEntradas();
            if (completado)
            {
                configuracion = new Configuracion();
                configuracion.Usuario.User = txtUsuario.Text.Trim();
                configuracion.Usuario.Password = txtPassword.Text.Trim();
                configuracion.Usuario.Acceso = "Admin";

                decimal propina = (numericPropina.Value / 100) + 1;

                configuracion.Propina = propina;
                configuracion.NMesas = (int)numericMesas.Value;


                archivo.Guardar(ruta, configuracion);
                MessageBox.Show("Configuracion realizada con exito!", "Configuracion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
        }

        //---------------------------------- FUNCIONES -------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------

        // Funcion para Validar entra de datos.
        private void ValidarEntradas()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || txtUsuario.Text.Length < 3)
            {
                errorProvider.SetError(txtUsuario, "Ingrese un usuario (min 3 caracteres)");
                completado = false;
            }
            else
            {
                errorProvider.Clear();
                completado = true;
            }

            if (string.IsNullOrEmpty(txtPassword.Text) || txtPassword.Text.Length < 5)
            {
                errorProvider.SetError(txtPassword, "Ingrese una clave (min 5 digitos)");
                completado = false;
            }
            else
            {
                errorProvider.Clear();
                completado = true;
            }                
        }

        // Funcion para retorno configuracion.
        public Configuracion GetConfiguracion()
        {
            return configuracion;
        }
    }
}
