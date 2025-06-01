using OptimaBank.ApplicationLogic;
using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.Domain;
using OptimaBank.Services;

namespace OptimaBank.UI.Controllers
{
    public class UsuarioController
    {
        private IEncriptarApplicationService _encriptarAppService;
        private ILoginAppService<Usuario> _loginAppServer;

        public UsuarioController(IEncriptarApplicationService encriptarAppService, ILoginAppService<Usuario> loginAppServer)
        {
            _encriptarAppService = encriptarAppService;
            _loginAppServer = loginAppServer;
        }

        public LoginResult AutenticarUsuario(string username, string password) 
        {
            var _passEncrypted = _encriptarAppService.Encriptar(password);
            return _loginAppServer.Login(new Usuario(username, _passEncrypted));
        }
    }
}
