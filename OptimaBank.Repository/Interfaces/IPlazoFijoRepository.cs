
using OptimaBank.Domain;

namespace OptimaBank.Repository.Interfaces
{
    public interface IPlazoFijoRepository
    {
        public float ObtenerSaldoPorId(int idCuenta);
        public bool ActualizarSaldo(int idCuenta, float monto);

        bool GuardarPlazoFijo(PlazoFijo plazoFijo);
        PlazoFijo ObtenerPlazoFijo(int idPlazoFijo);
        bool ActualizarEstado(int idPlazoFijo, string nuevoEstado);
    }
}
