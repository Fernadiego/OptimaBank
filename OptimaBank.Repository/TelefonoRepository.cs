using OptimaBank.Abstractions;
using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.Repository
{
    public class TelefonoRepository<T> : RepositoryManager<Telefono>, ITelefonoRepository
    {
        IDbContext<Telefono> _context;

        public TelefonoRepository(IDbContext<Telefono> context) : base(context)
        {
            _context = context;
        }
    }
}
