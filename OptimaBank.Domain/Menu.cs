
namespace OptimaBank.Domain
{
    public class Menu : Entity
    {
        public Menu()
        {
        }
        public Menu(string nombre, string descripcion)
        {
            NombreMenu = nombre;
            Descripcion = descripcion;
        }
        public string NombreMenu { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }

    }
}
