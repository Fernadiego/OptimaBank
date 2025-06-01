using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;
using OptimaBank.SQLServerDataProvider.Interfaces;

namespace OptimaBank.Repository
{
    public class UsuarioRepository : RepositoryManager<Usuario>, IUsuarioRepository
    {
        IUsuarioDbContext _context;

        public UsuarioRepository(IUsuarioDbContext context): base(context)
        {
            this._context = context;
        }

        public Usuario GetCredentials(string usuario, string contrasena)
        {
            return _context.GetUserByCredentials(usuario, contrasena);
        }
    }
}
