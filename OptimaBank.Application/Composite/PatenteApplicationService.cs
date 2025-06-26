
using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.ApplicationLogic.Composite
{
    public interface IPatenteApplicationService<T>
    {
        IList<Patente> GetAllPatentes();
    }

    public class PatenteApplicationService : IPatenteApplicationService<Patente>
    {
        private readonly IPatenteRepository _patenteRepository;

        public PatenteApplicationService(IPatenteRepository patenteRepository)
        {
            _patenteRepository = patenteRepository;
        }

        public IList<Patente> GetAllPatentes()
        {
            return _patenteRepository.ListarPatentes();
        }
    }
}
