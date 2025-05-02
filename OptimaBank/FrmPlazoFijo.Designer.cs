namespace OptimaBank.UI
{
    partial class FrmPlazoFijo
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
            btnConsultarSaldo = new Button();
            btnRealizarTransaccion = new Button();
            txtCuentaID = new TextBox();
            lblSaldo = new Label();
            txtMonto = new TextBox();
            cmbTipoTransaccion = new ComboBox();
            txtTasaInteres = new TextBox();
            btnSolicitarPlazoFijo = new Button();
            SuspendLayout();
            // 
            // btnConsultarSaldo
            // 
            btnConsultarSaldo.Location = new Point(266, 175);
            btnConsultarSaldo.Name = "btnConsultarSaldo";
            btnConsultarSaldo.Size = new Size(75, 23);
            btnConsultarSaldo.TabIndex = 0;
            btnConsultarSaldo.Text = "button1";
            btnConsultarSaldo.UseVisualStyleBackColor = true;
            btnConsultarSaldo.Click += btnConsultarSaldo_Click;
            // 
            // btnRealizarTransaccion
            // 
            btnRealizarTransaccion.Location = new Point(461, 175);
            btnRealizarTransaccion.Name = "btnRealizarTransaccion";
            btnRealizarTransaccion.Size = new Size(75, 23);
            btnRealizarTransaccion.TabIndex = 1;
            btnRealizarTransaccion.Text = "button1";
            btnRealizarTransaccion.UseVisualStyleBackColor = true;
            btnRealizarTransaccion.Click += btnRealizarTransaccion_Click;
            // 
            // txtCuentaID
            // 
            txtCuentaID.Location = new Point(262, 86);
            txtCuentaID.Name = "txtCuentaID";
            txtCuentaID.Size = new Size(100, 23);
            txtCuentaID.TabIndex = 2;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(415, 86);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(38, 15);
            lblSaldo.TabIndex = 3;
            lblSaldo.Text = "label1";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(262, 119);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(100, 23);
            txtMonto.TabIndex = 4;
            // 
            // cmbTipoTransaccion
            // 
            cmbTipoTransaccion.FormattingEnabled = true;
            cmbTipoTransaccion.Location = new Point(415, 119);
            cmbTipoTransaccion.Name = "cmbTipoTransaccion";
            cmbTipoTransaccion.Size = new Size(121, 23);
            cmbTipoTransaccion.TabIndex = 5;
            // 
            // txtTasaInteres
            // 
            txtTasaInteres.Location = new Point(56, 146);
            txtTasaInteres.Name = "txtTasaInteres";
            txtTasaInteres.Size = new Size(100, 23);
            txtTasaInteres.TabIndex = 6;
            // 
            // btnSolicitarPlazoFijo
            // 
            btnSolicitarPlazoFijo.Location = new Point(56, 175);
            btnSolicitarPlazoFijo.Name = "btnSolicitarPlazoFijo";
            btnSolicitarPlazoFijo.Size = new Size(75, 23);
            btnSolicitarPlazoFijo.TabIndex = 7;
            btnSolicitarPlazoFijo.Text = "button1";
            btnSolicitarPlazoFijo.UseVisualStyleBackColor = true;
            btnSolicitarPlazoFijo.Click += btnSolicitarPlazoFijo_Click;
            // 
            // FrmPlazoFijo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSolicitarPlazoFijo);
            Controls.Add(txtTasaInteres);
            Controls.Add(cmbTipoTransaccion);
            Controls.Add(txtMonto);
            Controls.Add(lblSaldo);
            Controls.Add(txtCuentaID);
            Controls.Add(btnRealizarTransaccion);
            Controls.Add(btnConsultarSaldo);
            Name = "FrmPlazoFijo";
            Text = "FrmPlazoFijo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConsultarSaldo;
        private Button btnRealizarTransaccion;
        private TextBox txtCuentaID;
        private Label lblSaldo;
        private TextBox txtMonto;
        private ComboBox cmbTipoTransaccion;
        private TextBox txtTasaInteres;
        private Button btnSolicitarPlazoFijo;
    }
}