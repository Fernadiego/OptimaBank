
namespace OptimaBank.Abstractions
{
   public interface IBASystem<T>
   {
        IList<T> GetAllAsync();

        T GetByIdAsync(int Id);

        //T GetUserByCredentials(string user, string password);

        bool Exists(T entity);

        T SaveAs(T entity); 

        //void DeleteAsync(int id);
    }
}
