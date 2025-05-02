namespace OptimaBank
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            btnAceptar = new Button();
            lblUser = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            lblPass = new Label();
            BtnCancelar = new Button();
            panel1 = new Panel();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.ForeColor = SystemColors.ButtonShadow;
            btnAceptar.Location = new Point(215, 123);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(129, 40);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUser.ForeColor = SystemColors.ButtonShadow;
            lblUser.Location = new Point(206, 24);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(67, 21);
            lblUser.TabIndex = 1;
            lblUser.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtUsuario.ForeColor = SystemColors.ButtonShadow;
            txtUsuario.Location = new Point(290, 23);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(201, 29);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtPassword.ForeColor = SystemColors.ButtonShadow;
            txtPassword.Location = new Point(290, 68);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(201, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPass.ForeColor = SystemColors.ButtonShadow;
            lblPass.Location = new Point(205, 70);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(79, 21);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            BtnCancelar.ForeColor = SystemColors.ButtonShadow;
            BtnCancelar.Location = new Point(362, 123);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 40);
            BtnCancelar.TabIndex = 5;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = true;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(linkLabel2);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(183, 182);
            panel1.TabIndex = 6;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel2.Location = new Point(3, 148);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(70, 12);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Nuevo Usuario";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            linkLabel1.Location = new Point(87, 148);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(93, 12);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Cambiar Contraseña";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(34, 37);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(111, 102);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AcceptButton = btnAceptar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = BtnCancelar;
            ClientSize = new Size(525, 182);
            Controls.Add(panel1);
            Controls.Add(BtnCancelar);
            Controls.Add(lblPass);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUser);
            Controls.Add(btnAceptar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            Opacity = 0.5D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private Label lblUser;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Label lblPass;
        private Button BtnCancelar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}