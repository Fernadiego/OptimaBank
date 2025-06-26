
namespace OptimaBank.Domain
{
    public class Bitacora : Entity
    {
        public string NombreUsuario { get; set; }

        public DateTime FechaSuceso { get; set; }

        public string Mensaje { get; set; }

        public string Modulo { get; set; }

        public Byte Tipo { get; set; }

        public Byte Categoria { get; set; }
    }
}
