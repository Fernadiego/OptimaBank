using OptimaBank.ApplicationLogic.Composite;
using OptimaBank.Domain;

namespace OptimaBank.UI.Controllers
{ 
    public class CompositeController
    {
        private readonly IFamiliaApplicationService<Familia> _familiaApplicationService;
        private readonly IPatenteApplicationService<Patente> _patenteApplicationService;
        public CompositeController(IFamiliaApplicationService<Familia> familiaApplicationService, IPatenteApplicationService<Patente> patenteApplicationService)
        {
            _familiaApplicationService = familiaApplicationService;
            _patenteApplicationService = patenteApplicationService;
        }

        public IList<Familia> ListarFamilias()
        {
            return _familiaApplicationService.GetAllFamilias();
        }

        public IList<Patente> ListarPatentes()
        {
            return _patenteApplicationService.GetAllPatentes();
        }
    }
}
