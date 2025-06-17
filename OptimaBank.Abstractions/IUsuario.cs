
namespace OptimaBank.Abstractions
{
    public interface Entity
    {
        public int Id { get; set; }
    }

    public interface ILogin
    {
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }

    public interface IUsuario : Entity, ILogin
    {
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? UltimoAcceso { get; set; }
        public bool Activo { get; set; }
    }
}