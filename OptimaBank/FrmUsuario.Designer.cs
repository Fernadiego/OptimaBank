namespace OptimaBank
{
    partial class FrmUsuario
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
            groupBox1 = new GroupBox();
            cmbUsuarios = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSelUsuario = new Button();
            btnSelFamilia = new Button();
            btnSelPatente = new Button();
            tvComponent = new TreeView();
            btnGuardarUsuario = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSelPatente);
            groupBox1.Controls.Add(btnSelFamilia);
            groupBox1.Controls.Add(btnSelUsuario);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(cmbUsuarios);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(364, 309);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Usuarios";
            // 
            // cmbUsuarios
            // 
            cmbUsuarios.FormattingEnabled = true;
            cmbUsuarios.Location = new Point(18, 43);
            cmbUsuarios.Name = "cmbUsuarios";
            cmbUsuarios.Size = new Size(329, 23);
            cmbUsuarios.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(18, 146);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(329, 23);
            comboBox2.TabIndex = 1;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(18, 242);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(329, 23);
            comboBox3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 25);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 3;
            label1.Text = "Todos los Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 128);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 4;
            label2.Text = "Todas las Familias";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 224);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 5;
            label3.Text = "Todas las Patentes";
            // 
            // btnSelUsuario
            // 
            btnSelUsuario.Location = new Point(17, 74);
            btnSelUsuario.Name = "btnSelUsuario";
            btnSelUsuario.Size = new Size(104, 23);
            btnSelUsuario.TabIndex = 6;
            btnSelUsuario.Text = "Seleccionar >>";
            btnSelUsuario.UseVisualStyleBackColor = true;
            // 
            // btnSelFamilia
            // 
            btnSelFamilia.Location = new Point(18, 175);
            btnSelFamilia.Name = "btnSelFamilia";
            btnSelFamilia.Size = new Size(104, 23);
            btnSelFamilia.TabIndex = 7;
            btnSelFamilia.Text = "Agregar >>";
            btnSelFamilia.UseVisualStyleBackColor = true;
            // 
            // btnSelPatente
            // 
            btnSelPatente.Location = new Point(18, 271);
            btnSelPatente.Name = "btnSelPatente";
            btnSelPatente.Size = new Size(104, 23);
            btnSelPatente.TabIndex = 8;
            btnSelPatente.Text = "Agregar >>";
            btnSelPatente.UseVisualStyleBackColor = true;
            // 
            // tvComponent
            // 
            tvComponent.Location = new Point(409, 21);
            tvComponent.Name = "tvComponent";
            tvComponent.Size = new Size(424, 256);
            tvComponent.TabIndex = 1;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.Location = new Point(679, 283);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(154, 23);
            btnGuardarUsuario.TabIndex = 9;
            btnGuardarUsuario.Text = "Guardar Cambios >>";
            btnGuardarUsuario.UseVisualStyleBackColor = true;
            // 
            // FrmUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 333);
            Controls.Add(btnGuardarUsuario);
            Controls.Add(tvComponent);
            Controls.Add(groupBox1);
            Name = "FrmUsuario";
            Text = "FrmUsuario";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBox3;
        private ComboBox comboBox2;
        private ComboBox cmbUsuarios;
        private Button btnSelPatente;
        private Button btnSelFamilia;
        private Button btnSelUsuario;
        private TreeView tvComponent;
        private Button btnGuardarUsuario;
    }
}