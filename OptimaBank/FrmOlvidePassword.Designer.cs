namespace OptimaBank.UI
{
    partial class FrmOlvidePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOlvidePassword));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            BtnCancelar = new Button();
            txtUsuario = new TextBox();
            lblUser = new Label();
            btnAceptar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 178);
            panel1.TabIndex = 7;
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
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.RoyalBlue;
            BtnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.White;
            BtnCancelar.Location = new Point(372, 121);
            BtnCancelar.Margin = new Padding(3, 2, 3, 2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 40);
            BtnCancelar.TabIndex = 13;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Segoe UI", 12F);
            txtUsuario.ForeColor = SystemColors.ButtonShadow;
            txtUsuario.Location = new Point(317, 29);
            txtUsuario.Margin = new Padding(3, 2, 3, 2);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(183, 29);
            txtUsuario.TabIndex = 10;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblUser.ForeColor = SystemColors.ActiveCaptionText;
            lblUser.Location = new Point(214, 30);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(63, 25);
            lblUser.TabIndex = 9;
            lblUser.Text = "Email:";
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.RoyalBlue;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(225, 121);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(129, 40);
            btnAceptar.TabIndex = 8;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // FrmOlvidePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 178);
            Controls.Add(BtnCancelar);
            Controls.Add(txtUsuario);
            Controls.Add(lblUser);
            Controls.Add(btnAceptar);
            Controls.Add(panel1);
            Name = "FrmOlvidePassword";
            Text = "FrmOlvidePassword";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Button BtnCancelar;
        private TextBox txtUsuario;
        private Label lblUser;
        private Button btnAceptar;
    }
}