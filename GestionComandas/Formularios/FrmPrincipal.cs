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
    public partial class FrmPrincipal : Form
    {
        FrmAcceso acceso;
        FrmUsuarios usuarios;
        FrmMenu menu;
        FrmComandas comandas;
        FrmConfiguracion configuracion;
        Usuario usuario;

        bool cambiar;

        public FrmPrincipal()
        {
            InitializeComponent();

            usuarios = null;
            menu = null;
            comandas = null;
            configuracion = null;
        }

        // Eventos y Funciones personalizadas para Abrir formularios hijo.

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usuarios == null)
            {
                usuarios = new FrmUsuarios();
                usuarios.MdiParent = this;
                usuarios.FormClosed += new FormClosedEventHandler(Usuario_Cerrado);
                usuarios.Show();
            }
            else
            {
                usuarios.Activate();
            }
        }

        void Usuario_Cerrado(object sender, EventArgs e)
        {
            usuarios = null;
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menu == null)
            {
                menu = new FrmMenu();
                menu.MdiParent = this;
                menu.FormClosed += new FormClosedEventHandler(Menu_Cerrado);
                menu.Show();
            }
            else
            {
                menu.Activate();
            }
        }

        void Menu_Cerrado(object sender, EventArgs e)
        {
            menu = null;
        }

        private void comandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comandas == null)
            {
                comandas = new FrmComandas();
                comandas.mesero = usuario.Nombre;
                comandas.MdiParent = this;
                comandas.FormClosed += new FormClosedEventHandler(Comanda_Cerrado);
                comandas.Show();
            }
            else
            {
                comandas.Activate();
            }
        }

        void Comanda_Cerrado(object sender, EventArgs e)
        {
            comandas = null;
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (configuracion == null)
            {
                configuracion = new FrmConfiguracion();
                configuracion.MdiParent = this;
                configuracion.FormClosed += new FormClosedEventHandler(Configuracion_Cerrado);
                configuracion.Show();
            }
            else
            {
                configuracion.Activate();
            }
        }

        void Configuracion_Cerrado(object sender, EventArgs e)
        {
            configuracion = null;
        }


        // Evento click para salir del formulario.
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Esta seguro de salir.", "Sistema", 
                MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.OK)
            {
                Close();
            }
        }

        // Funcion para Acceder al sistema.
        private void AccederSistema()
        {
            acceso = new FrmAcceso();
            if (acceso.ShowDialog(this) == DialogResult.OK)
            {
                usuario = acceso.Acceso.Usuario;
                toolStripStatusLabel1.Text = usuario.Acceso;
                toolStripStatusLabel2.Text = usuario.Nombre;

                if (usuario.Acceso.Equals("user"))
                {
                    toolStripButton1.Enabled = false;
                    toolStripButton2.Enabled = false;
                    toolStripButton4.Enabled = false;
                    editarToolStripMenuItem.Enabled = false;
                    configuracionToolStripMenuItem.Enabled = false;
                    menuToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                if (cambiar == false) 
                {
                    Close();
                }
            }
        }

        // Evento Load del Formulario.
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AccederSistema();
        }

        // Evento para cambiar de usuario.
        private void cambiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cambiar = true;
            AccederSistema();
        }
    }
}
