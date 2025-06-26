using OptimaBank.Domain;
using OptimaBank.Services;
using OptimaBank.Services.MultipleLanguage;
using OptimaBank.UI;
using OptimaBank.UI.Controllers;

namespace OptimaBank
{
    public partial class FrmLogin : Form, IIdiomaObserver
    {
        private readonly UsuarioController _usuarioController;
        private readonly IdiomaController _idiomaController;
        private readonly ITraductorService _traductorService;

        public Dictionary<string, string> Labels { get; set; }

        public FrmLogin()
        {
            TraducirFormulario(SingletonSession.GetInstance.Idioma);
        }

        public FrmLogin(UsuarioController usuarioController, IdiomaController idiomaController, ITraductorService traductorService)
        {
            _usuarioController = usuarioController;
            _idiomaController = idiomaController;
            _traductorService = traductorService;
            InitializeComponent();

            TraducirFormulario(SingletonSession.GetInstance.Idioma);
        }

        private void InicializarControles()
        {
            lblUser.Text = "Usuario:";
            lblPass.Text = "Clave:";
            txtUsuario.Focus();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SingletonSession.SuscribeObserver(this);  
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            SingletonSession.UsubscribeObserver(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var _login = _usuarioController.AutenticarUsuario(txtUsuario.Text, txtPassword.Text);

                FrmMain main = (FrmMain)this.MdiParent;
                main.ValidarFormulario();

                Labels = _traductorService.ReadLabelsStartsWith(SingletonSession.GetInstance.Idioma, "MSG_LOGIN");

                if (_login == LoginResult.ValidUser)
                {
                    main.EscribirConsola(ResourcesFile.LoginOK);
                    main.BackgroundImage = null;
                    main.CargarMenuSegunPerfil();
                    this.Visible = false;

                    var sesionDataNombre = SingletonSession.GetInstance.Usuario.NombreUsuario.ToUpper();
                    var sesionDataUltAcceso = SingletonSession.GetInstance.Usuario.UltimoAcceso;

                    MessageBox.Show(string.Format(Labels["MSG_LOGIN_BIENVENIDO"], sesionDataNombre, sesionDataUltAcceso),
                        Labels["MSG_LOGIN_LABEL_BIENVENIDO"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    main.EscribirConsola(ResourcesFile.LoginNOK);
                    MessageBox.Show(ResourcesFile.LoginNOK, ResourcesFile.Atencion, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = string.Empty;
                    txtPassword.Focus();
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

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            FrmRegistrarse registro = new FrmRegistrarse(_usuarioController);
            registro.MdiParent = (FrmMain)this.MdiParent;
            registro.StartPosition = FormStartPosition.Manual;
            registro.Location = new Point((Screen.PrimaryScreen.Bounds.Width - registro.Width) / 2, 100);
            registro.Show();
        }

        public void UpdatedLanguage(Idioma idioma)
        {
            TraducirFormulario(idioma);
        }

        private void TraducirFormulario(Idioma idioma = null)
        {
            var traducciones = _idiomaController.ObtenerTraducciones(idioma);
            Functions.InicializarHeader(traducciones, this);
            Functions.AplicarTraduction(this.Controls, traducciones);

            //InicializarControles();
            txtUsuario.Focus();
        }
    }
}
