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
            btnOlvidePass = new Button();
            btnRegistrarse = new Button();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.RoyalBlue;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(223, 121);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(129, 40);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUser.ForeColor = SystemColors.ActiveCaptionText;
            lblUser.Location = new Point(212, 30);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(82, 25);
            lblUser.TabIndex = 1;
            lblUser.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.ForeColor = SystemColors.ButtonShadow;
            txtUsuario.Location = new Point(315, 29);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(183, 29);
            txtUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 12F);
            txtPassword.ForeColor = SystemColors.ButtonShadow;
            txtPassword.Location = new Point(315, 66);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(183, 29);
            txtPassword.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPass.ForeColor = SystemColors.ActiveCaptionText;
            lblPass.Location = new Point(212, 68);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(97, 25);
            lblPass.TabIndex = 4;
            lblPass.Text = "Password:";
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.RoyalBlue;
            BtnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.White;
            BtnCancelar.Location = new Point(370, 121);
            BtnCancelar.Margin = new Padding(3, 2, 3, 2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 40);
            BtnCancelar.TabIndex = 5;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(btnOlvidePass);
            panel1.Controls.Add(btnRegistrarse);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 182);
            panel1.TabIndex = 6;
            // 
            // btnOlvidePass
            // 
            btnOlvidePass.BackColor = Color.LightGray;
            btnOlvidePass.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnOlvidePass.Location = new Point(99, 143);
            btnOlvidePass.Margin = new Padding(3, 2, 3, 2);
            btnOlvidePass.Name = "btnOlvidePass";
            btnOlvidePass.Size = new Size(90, 31);
            btnOlvidePass.TabIndex = 8;
            btnOlvidePass.Text = "Olvidé Password";
            btnOlvidePass.UseVisualStyleBackColor = false;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.BackColor = Color.LightGray;
            btnRegistrarse.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            btnRegistrarse.Location = new Point(4, 143);
            btnRegistrarse.Margin = new Padding(3, 2, 3, 2);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(90, 31);
            btnRegistrarse.TabIndex = 7;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = false;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(54, 30);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 85);
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
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLogin";
            Opacity = 0.5D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Optima Bank";
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
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
        private Button btnOlvidePass;
        private Button btnRegistrarse;
    }
}