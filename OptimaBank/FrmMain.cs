using OptimaBank.Domain;
using OptimaBank.Services;
using OptimaBank.Services.MultipleLanguage;
using OptimaBank.UI;
using OptimaBank.UI.Controllers;
using System.Drawing.Design;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OptimaBank
{
    public partial class FrmMain : Form, IIdiomaObserver
    {
        private readonly UsuarioController _usuarioController;
        private readonly MenuController _menuController;
        private readonly IdiomaController _idiomaController;
        private readonly BitacoraController _bitacoraController;
        private readonly CompositeController _compositeController;
        private readonly ITraductorService _traductorService;

        //IApplicationManager<Usuario> _app;
        //IDataProtectorApp _data;
        //IApplicationManager<Componente> _patenteApp;
        //IApplicationManager<UsuarioPermiso> _usuPemiso;

        public FrmMain(UsuarioController usuarioController, MenuController menuController, IdiomaController idiomaController, BitacoraController bitacoraController, CompositeController compositeController, ITraductorService traductorService)
        //IApplicationManager<Usuario> app,
        //IApplicationManager<Componente> patenteApp,
        //IDataProtectorApp data, IApplicationManager<UsuarioPermiso> usuPemiso)
        {
            _usuarioController = usuarioController;
            _menuController = menuController;
            _idiomaController = idiomaController;
            _bitacoraController = bitacoraController;
            _traductorService = traductorService;
            _compositeController = compositeController;
            InitializeComponent();
            TraducirFormulario();
                        


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
            SingletonSession.SuscribeObserver(this);
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SingletonSession.UsubscribeObserver(this);
        }

        private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin(_usuarioController, _idiomaController, _traductorService);
            login.MdiParent = this;
            login.StartPosition = FormStartPosition.Manual;
            login.Location = new Point((Screen.PrimaryScreen.Bounds.Width - login.Width) / 2, 100);
            login.Show();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingletonSession.Close();
            ValidarFormulario();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var menuText = menuItem.Text;

            switch (menuText)
            {
                case "Idiomas":
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR EN CA");
                    FrmIdioma login = new FrmIdioma(_idiomaController, _bitacoraController);
                    login.MdiParent = this;
                    login.StartPosition = FormStartPosition.Manual;
                    login.Location = new Point((Screen.PrimaryScreen.Bounds.Width - login.Width) / 2, 100);
                    login.Show();
                    break;

                case "Etiquetas":
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR CC");
                    FrmEtiquetasTraducciones fer = new FrmEtiquetasTraducciones(_idiomaController);
                    fer.MdiParent = this;
                    fer.StartPosition = FormStartPosition.Manual;
                    fer.Location = new Point((Screen.PrimaryScreen.Bounds.Width - fer.Width) / 2, 100);
                    fer.Show();
                    break;

                case "Usuarios":
                    FrmUsuario formUsuario = new FrmUsuario(_usuarioController, _compositeController);
                    formUsuario.MdiParent = this;
                    formUsuario.StartPosition = FormStartPosition.Manual;
                    formUsuario.Location = new Point((Screen.PrimaryScreen.Bounds.Width - formUsuario.Width) / 2, 100);
                    formUsuario.Show();
                    break;

                case "PatentesFamilias":
                    FrmPatentesFamilias formPatentesFamilias = new FrmPatentesFamilias();
                    formPatentesFamilias.MdiParent = this;
                    formPatentesFamilias.StartPosition = FormStartPosition.Manual;
                    formPatentesFamilias.Location = new Point((Screen.PrimaryScreen.Bounds.Width - formPatentesFamilias.Width) / 2, 100);
                    formPatentesFamilias.Show();
                    break;

                default:
                    MessageBox.Show("HACIENDO COSAS DE ADMINISTRADOR DF");
                    break;
            }

        }

        #endregion

        #region Propiedades

        private void InicializarMenu(Dictionary<string, string> traducciones)
        {
            foreach (Control control in this.Controls)
            {
                if (control is MenuStrip menuStrip)
                {
                    foreach (ToolStripMenuItem menuItem in menuStrip.Items)
                    {
                        menuItem.Text = menuItem.Tag != null && traducciones.ContainsKey(menuItem.Tag.ToString())
                            ? menuItem.Text = traducciones[menuItem.Tag.ToString()]
                            : menuItem.Text = "MenuItem(E)";
                        foreach (ToolStripMenuItem subItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
                        {
                            subItem.Text = subItem.Tag != null && traducciones.ContainsKey(subItem.Tag.ToString())
                           ? subItem.Text = traducciones[subItem.Tag.ToString()]
                           : subItem.Text = "SubMenuItem(E)";
                        }
                    }
                }
            }
        }

        private void CargarMenuIdiomas(Idioma lenguaje)
        {
            if (lenguaje != null && string.IsNullOrEmpty(lenguaje.Imagen))
            {
                lenguaje = _idiomaController.ObtenerIdiomaById(lenguaje.Id);
            }

            var idiomas = _idiomaController.ObtenerIdiomas();
            var idiomaSeleccionado = lenguaje ?? _idiomaController.ObtenerIdiomaDefault();

            toolStripDropDownButton.DropDownItems.Clear();

            var imagenMap = new Dictionary<string, (byte[] normal, byte[] check)>
            {
                ["ARG"] = (UI.Properties.Recursos.ARG,        UI.Properties.Recursos.ARG_CHECK),
                ["BRA"] = (UI.Properties.Recursos.BRA,        UI.Properties.Recursos.BRA_CHECK),
                ["UK"] = (UI.Properties.Recursos.UK,          UI.Properties.Recursos.UK_CHECK),
                ["HK"] = (UI.Properties.Recursos.HK,          UI.Properties.Recursos.HK_CHECK)
            };
            
            foreach (var idioma in idiomas)
            {
                var item = new ToolStripMenuItem(idioma.Descripcion)
                {
                    Tag = idioma.Id
                };

                var esSeleccionado = idiomaSeleccionado.Imagen == idioma.Imagen;
                var imagenRecurso = imagenMap.GetValueOrDefault(idioma.Imagen, imagenMap["HK"]);
                var imagenFinal = esSeleccionado ? imagenRecurso.check : imagenRecurso.normal;

                item.Image = GetImagen(imagenFinal);
                item.Enabled = !esSeleccionado;

                var idiomaId = idioma.Id;
                item.Click += (s, e) => SeleccionarIdioma(idiomaId);
                toolStripDropDownButton.DropDownItems.Add(item);
            }
        }

        private Image GetImagen(byte[] imagen)
        {
            using (var ms = new MemoryStream(imagen))
            {
                return Image.FromStream(ms);
            }
        }

        private void InicializarFooter(Dictionary<string,string> traducciones)
        {
            traducciones.TryGetValue(LABEL.LABEL_NOT_LOGGER.ToString(), out string label);
            EscribirConsola(label);
        }

        private void SeleccionarIdioma(int idiomaId)
        {
            SingletonSession.ChangeLanguage(new Idioma() { Id = idiomaId });
        }

        public void CargarMenuSegunPerfil()
        {
            UserProfile Profile = SingletonSession.GetInstance.Perfil;

            var menu = _menuController.TraerMenu();
            var submenu = _menuController.TraerSubMenu();

            foreach (var item in menu)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem(item.Descripcion);
                menuItem.Name = item.Descripcion;
                foreach (var subItem in submenu)
                {
                    if (item.Id == subItem.MenuId)
                    {
                        ToolStripMenuItem subMenuItem = new ToolStripMenuItem(subItem.Descripcion);
                        subMenuItem.Name = subItem.Descripcion;
                        subMenuItem.Click += new EventHandler(Menu_Click);
                        menuItem.DropDownItems.Add(subMenuItem);
                    }
                }

                menuStrip1.Items.Add(menuItem);
            }   

            if (Profile == UserProfile.DEFAULT)
            {
                tssMensaje.Text = "No tiene permisos cargados.";
                return;
            }

            if (Profile == UserProfile.ADMINISTRADOR)
            {
                ToolStripMenuItem Menu = new ToolStripMenuItem("Administracion");

                ToolStripMenuItem subSubItem = new ToolStripMenuItem("Idiomas");
                subSubItem.Click += new EventHandler(Menu_Click);

                ToolStripMenuItem subSubItem2 = new ToolStripMenuItem("Etiquetas");
                subSubItem2.Click += new EventHandler(Menu_Click);

                ToolStripMenuItem subSubItem3 = new ToolStripMenuItem("Usuarios");
                subSubItem3.Click += new EventHandler(Menu_Click);

                ToolStripMenuItem subSubItem4 = new ToolStripMenuItem("PatentesFamilias");
                subSubItem4.Click += new EventHandler(Menu_Click);

                Menu.DropDownItems.Add(subSubItem);
                Menu.DropDownItems.Add(subSubItem2);
                Menu.DropDownItems.Add(subSubItem3);
                Menu.DropDownItems.Add(subSubItem4);

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

        public void UpdatedLanguage(Idioma idioma)
        {
            TraducirFormulario(idioma);
        }

        private void TraducirFormulario(Idioma idioma = null)
        {
            var traducciones = _idiomaController.ObtenerTraducciones(idioma);
            Functions.InicializarHeader(traducciones, this);
            InicializarMenu(traducciones);
            CargarMenuIdiomas(idioma);
            InicializarFooter(traducciones);
        }
        #endregion
    }
}