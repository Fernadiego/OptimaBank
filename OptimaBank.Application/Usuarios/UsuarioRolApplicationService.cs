
using OptimaBank.Domain;
using OptimaBank.Repository;

namespace OptimaBank.ApplicationLogic.Usuarios
{
    public interface IUsuarioRolApplicationService<T>
    {
        void CrearUsuarioRol(T usuarioRol);
    }

    public class UsuarioRolApplicationService : IUsuarioRolApplicationService<UsuarioRol>
    {
        IRepositoryManager<UsuarioRol> _usuarioRolRepositoryManager;

        public UsuarioRolApplicationService(IRepositoryManager<UsuarioRol> usuarioRolRepositoryManager)
        {
            _usuarioRolRepositoryManager = usuarioRolRepositoryManager;
        }

        public void CrearUsuarioRol(UsuarioRol usuarioRol)
        {
            _usuarioRolRepositoryManager.Insert(usuarioRol);
        }
    }
}
