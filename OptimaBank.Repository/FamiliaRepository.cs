using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;
using OptimaBank.SQLServerDataProvider.Composite.Interfaces;

namespace OptimaBank.Repository
{
    public class FamiliaRepository : RepositoryManager<Familia>, IFamiliaRepository
    {
        IFamiliaDbContext _context;
        public FamiliaRepository(IFamiliaDbContext context) : base(context)
        {
            this._context = context;
        }

        public IList<Familia> ListarFamilias()
        {
            return _context.GetAllFamilias();
        }
    }
}
