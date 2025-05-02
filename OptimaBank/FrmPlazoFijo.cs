using OptimaBank.UI.Controllers;

namespace OptimaBank.UI
{
    public partial class FrmPlazoFijo : Form
    {
        private readonly PlazoFijoController _pfijoController;

        public FrmPlazoFijo(PlazoFijoController pfijoController)
        {
            InitializeComponent();
            _pfijoController = pfijoController;
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            int idCuenta = int.Parse(txtCuentaID.Text);
            float saldo = _pfijoController.ObtenerSaldo(idCuenta);
            lblSaldo.Text = $"Saldo: {saldo}";
        }

        private void btnRealizarTransaccion_Click(object sender, EventArgs e)
        {
            int idCuenta = int.Parse(txtCuentaID.Text);
            float monto = float.Parse(txtMonto.Text);
            string tipo = cmbTipoTransaccion.SelectedItem.ToString();

            if (_pfijoController.RealizarTransaccion(idCuenta, monto, tipo))
            {
                MessageBox.Show("Transacción realizada con éxito");
            }
            else
            {
                MessageBox.Show("Error en la transacción");
            }
        }

        private void btnSolicitarPlazoFijo_Click(object sender, EventArgs e)
        {
            // Obtener datos desde los campos del formulario
            Dictionary<string, object> datos = new Dictionary<string, object>
            {
                { "ID_Cuenta", int.Parse(txtCuentaID.Text) },
                { "Monto", float.Parse(txtMonto.Text) },
                { "Tasa_Interes", float.Parse(txtTasaInteres.Text) },
                { "Fecha_Inicio", DateTime.Now },
                { "Fecha_Vencimiento", DateTime.Now.AddMonths(6) } // Plazo fijo de 6 meses
            };

            // Llamar al método del Controller
            bool resultado = _pfijoController.CrearPlazoFijo(datos);

            // Mostrar el resultado en la UI
            MessageBox.Show(resultado ? "Plazo fijo creado exitosamente" : "Error al crear plazo fijo");
        }
    }
}
