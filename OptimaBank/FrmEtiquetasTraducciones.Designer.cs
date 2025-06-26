namespace OptimaBank.UI
{
    partial class FrmEtiquetasTraducciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEtiquetasTraducciones));
            panel1 = new Panel();
            groupBox2 = new GroupBox();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            lblDescripcion = new Label();
            lblNombre = new Label();
            groupBox1 = new GroupBox();
            listBoxEtiquetas = new ListBox();
            groupBox3 = new GroupBox();
            dataGridViewTraducciones = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            BtnCancelar = new Button();
            btnAceptar = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTraducciones).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 450);
            panel1.TabIndex = 9;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtApellidos);
            groupBox2.Controls.Add(txtNombres);
            groupBox2.Controls.Add(lblDescripcion);
            groupBox2.Controls.Add(lblNombre);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(536, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(362, 322);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de la Etiqueta";
            // 
            // txtApellidos
            // 
            txtApellidos.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApellidos.Location = new Point(114, 78);
            txtApellidos.MaxLength = 100;
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(222, 27);
            txtApellidos.TabIndex = 8;
            // 
            // txtNombres
            // 
            txtNombres.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombres.Location = new Point(114, 38);
            txtNombres.MaxLength = 100;
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(222, 27);
            txtNombres.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescripcion.Location = new Point(21, 78);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(87, 20);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Descripción";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(21, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxEtiquetas);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(210, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 333);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Etiquetas Disponibles";
            // 
            // listBoxEtiquetas
            // 
            listBoxEtiquetas.FormattingEnabled = true;
            listBoxEtiquetas.ItemHeight = 20;
            listBoxEtiquetas.Location = new Point(20, 38);
            listBoxEtiquetas.Name = "listBoxEtiquetas";
            listBoxEtiquetas.Size = new Size(226, 284);
            listBoxEtiquetas.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dataGridViewTraducciones);
            groupBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(917, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(363, 333);
            groupBox3.TabIndex = 15;
            groupBox3.TabStop = false;
            groupBox3.Text = "Traducciones";
            // 
            // dataGridViewTraducciones
            // 
            dataGridViewTraducciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTraducciones.Location = new Point(13, 38);
            dataGridViewTraducciones.Name = "dataGridViewTraducciones";
            dataGridViewTraducciones.Size = new Size(344, 233);
            dataGridViewTraducciones.TabIndex = 0;
            // 
            // button2
            // 
            button2.BackColor = Color.Crimson;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Location = new Point(371, 361);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(129, 40);
            button2.TabIndex = 21;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.RoyalBlue;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Location = new Point(228, 361);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(129, 40);
            button1.TabIndex = 20;
            button1.Text = "Nueva";
            button1.UseVisualStyleBackColor = false;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.Crimson;
            BtnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnCancelar.ForeColor = Color.White;
            BtnCancelar.Location = new Point(724, 361);
            BtnCancelar.Margin = new Padding(3, 2, 3, 2);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(129, 40);
            BtnCancelar.TabIndex = 19;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            btnAceptar.BackColor = Color.Green;
            btnAceptar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAceptar.ForeColor = Color.White;
            btnAceptar.Location = new Point(557, 361);
            btnAceptar.Margin = new Padding(3, 2, 3, 2);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(129, 40);
            btnAceptar.TabIndex = 18;
            btnAceptar.Text = "Guardar";
            btnAceptar.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Goldenrod;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button3.ForeColor = Color.White;
            button3.Location = new Point(930, 361);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(129, 40);
            button3.TabIndex = 22;
            button3.Text = "Nueva";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Crimson;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(1217, 361);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(129, 40);
            button4.TabIndex = 24;
            button4.Text = "Eliminar";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.RoyalBlue;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.ForeColor = Color.White;
            button5.Location = new Point(1074, 361);
            button5.Margin = new Padding(3, 2, 3, 2);
            button5.Name = "button5";
            button5.Size = new Size(129, 40);
            button5.TabIndex = 23;
            button5.Text = "Editar";
            button5.UseVisualStyleBackColor = false;
            // 
            // FrmEtiquetasTraducciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 450);
            Controls.Add(button4);
            Controls.Add(button5);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(BtnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmEtiquetasTraducciones";
            Text = "FrmEtiquetasTraducciones";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewTraducciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox2;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private Label lblDescripcion;
        private Label lblNombre;
        private GroupBox groupBox1;
        private ListBox listBoxEtiquetas;
        private GroupBox groupBox3;
        private Button button2;
        private Button button1;
        private Button BtnCancelar;
        private Button btnAceptar;
        private Button button3;
        private Button button4;
        private Button button5;
        private DataGridView dataGridViewTraducciones;
    }
}