using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.ApplicationLogic.PlazoFijo;

namespace OptimaBank.UI.Controllers
{
    public class PlazoFijoController
    {
        private IPlazoFijoApplicationService _pfijoService;

        public PlazoFijoController(IPlazoFijoApplicationService pfijoService)
        {
            _pfijoService = pfijoService;
        }

        public float ObtenerSaldo(int idCuenta)
        {
            return _pfijoService.ConsultarSaldo(idCuenta);
        }

        public bool RealizarTransaccion(int idCuenta, float monto, string tipo)
        {
            return _pfijoService.ProcesarTransaccion(idCuenta, monto, tipo);
        }

        public bool CrearPlazoFijo(Dictionary<string, object> datos)
        {
            return _pfijoService.GestionarSolicitudPlazoFijo(datos);
        }
    }
}
