namespace OptimaBank.UI
{
    partial class FrmIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIdioma));
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            listBoxIdiomas = new ListBox();
            groupBox2 = new GroupBox();
            lblId = new Label();
            txtIdIdioma = new TextBox();
            chkbDefault = new CheckBox();
            txtImagen = new TextBox();
            txtDescripcion = new TextBox();
            txtNombre = new TextBox();
            lblImagen = new Label();
            lblDefault = new Label();
            lblDescripcion = new Label();
            lblNombre = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            btnNuevo = new Button();
            btnModificar = new Button();
            cmbIdiomas = new ComboBox();
            groupBox3 = new GroupBox();
            btnCambiar = new Button();
            lIdiomaDefaul = new Label();
            btnEliminar = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
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
            // groupBox1
            // 
            groupBox1.Controls.Add(listBoxIdiomas);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(221, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 369);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Idiomas Disponibles";
            // 
            // listBoxIdiomas
            // 
            listBoxIdiomas.FormattingEnabled = true;
            listBoxIdiomas.ItemHeight = 20;
            listBoxIdiomas.Location = new Point(20, 38);
            listBoxIdiomas.Name = "listBoxIdiomas";
            listBoxIdiomas.Size = new Size(252, 304);
            listBoxIdiomas.TabIndex = 0;
            listBoxIdiomas.SelectedIndexChanged += listBoxIdiomas_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblId);
            groupBox2.Controls.Add(txtIdIdioma);
            groupBox2.Controls.Add(chkbDefault);
            groupBox2.Controls.Add(txtImagen);
            groupBox2.Controls.Add(txtDescripcion);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(lblImagen);
            groupBox2.Controls.Add(lblDefault);
            groupBox2.Controls.Add(lblDescripcion);
            groupBox2.Controls.Add(lblNombre);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(531, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(369, 215);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle del Idioma";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblId.Location = new Point(210, 172);
            lblId.Name = "lblId";
            lblId.Size = new Size(22, 20);
            lblId.TabIndex = 12;
            lblId.Text = "Id";
            // 
            // txtIdIdioma
            // 
            txtIdIdioma.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtIdIdioma.Location = new Point(240, 169);
            txtIdIdioma.MaxLength = 100;
            txtIdIdioma.Name = "txtIdIdioma";
            txtIdIdioma.Size = new Size(96, 27);
            txtIdIdioma.TabIndex = 11;
            // 
            // chkbDefault
            // 
            chkbDefault.AutoSize = true;
            chkbDefault.Location = new Point(119, 176);
            chkbDefault.Name = "chkbDefault";
            chkbDefault.Size = new Size(15, 14);
            chkbDefault.TabIndex = 10;
            chkbDefault.UseVisualStyleBackColor = true;
            // 
            // txtImagen
            // 
            txtImagen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtImagen.Location = new Point(114, 119);
            txtImagen.MaxLength = 100;
            txtImagen.Name = "txtImagen";
            txtImagen.Size = new Size(222, 27);
            txtImagen.TabIndex = 9;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescripcion.Location = new Point(114, 78);
            txtDescripcion.MaxLength = 100;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(222, 27);
            txtDescripcion.TabIndex = 8;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(114, 38);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(222, 27);
            txtNombre.TabIndex = 7;
            // 
            // lblImagen
            // 
            lblImagen.AutoSize = true;
            lblImagen.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblImagen.Location = new Point(26, 122);
            lblImagen.Name = "lblImagen";
            lblImagen.Size = new Size(59, 20);
            lblImagen.TabIndex = 3;
            lblImagen.Text = "Imagen";
            // 
            // lblDefault
            // 
            lblDefault.AutoSize = true;
            lblDefault.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDefault.Location = new Point(27, 172);
            lblDefault.Name = "lblDefault";
            lblDefault.Size = new Size(58, 20);
            lblDefault.TabIndex = 2;
            lblDefault.Text = "Default";
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
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Crimson;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(771, 397);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(129, 40);
            btnCancelar.TabIndex = 15;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.RoyalBlue;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(636, 397);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 40);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.RoyalBlue;
            btnNuevo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNuevo.ForeColor = Color.White;
            btnNuevo.Location = new Point(229, 397);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(129, 40);
            btnNuevo.TabIndex = 16;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = Color.Crimson;
            btnModificar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnModificar.ForeColor = Color.White;
            btnModificar.Location = new Point(364, 397);
            btnModificar.Margin = new Padding(3, 2, 3, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(129, 40);
            btnModificar.TabIndex = 17;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // cmbIdiomas
            // 
            cmbIdiomas.FormattingEnabled = true;
            cmbIdiomas.Location = new Point(119, 36);
            cmbIdiomas.Name = "cmbIdiomas";
            cmbIdiomas.Size = new Size(217, 28);
            cmbIdiomas.TabIndex = 13;
            cmbIdiomas.SelectedIndexChanged += cmbIdiomas_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnCambiar);
            groupBox3.Controls.Add(lIdiomaDefaul);
            groupBox3.Controls.Add(cmbIdiomas);
            groupBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(531, 246);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(369, 135);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cambiar Default";
            // 
            // btnCambiar
            // 
            btnCambiar.BackColor = Color.MediumSeaGreen;
            btnCambiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCambiar.ForeColor = Color.White;
            btnCambiar.Location = new Point(26, 83);
            btnCambiar.Margin = new Padding(3, 2, 3, 2);
            btnCambiar.Name = "btnCambiar";
            btnCambiar.Size = new Size(87, 36);
            btnCambiar.TabIndex = 15;
            btnCambiar.Text = "Cambiar";
            btnCambiar.UseVisualStyleBackColor = false;
            btnCambiar.Click += btnCambiar_Click;
            // 
            // lIdiomaDefaul
            // 
            lIdiomaDefaul.AutoSize = true;
            lIdiomaDefaul.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lIdiomaDefaul.Location = new Point(21, 39);
            lIdiomaDefaul.Name = "lIdiomaDefaul";
            lIdiomaDefaul.Size = new Size(56, 20);
            lIdiomaDefaul.TabIndex = 14;
            lIdiomaDefaul.Text = "Idioma";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.DimGray;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(501, 397);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(129, 40);
            btnEliminar.TabIndex = 19;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmIdioma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 450);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox3);
            Controls.Add(btnModificar);
            Controls.Add(btnNuevo);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmIdioma";
            Text = "FrmIdioma";
            Load += FrmIdioma_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private ListBox listBoxIdiomas;
        private GroupBox groupBox2;
        private Label lblImagen;
        private Label lblDefault;
        private Label lblDescripcion;
        private Label lblNombre;
        private CheckBox chkbDefault;
        private TextBox txtImagen;
        private TextBox txtDescripcion;
        private TextBox txtNombre;
        private Button btnCancelar;
        private Button btnGuardar;
        private Button btnNuevo;
        private Button btnModificar;
        private TextBox txtIdIdioma;
        private Label lblId;
        private ComboBox cmbIdiomas;
        private GroupBox groupBox3;
        private Label lIdiomaDefaul;
        private Button btnCambiar;
        private Button btnEliminar;
    }
}