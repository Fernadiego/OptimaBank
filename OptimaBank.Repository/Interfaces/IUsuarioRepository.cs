using OptimaBank.Domain;

namespace OptimaBank.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryManager<Usuario>
    {
        bool GetUserByName(string NombreUsuario);
        Usuario GetCredentials(string usuario, string contrasena);
    }
}
