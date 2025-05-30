using OptimaBank.ApplicationLogic;
using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.Domain;
using OptimaBank.Services;
using OptimaBank.UI.Controllers;

namespace OptimaBank
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioController _usuarioController;
        public FrmLogin()
        {
                
        }

        public FrmLogin(UsuarioController usuarioController)
        {
            _usuarioController = usuarioController;
            InitializeComponent();
        }

        private void InicializarControles()
        {
            lblUser.Text = "Usuario:";//ResourcesFile.LabelUser;
            lblPass.Text = "Clave:"; //ResourcesFile.LabelPassword;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //var _passEncrypted = _encriptarAppService.Encriptar(txtPassword.Text);
                var _login = _usuarioController.Login(txtUsuario.Text, txtPassword.Text);

                FrmMain main = (FrmMain)this.MdiParent;
                main.ValidarFormulario();

                if (_login == LoginResult.ValidUser)
                {
                    main.EscribirConsola(ResourcesFile.LoginOK);
                    main.BackgroundImage = null;
                    main.CargarMenuSegunPermisos();
                    this.Visible = false;
                    MessageBox.Show("Ultimo ingreso DD/MM/YYYY", ResourcesFile.Bienvenido, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    //if usuario inabilitado continuar
                    main.EscribirConsola(ResourcesFile.LoginNOK);
                    MessageBox.Show(ResourcesFile.LoginNOK, ResourcesFile.Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
