using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;
using OptimaBank.SQLServerDataProvider.Idiomas;

namespace OptimaBank.Repository
{
    public class IdiomaRepository : RepositoryManager<Idioma>, IIdiomaRepository
    {
        IIdiomaDbContext _context;
        public IdiomaRepository(IIdiomaDbContext context) : base(context)
        {
            this._context = context;
        }
        public Dictionary<string, string> GetLabelByLanguage(Idioma idioma)
        {
            return _context.GetLabelByLanguage(idioma);
        }
    }
}
