using OptimaBank.Services;
using OptimaBank.UI.Controllers;

namespace OptimaBank
{
    public partial class FrmMain : Form
    {
        private readonly UsuarioController _usuarioController;
        private readonly MenuController _menuController;

        //IApplicationManager<Usuario> _app;
        //IDataProtectorApp _data;
        //IApplicationManager<Componente> _patenteApp;
        //IApplicationManager<UsuarioPermiso> _usuPemiso;

        public FrmMain(UsuarioController usuarioController, MenuController menuController)
            //IApplicationManager<Usuario> app,
            //IApplicationManager<Componente> patenteApp,
            //IDataProtectorApp data, IApplicationManager<UsuarioPermiso> usuPemiso)
        {
            _usuarioController = usuarioController;
            _menuController = menuController;

            InitializeComponent();
            ValidarFormulario();
            //_app = app;
            //_patenteApp = patenteApp;
            //_data = data;
            //_usuPemiso = usuPemiso;
            //ValidarForm();
            PrepareMenuVer();
        }

        #region Eventos

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InicializarMenu();
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(_usuarioController);
            login.MdiParent = this;
            login.StartPosition = FormStartPosition.Manual;
            login.Location = new Point((Screen.PrimaryScreen.Bounds.Width - login.Width) / 2, 100);
            login.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingletonSession.GetInstance.Close();
            ValidarFormulario();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var menuText = menuItem.Text;

            switch (menuText)
            {
                case "Caja de Ahorro":
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR EN CA");
                    break;

                case "Cuenta":
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR CC");
                    break;

                default:
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR DF");
                    break;
            }

        }

        #endregion

        #region Propiedades

        private ToolStripLabel lblUsuario;
        private void InicializarMenu()
        {
            sesionToolStripMenuItem.Text = "Sesión"; //ResourcesFile.MenuSession;
            iniciarToolStripMenuItem.Text = "Iniciar"; //ResourcesFile.MenuInit;
            cerrarToolStripMenuItem.Text = "Cerrar"; //ResourcesFile.MenuClose;
        }

        public void CargarMenuSegunPerfil()
        {
            UserProfile Profile = SingletonSession.GetInstance.Perfil;

            var menu = _menuController.TraerMenu();
            var submenu = _menuController.TraerSubMenu();

            if (Profile == UserProfile.DEFAULT)
            {
                tssMensaje.Text = "No tiene permisos cargados.";
                return;
            }

            if (Profile == UserProfile.ADMINISTRADOR)
            {
                ToolStripMenuItem Menu = new ToolStripMenuItem("Administracion");

                ToolStripMenuItem subSubItem = new ToolStripMenuItem("Caja de Ahorro");
                subSubItem.Click += new EventHandler(Menu_Click);
                ToolStripMenuItem subSubItem2 = new ToolStripMenuItem("Cuenta Corriente");

                subSubItem2.Click += new EventHandler(Menu_Click);

                Menu.DropDownItems.Add(subSubItem);
                Menu.DropDownItems.Add(subSubItem2);

                menuStrip1.Items.Add(Menu);
                return;
            }
        }

        public void ValidarFormulario()
        {
            tssMensaje.Text = SingletonSession.GetInstance.IsLogged() ? string.Empty : ResourcesFile.NotLogger;
            PrepararMenuLogin();
        }

        public void EscribirConsola(string message)
        {
            tssMensaje.Text = message;
        }

        private void PrepararMenuLogin()
        {
            this.iniciarToolStripMenuItem.Enabled = !SingletonSession.GetInstance.IsLogged();
            this.cerrarToolStripMenuItem.Enabled = SingletonSession.GetInstance.IsLogged();
        }

        private void PrepareMenuVer()
        {
            //cuentasToolStripMenuItem.Enabled = false;

            //_login.Login(new Usuario("fer", "fer"));

            //var fer = _app.GetAllAsync();

            //var fer1 = _app.GetByIdAsync(1);

            ////NUEVA PATENTE
            //Componente Patente = new Patente("PATENTE-001", "MENU-ABM");

            //bool existe = _patenteApp.Exists(Patente);

            //if(!existe)
            //{
            //    var ENTIDAD = _patenteApp.SaveAs(Patente);
            //}

            //ToolStripMenuItem Menu = new ToolStripMenuItem("Administracion");

            //ToolStripMenuItem subSubItem = new ToolStripMenuItem("Caja de Ahorro");
            //subSubItem.Click += new EventHandler(Menu_Click);
            //ToolStripMenuItem subSubItem2 = new ToolStripMenuItem("Cuenta Corriente");

            //subSubItem2.Click += new EventHandler(Menu_Click);

            //Menu.DropDownItems.Add(subSubItem);
            //Menu.DropDownItems.Add(subSubItem2);

            //menuStrip1.Items.Add(Menu);

            //var fer = _data.Proteger("Palabras mas o menos");


            //var permiso = _usuPemiso.GetAllAsync();
        }

        #endregion
    }
}