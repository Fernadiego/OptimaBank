using OptimaBank.ApplicationLogic;
using OptimaBank.ApplicationLogic.Usuarios;
using OptimaBank.Domain;
using OptimaBank.Services;
using System.Text.RegularExpressions;

namespace OptimaBank.UI.Controllers
{
    public class UsuarioController
    {
        private readonly ILoginAppService<Usuario> _loginAppServer;
        private readonly IUsuarioApplicationService<Usuario> _usuarioApplicationService;
        private readonly IUsuarioRolApplicationService<UsuarioRol> _usuarioRolApplicationService;

        public UsuarioController(ILoginAppService<Usuario> loginAppServer,
                                IUsuarioApplicationService<Usuario> usuarioApplicationService, 
                                IUsuarioRolApplicationService<UsuarioRol> usuarioRolApplicationService)
        {
            _loginAppServer = loginAppServer;
            _usuarioApplicationService = usuarioApplicationService;
            _usuarioRolApplicationService = usuarioRolApplicationService;
        }

        public LoginResult AutenticarUsuario(string username, string password) 
        {
            return _loginAppServer.Login(new Usuario(username, password));
        }

        public bool Validar(string nombreUsuario, string contrasena, string repetir,string sexo, DateTime fechaDeNacimiento, string email)
        {
            Regex emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if(!emailRegex.IsMatch(email))
                return false;

            if (_usuarioApplicationService.ValidarExistencia(nombreUsuario))
            {
                MessageBox.Show("El nombre de usuario ya existe, por favor elija otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(sexo) || (sexo != "Masculino" && sexo != "Femenino" && sexo != "Otro"))
            {
                MessageBox.Show($"Por favor, seleccione el sexo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (fechaDeNacimiento > DateTime.Now)
            {
                    MessageBox.Show($"Fecha de Nacimiento incorrecta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
            }

            if (repetir != contrasena)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; 
        }

        public bool Nuevo(Usuario usuario)
        {
            var entidad = _usuarioApplicationService.CrearUsuario(usuario);
            //_usuarioRolApplicationService.CrearUsuarioRol(usuarioRol);

            MessageBox.Show("Usuario Creado Exitosamente.", "Alta de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        public IList<Usuario> Listar()
        {
            return _usuarioApplicationService.ListarUsuarios();
        }
    }
}
