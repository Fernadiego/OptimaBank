using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.ApplicationLogic
{
    public class ApplicationManager<T> : IApplicationManager<T>
    {
        IRepositoryManager<T> _repository;
        public ApplicationManager(IRepositoryManager<T> repository)
        {
            _repository = repository;
        }

        public bool Exists(T entity)
        {
            return _repository.Exists(entity);
        }

        public IList<T> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public T GetByIdAsync(int Id)
        {
            return _repository.GetByIdAsync(Id);
        }

        //public T GetUserByCredentials(string user, string password)
        //{
        //    return _repository.GetUserByCredentials(user, password);
        //}

        public T SaveAs(T entity)
        {
            return _repository.SaveAs(entity);
        }
    }
}
