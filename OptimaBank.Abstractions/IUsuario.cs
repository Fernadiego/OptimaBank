
namespace OptimaBank.Abstractions
{
    public interface Entity
    {
        public int Id { get; set; }
    }

    public interface ILogin
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public interface IUsuario : Entity, ILogin
    {
        public DateTime FechaAlta { get; set; }
        public bool Habilitado { get; set; }
    }
}