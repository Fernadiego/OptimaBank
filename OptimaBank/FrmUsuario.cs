using OptimaBank.Domain;
using OptimaBank.UI.Controllers;

namespace OptimaBank
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioController _usuarioController;
        private readonly CompositeController _compositeController;

        Usuario UsuarioSeleccionado;
        Usuario UsuarioCopiaTemporral;

        public FrmUsuario(UsuarioController usuarioController, CompositeController compositeController)
        {
            _usuarioController = usuarioController;
            _compositeController = compositeController;
            InitializeComponent();
            CargarCombos();
        }

        private void CargarCombos()
        {
            cmbUsuarios.Items.Add("Seleccionar");
            cmbUsuarios.DataSource = _usuarioController.Listar();
            cmbUsuarios.DisplayMember = "NombreUsuario";
            cmbUsuarios.ValueMember = "Id";

            cmbFamilias.Items.Add("Seleccionar");
            cmbFamilias.DataSource = _compositeController.ListarFamilias();
            cmbFamilias.DisplayMember = "Nombre";
            cmbFamilias.ValueMember = "Id";

            cmbPatentes.Items.Add("Seleccionar");
            cmbPatentes.DataSource = _compositeController.ListarPatentes();
            cmbPatentes.DisplayMember = "Nombre";
            cmbPatentes.ValueMember = "Id";
        }

        private void btnSelUsuario_Click(object sender, EventArgs e)
        {
            UsuarioSeleccionado = (Usuario)cmbUsuarios.SelectedItem;

            UsuarioCopiaTemporral = new Usuario
            {
                Id = UsuarioSeleccionado.Id,
                NombreUsuario = UsuarioSeleccionado.NombreUsuario,
                Contrasena = UsuarioSeleccionado.Contrasena,
                Activo = UsuarioSeleccionado.Activo,
                IdiomaId = UsuarioSeleccionado.IdiomaId,
                FechaCreacion = UsuarioSeleccionado.FechaCreacion,
                Email = UsuarioSeleccionado.Email
            };
        }
    }
}
