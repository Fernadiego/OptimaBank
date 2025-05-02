
using OptimaBank.Domain;
using OptimaBank.Repository.Interfaces;

namespace OptimaBank.Repository
{
    public class PlazoFijoRepository : IPlazoFijoRepository
    {
        public float ObtenerSaldoPorId(int idCuenta)
        {
            // Simulación de consulta a base de datos
            return 1000.00f; // Retorna saldo ficticio
        }

        public bool ActualizarSaldo(int idCuenta, float monto)
        {
            // Simulación de actualización en base de datos
            return true; // Indica que la operación fue exitosa
        }

        public bool GuardarPlazoFijo(PlazoFijo plazoFijo) => true;
        public PlazoFijo ObtenerPlazoFijo(int idPlazoFijo) => new PlazoFijo();
        public bool ActualizarEstado(int idPlazoFijo, string nuevoEstado) => true;
    }
}
