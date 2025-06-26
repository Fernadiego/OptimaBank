using OptimaBank.ApplicationLogic.Bitacoras;
using OptimaBank.Domain;

namespace OptimaBank.UI.Controllers
{
    public class BitacoraController
    {
        private readonly IBitacoraApplicationService<Bitacora> _bitacoraApplicationService;
        public BitacoraController(IBitacoraApplicationService<Bitacora> bitacoraApplicationService)
        {
            _bitacoraApplicationService = bitacoraApplicationService;
        }

        public void RegistrarSuceso(Bitacora bitacora)
        {
            if (bitacora == null)
                throw new ArgumentNullException(nameof(bitacora), "El objeto Bitacora no puede ser nulo.");
            _bitacoraApplicationService.Grabar(bitacora);
        }
    }
}
