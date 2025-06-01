using OptimaBank.Domain;

namespace OptimaBank.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryManager<Usuario>
    {
        Usuario GetCredentials(string usuario, string contrasena);
    }
}
