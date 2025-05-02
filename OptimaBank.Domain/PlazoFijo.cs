
namespace OptimaBank.Domain
{
    public class PlazoFijo
    {
        public int ID_Cuenta { get; set; }
        public float Monto { get; set; }
        public float Tasa_Interes { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }        
    }
}
