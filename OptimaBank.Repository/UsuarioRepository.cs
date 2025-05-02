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

        public void Fernandito(string p1)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUserByCredentials(string user, string password)
        {
            return _context.GetUserByCredentials(user, password);
        }
    }
}
