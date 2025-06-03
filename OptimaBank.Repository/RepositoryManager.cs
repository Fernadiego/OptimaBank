using OptimaBank.Abstractions;
using OptimaBank.Domain;

namespace OptimaBank.Repository
{
    public interface IRepositoryManager<T> : IBASystem<T>
    {
    }

    public class RepositoryManager<T> : IRepositoryManager<T>
    {
        private IDbContext<T> _context;

        public RepositoryManager(IDbContext<T> context)
        {
            _context = context;
        }

        public IList<T> GetAll()
        {
            return _context.GetAll();
        }

        public T GetById(int id)
        {
            return _context.GetById(id);
        }

        public bool Exists(T entity)
        {
            return _context.Exists(entity);
        }

        public T Insert(T entity)
        {
            return _context.Insert(entity);
        }

        public T Update(T entity)
        {
            return _context.Update(entity);
        }
    }
}
