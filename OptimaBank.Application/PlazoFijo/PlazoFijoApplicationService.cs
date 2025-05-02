using OptimaBank.ApplicationLogic.Interfaces;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.ApplicationLogic.PlazoFijo
{
    public class PlazoFijoApplicationService: IPlazoFijoApplicationService
    {
        private IPlazoFijoRepository _pfijoRepository;

        public PlazoFijoApplicationService(IPlazoFijoRepository pfijoRepository)
        {
            _pfijoRepository = pfijoRepository;
        }

        public float ConsultarSaldo(int idCuenta)
        {
            return _pfijoRepository.ObtenerSaldoPorId(idCuenta);
        }

        public bool ProcesarTransaccion(int idCuenta, float monto, string tipo)
        {
            if (tipo == "Depósito")
            {
                return _pfijoRepository.ActualizarSaldo(idCuenta, monto);
            }
            else if (tipo == "Retiro")
            {
                float saldoActual = _pfijoRepository.ObtenerSaldoPorId(idCuenta);
                if (saldoActual >= monto)
                {
                    return _pfijoRepository.ActualizarSaldo(idCuenta, -monto);
                }
            }
            return false;
        }

        public bool ValidarSolicitudPlazoFijo(int idCuenta, float monto) => monto >= 1000;
        public float CalcularIntereses(int idPlazoFijo) => 5.0f;
        public bool ProcesarCancelacion(int idPlazoFijo) => _pfijoRepository.ActualizarEstado(idPlazoFijo, "Cancelado");

        public bool GestionarSolicitudPlazoFijo(Dictionary<string, object> datos)
        {
            return true;
        }
    }
}
