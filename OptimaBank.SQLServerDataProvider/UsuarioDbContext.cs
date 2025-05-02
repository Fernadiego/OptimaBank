using OptimaBank.Domain;
using OptimaBank.SQLServerDataProvider.Interfaces;

namespace OptimaBank.SQLServerDataProvider
{
    public class UsuarioDbContext : DbContext<Usuario>, IUsuarioDbContext
    {
        public UsuarioDbContext() : base()
        {

        }
    }
}
