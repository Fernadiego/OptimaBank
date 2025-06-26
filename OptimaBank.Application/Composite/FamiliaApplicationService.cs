using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.ApplicationLogic.Composite
{
    public interface IFamiliaApplicationService<T>
    {
        IList<Familia> GetAllFamilias();
    }
    public class FamiliaApplicationService : IFamiliaApplicationService<Familia>
    {
        private readonly IFamiliaRepository _compositeRepository;

        public FamiliaApplicationService(IFamiliaRepository compositeRepository)
        {
            _compositeRepository = compositeRepository;
        }

        public IList<Familia> GetAllFamilias()
        {
            return _compositeRepository.ListarFamilias();
        }
    }
}
