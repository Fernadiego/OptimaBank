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

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int Id)
        {
            return _repository.GetById(Id);
        }

        public T SaveAs(T entity)
        {
            return _repository.SaveAs(entity);
        }

        public T Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
