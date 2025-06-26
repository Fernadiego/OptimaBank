using OptimaBank.Domain;
using OptimaBank.Repository;

namespace OptimaBank.ApplicationLogic.Bitacoras
{
    public interface IBitacoraApplicationService<T>
    {
        void Grabar(T suceso);
    }
    public class BitacoraApplicationService : IBitacoraApplicationService<Bitacora>
    {
        IRepositoryManager<Bitacora> _bitacoraRepositoryManager;
        public BitacoraApplicationService(IRepositoryManager<Bitacora> bitacoraRepositoryManager)
        {
           _bitacoraRepositoryManager = bitacoraRepositoryManager;
        }

        public void Grabar(Bitacora suceso)
        {
            _bitacoraRepositoryManager.Insert(suceso);
        }
    }
}
