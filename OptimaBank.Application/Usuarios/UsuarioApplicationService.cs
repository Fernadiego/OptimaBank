using Microsoft.AspNetCore.DataProtection;
using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.Domain;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.ApplicationLogic.Usuarios
{
    public interface IUsuarioApplicationService<T>
    {
        bool ValidarExistencia(string NombreUsuario);
        Usuario CrearUsuario(T usuario);
    }

    public class UsuarioApplicationService : IUsuarioApplicationService<Usuario>
    {
        private readonly IRepositoryManager<Usuario> _usuarioRepositoryManager;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IDataProtectorApp _dataProtector;
        private readonly IEncriptarApplicationService _encriptarAppService;

        public UsuarioApplicationService(IRepositoryManager<Usuario> usuarioRepositoryManager, IUsuarioRepository usuarioRepository,
            IDataProtectorApp dataProtector, IEncriptarApplicationService encriptarAppService)
        {
            _usuarioRepositoryManager = usuarioRepositoryManager;
            _usuarioRepository = usuarioRepository;
            _dataProtector = dataProtector;
            _encriptarAppService = encriptarAppService;
        }

        public bool ValidarExistencia(string NombreUsuario)
        {
            return _usuarioRepository.GetUserByName(NombreUsuario);
        }

        public Usuario CrearUsuario(Usuario usuario)
        {
            string contrasena = _encriptarAppService.Encriptar(usuario.Contrasena);
            string email = _dataProtector.Proteger(usuario.Email);
            usuario.Contrasena = contrasena;
            usuario.Email = email;

            return _usuarioRepositoryManager.Insert(usuario);
        }
    }
}
