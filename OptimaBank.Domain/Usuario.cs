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
            User = user;
            Password = password;
        }

        public string User { get; set; }
        public string Password { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Habilitado { get; set; }
    }
}
