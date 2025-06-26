using OptimaBank.Domain;
using OptimaBank.Repository;

namespace OptimaBank.ApplicationLogic.Idiomas
{
    public interface IEtiquetaAplicationService<T>
    {
        IList<T> TraerEtiquetasDisponibles();
    }
    public class EtiquetaApplicationService : IEtiquetaAplicationService<Etiqueta>
    {
        IRepositoryManager<Etiqueta> _idiomaRepositoryManager;
        public EtiquetaApplicationService(IRepositoryManager<Etiqueta> idiomaRepositoryManager)
        {
            _idiomaRepositoryManager = idiomaRepositoryManager;
        }

        public IList<Etiqueta> TraerEtiquetasDisponibles()
        {
            return _idiomaRepositoryManager.GetAll();
        }
    }
}
