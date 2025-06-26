namespace OptimaBank.UI
{
    partial class FrmPatentesFamilias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPatentesFamilias));
            groupBox1 = new GroupBox();
            btnGuardar = new Button();
            btnSelUsuario = new Button();
            label2 = new Label();
            label1 = new Label();
            cmbPermisos = new ComboBox();
            cmbPatentes = new ComboBox();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            txtNombre = new TextBox();
            label3 = new Label();
            groupBox2 = new GroupBox();
            groupBox4 = new GroupBox();
            label4 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            comboBox2 = new ComboBox();
            button3 = new Button();
            groupBox5 = new GroupBox();
            treeConfigurarFamilia = new TreeView();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(btnSelUsuario);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbPatentes);
            groupBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(201, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(323, 414);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Patentes";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.MediumSeaGreen;
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Transparent;
            btnGuardar.Location = new Point(17, 167);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(129, 40);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnSelUsuario
            // 
            btnSelUsuario.BackColor = Color.RoyalBlue;
            btnSelUsuario.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelUsuario.ForeColor = Color.Transparent;
            btnSelUsuario.Location = new Point(18, 94);
            btnSelUsuario.Name = "btnSelUsuario";
            btnSelUsuario.Size = new Size(129, 40);
            btnSelUsuario.TabIndex = 6;
            btnSelUsuario.Text = "Agregar >>";
            btnSelUsuario.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 29);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 4;
            label2.Text = "Permiso";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 37);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 3;
            label1.Text = "Todas las Patentes";
            // 
            // cmbPermisos
            // 
            cmbPermisos.FormattingEnabled = true;
            cmbPermisos.Location = new Point(17, 52);
            cmbPermisos.Name = "cmbPermisos";
            cmbPermisos.Size = new Size(250, 28);
            cmbPermisos.TabIndex = 1;
            cmbPermisos.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // cmbPatentes
            // 
            cmbPatentes.FormattingEnabled = true;
            cmbPatentes.Location = new Point(18, 60);
            cmbPatentes.Name = "cmbPatentes";
            cmbPatentes.Size = new Size(250, 28);
            cmbPatentes.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.RoyalBlue;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 450);
            panel1.TabIndex = 10;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(txtNombre);
            groupBox3.Controls.Add(btnGuardar);
            groupBox3.Controls.Add(cmbPermisos);
            groupBox3.Controls.Add(label2);
            groupBox3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(18, 162);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(287, 227);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nueva Patente";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(17, 117);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(250, 27);
            txtNombre.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 94);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 9;
            label3.Text = "Nombre";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(530, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(318, 414);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Familias";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(textBox1);
            groupBox4.Controls.Add(button1);
            groupBox4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(18, 162);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(283, 227);
            groupBox4.TabIndex = 19;
            groupBox4.TabStop = false;
            groupBox4.Text = "Nueva Familia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 30);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 9;
            label4.Text = "Nombre";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(17, 53);
            textBox1.MaxLength = 100;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 27);
            textBox1.TabIndex = 8;
            // 
            // button1
            // 
            button1.BackColor = Color.Crimson;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(17, 103);
            button1.Name = "button1";
            button1.Size = new Size(129, 40);
            button1.TabIndex = 7;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.RoyalBlue;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(18, 94);
            button2.Name = "button2";
            button2.Size = new Size(129, 40);
            button2.TabIndex = 6;
            button2.Text = "Configurar";
            button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 37);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 3;
            label6.Text = "Todas las Familias";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(18, 60);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(250, 28);
            comboBox2.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.RoyalBlue;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Transparent;
            button3.Location = new Point(162, 94);
            button3.Name = "button3";
            button3.Size = new Size(129, 40);
            button3.TabIndex = 20;
            button3.Text = "Agregar >>";
            button3.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(treeConfigurarFamilia);
            groupBox5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(854, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(504, 414);
            groupBox5.TabIndex = 12;
            groupBox5.TabStop = false;
            groupBox5.Text = "Configurar Familia";
            // 
            // treeConfigurarFamilia
            // 
            treeConfigurarFamilia.Location = new Point(24, 37);
            treeConfigurarFamilia.Name = "treeConfigurarFamilia";
            treeConfigurarFamilia.Size = new Size(458, 352);
            treeConfigurarFamilia.TabIndex = 0;
            // 
            // FrmPatentesFamilias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 450);
            Controls.Add(groupBox5);
            Controls.Add(groupBox2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmPatentesFamilias";
            Text = "FrmPatentesFamilias";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnSelPatente;
        private Button btnGuardar;
        private Button btnSelUsuario;
        private Label label2;
        private Label label1;
        private ComboBox comboBox3;
        private ComboBox cmbPermisos;
        private ComboBox cmbPatentes;
        private Panel panel1;
        private GroupBox groupBox3;
        private Label label3;
        private TextBox txtNombre;
        private GroupBox groupBox2;
        private Button button3;
        private GroupBox groupBox4;
        private Label label4;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label6;
        private ComboBox comboBox2;
        private GroupBox groupBox5;
        private TreeView treeConfigurarFamilia;
        private Label lIdiomaDefaul;
        private ComboBox cmbIdiomas;
    }
}