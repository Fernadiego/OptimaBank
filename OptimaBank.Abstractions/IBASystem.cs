
namespace OptimaBank.Abstractions
{
   public interface IBASystem<T>
   {
        IList<T> GetAll();
        T GetById(int Id);
        bool Exists(T entity);
        T Insert(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
