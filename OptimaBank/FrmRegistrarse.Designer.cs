namespace OptimaBank.UI
{
    partial class FrmRegistrarse
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
            gbRegistrarse = new GroupBox();
            mtbDocumento = new MaskedTextBox();
            mtbCelular = new MaskedTextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            txtRepite = new TextBox();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            dtpNacimiento = new DateTimePicker();
            cmbSexo = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            BtnCancelar = new Button();
            btnAceptar = new Button();
            panel1 = new Panel();
            gbRegistrarse.SuspendLayout();
            SuspendLayout();
            // 
            // gbRegistrarse
            // 
            gbRegistrarse.Controls.Add(mtbDocumento);
            gbRegistrarse.Controls.Add(mtbCelular);
            gbRegistrarse.Controls.Add(lblEmail);
            gbRegistrarse.Controls.Add(txtEmail);
            gbRegistrarse.Controls.Add(label7);
            gbRegistrarse.Controls.Add(label8);
            gbRegistrarse.Controls.Add(label9);
            gbRegistrarse.Controls.Add(txtRepite);
            gbRegistrarse.Controls.Add(txtContraseña);
            gbRegistrarse.Controls.Add(txtUsuario);
            gbRegistrarse.Controls.Add(dtpNacimiento);
            gbRegistrarse.Controls.Add(cmbSexo);
            gbRegistrarse.Controls.Add(label6);
            gbRegistrarse.Controls.Add(label5);
            gbRegistrarse.Controls.Add(label4);
            gbRegistrarse.Controls.Add(label3);
            gbRegistrarse.Controls.Add(label2);
            gbRegistrarse.Controls.Add(label1);
            gbRegistrarse.Controls.Add(txtApellidos);
            gbRegistrarse.Controls.Add(txtNombres);
            gbRegistrarse.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbRegistrarse.Location = new Point(201, 0);
            gbRegistrarse.Name = "gbRegistrarse";
            gbRegistrarse.Size = new Size(649, 374);
            gbRegistrarse.TabIndex = 0;
            gbRegistrarse.TabStop = false;
            gbRegistrarse.Text = "Registrarse";
            // 
            // mtbDocumento
            // 
            mtbDocumento.Location = new Point(128, 114);
            mtbDocumento.Mask = "00000000";
            mtbDocumento.Name = "mtbDocumento";
            mtbDocumento.Size = new Size(118, 27);
            mtbDocumento.TabIndex = 23;
            // 
            // mtbCelular
            // 
            mtbCelular.Location = new Point(314, 181);
            mtbCelular.Mask = "+54 (00) 0000-0000";
            mtbCelular.Name = "mtbCelular";
            mtbCelular.Size = new Size(151, 27);
            mtbCelular.TabIndex = 22;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(257, 249);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 21;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(309, 246);
            txtEmail.MaxLength = 50;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(320, 27);
            txtEmail.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(304, 322);
            label7.Name = "label7";
            label7.Size = new Size(130, 20);
            label7.TabIndex = 19;
            label7.Text = "Repite Contraseña";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(15, 322);
            label8.Name = "label8";
            label8.Size = new Size(83, 20);
            label8.TabIndex = 18;
            label8.Text = "Contraseña";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(15, 249);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 17;
            label9.Text = "Usuario";
            // 
            // txtRepite
            // 
            txtRepite.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRepite.Location = new Point(440, 319);
            txtRepite.MaxLength = 10;
            txtRepite.Name = "txtRepite";
            txtRepite.Size = new Size(189, 27);
            txtRepite.TabIndex = 9;
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.Location = new Point(114, 319);
            txtContraseña.MaxLength = 10;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(173, 27);
            txtContraseña.TabIndex = 8;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.Location = new Point(88, 246);
            txtUsuario.MaxLength = 10;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(135, 27);
            txtUsuario.TabIndex = 6;
            // 
            // dtpNacimiento
            // 
            dtpNacimiento.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpNacimiento.Location = new Point(417, 113);
            dtpNacimiento.Name = "dtpNacimiento";
            dtpNacimiento.Size = new Size(212, 27);
            dtpNacimiento.TabIndex = 3;
            // 
            // cmbSexo
            // 
            cmbSexo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Location = new Point(88, 181);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(135, 28);
            cmbSexo.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(262, 118);
            label6.Name = "label6";
            label6.Size = new Size(149, 20);
            label6.TabIndex = 11;
            label6.Text = "Fecha de Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(254, 184);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 10;
            label5.Text = "Celular";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(16, 184);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 9;
            label4.Text = "Sexo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 116);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 8;
            label3.Text = "N° Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(294, 56);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 7;
            label2.Text = "Apellidos";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 56);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 6;
            label1.Text = "Nombres";
            // 
            // txtApellidos
            // 
            txtApellidos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(372, 53);
            txtApellidos.MaxLength = 100;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(257, 27);
            txtApellidos.TabIndex = 1;
            // 
            // txtNombres
            // 
            txtNombres.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(88, 53);
            txtNombres.MaxLength = 100;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(197, 27);
            txtNombres.TabIndex = 0;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.RoyalBlue;
            BtnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.White;
            BtnCancelar.Location = new Point(721, 383);
            BtnCancelar.Margin = new Padding(3, 2, 3, 2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 40);
            BtnCancelar.TabIndex = 11;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.RoyalBlue;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(574, 383);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(129, 40);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Registrar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 432);
            panel1.TabIndex = 8;
            // 
            // FrmRegistrarse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 432);
            Controls.Add(panel1);
            Controls.Add(BtnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(gbRegistrarse);
            Name = "FrmRegistrarse";
            Text = "FrmRegistrarse";
            gbRegistrarse.ResumeLayout(false);
            gbRegistrarse.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbRegistrarse;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DateTimePicker dtpNacimiento;
        private ComboBox cmbSexo;
        private Button BtnCancelar;
        private Button btnAceptar;
        private Panel panel1;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox txtRepite;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Label lblEmail;
        private TextBox txtEmail;
        private MaskedTextBox mtbCelular;
        private MaskedTextBox mtbDocumento;
    }
}