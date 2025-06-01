
namespace OptimaBank.Abstractions
{
   public interface IBASystem<T>
   {
        IList<T> GetAll();
        T GetById(int Id);
        bool Exists(T entity);
        T SaveAs(T entity);
        T Update(T entity);
        //void DeleteAsync(int id);
    }
}
