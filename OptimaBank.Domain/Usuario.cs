using OptimaBank.Abstractions;

namespace OptimaBank.Domain
{
    public class Usuario : Entity, IUsuario
    {
        public Usuario()
        {
        }

        public Usuario(string user, string password)
        {
            NombreUsuario = user;
            Contrasena = password;
        }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public string Email { get; set; }

        public bool Activo { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public DateTime? UltimoAcceso { get; set; }

        public int CantidadIntentos { get; set; }

        public int IdiomaId { get; set; }
    }
}
