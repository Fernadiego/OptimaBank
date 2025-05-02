using OptimaBank.Domain;

namespace OptimaBank.Repository.Interfaces
{
    public interface IUsuarioRepository : IRepositoryManager<Usuario>
    {
        void Fernandito(string p1);
        Usuario GetUserByCredentials(string user, string password);
    }
}
