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

        public IList<T> GetAllAsync()
        {
            return _context.GetAllAsync();
        }

        public T GetByIdAsync(int id)
        {
            return _context.GetByIdAsync(id);
        }

        //public T GetUserByCredentials(string user, string password)
        //{
        //    return _context.GetUserByCredentials(user, password);
        //}

        public bool Exists(T entity)
        {
            return _context.Exists(entity);
        }

        public T SaveAs(T entity)
        {
            return _context.SaveAs(entity);
        }
    }
}
