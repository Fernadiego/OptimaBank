
namespace OptimaBank.ApplicationLogic.Interfaces
{
    public interface IPlazoFijoApplicationService
    {
        public float ConsultarSaldo(int idCuenta);
        public bool ProcesarTransaccion(int idCuenta, float monto, string tipo);

        bool ValidarSolicitudPlazoFijo(int idCuenta, float monto);
        float CalcularIntereses(int idPlazoFijo);
        bool ProcesarCancelacion(int idPlazoFijo);

        bool GestionarSolicitudPlazoFijo(Dictionary<string, object> datos);
    }
}
