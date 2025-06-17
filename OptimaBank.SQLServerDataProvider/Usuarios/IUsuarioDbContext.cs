using OptimaBank.Domain;

namespace OptimaBank.SQLServerDataProvider.Interfaces
{
    public interface IUsuarioDbContext : IDbContext<Usuario>
    {
        bool GetUserByName(string NombreUsuario);
        Usuario GetUserByCredentials(string user, string password);
    }
}
