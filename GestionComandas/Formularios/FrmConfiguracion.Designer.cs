namespace GestionComandas
{
    partial class FrmConfiguracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.groupOpciones = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericPropina = new System.Windows.Forms.NumericUpDown();
            this.numericMesas = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupAdmin = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlEncabezado.SuspendLayout();
            this.groupOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPropina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMesas)).BeginInit();
            this.groupAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.Color.Maroon;
            this.pnlEncabezado.Controls.Add(this.label4);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(404, 38);
            this.pnlEncabezado.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Configuración";
            // 
            // groupOpciones
            // 
            this.groupOpciones.Controls.Add(this.label8);
            this.groupOpciones.Controls.Add(this.label7);
            this.groupOpciones.Controls.Add(this.numericPropina);
            this.groupOpciones.Controls.Add(this.numericMesas);
            this.groupOpciones.Controls.Add(this.label5);
            this.groupOpciones.Controls.Add(this.label2);
            this.groupOpciones.Controls.Add(this.label1);
            this.groupOpciones.Location = new System.Drawing.Point(12, 44);
            this.groupOpciones.Name = "groupOpciones";
            this.groupOpciones.Size = new System.Drawing.Size(293, 80);
            this.groupOpciones.TabIndex = 8;
            this.groupOpciones.TabStop = false;
            this.groupOpciones.Text = "Opciones";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "(Max. 20)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "(Max. 60)";
            // 
            // numericPropina
            // 
            this.numericPropina.Location = new System.Drawing.Point(73, 49);
            this.numericPropina.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericPropina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPropina.Name = "numericPropina";
            this.numericPropina.Size = new System.Drawing.Size(155, 20);
            this.numericPropina.TabIndex = 5;
            this.numericPropina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericMesas
            // 
            this.numericMesas.Location = new System.Drawing.Point(73, 22);
            this.numericMesas.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMesas.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMesas.Name = "numericMesas";
            this.numericMesas.Size = new System.Drawing.Size(155, 20);
            this.numericMesas.TabIndex = 4;
            this.numericMesas.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "% Propina:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "No. Mesas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 47);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '☻';
            this.txtPassword.Size = new System.Drawing.Size(152, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(76, 21);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(152, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // groupAdmin
            // 
            this.groupAdmin.Controls.Add(this.label6);
            this.groupAdmin.Controls.Add(this.label3);
            this.groupAdmin.Controls.Add(this.txtUsuario);
            this.groupAdmin.Controls.Add(this.txtPassword);
            this.groupAdmin.Location = new System.Drawing.Point(12, 130);
            this.groupAdmin.Name = "groupAdmin";
            this.groupAdmin.Size = new System.Drawing.Size(293, 78);
            this.groupAdmin.TabIndex = 4;
            this.groupAdmin.TabStop = false;
            this.groupAdmin.Text = "Administrador:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Contraseña:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImage = global::GestionComandas.Properties.Resources._checked;
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Location = new System.Drawing.Point(342, 158);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(50, 50);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(404, 217);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.groupAdmin);
            this.Controls.Add(this.groupOpciones);
            this.Controls.Add(this.pnlEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.groupOpciones.ResumeLayout(false);
            this.groupOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPropina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMesas)).EndInit();
            this.groupAdmin.ResumeLayout(false);
            this.groupAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupOpciones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.GroupBox groupAdmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.NumericUpDown numericPropina;
        private System.Windows.Forms.NumericUpDown numericMesas;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}