using OptimaBank.Domain;

namespace OptimaBank.SQLServerDataProvider.Interfaces
{
    public interface IUsuarioDbContext : IDbContext<Usuario>
    {
        Usuario GetUserByCredentials(string user, string password);
    }
}
