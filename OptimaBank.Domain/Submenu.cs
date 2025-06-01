
namespace OptimaBank.Domain
{
    public class Submenu : Entity
    {
        public Submenu()
        {
        }
        public Submenu(string nombre, string descripcion)
        {
            NombreSubmenu = nombre;
            Descripcion = descripcion;
        }

        public int MenuId { get; set; }
        public string NombreSubmenu { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public string Icono { get; set; }
        public string Formulario { get; set; }
    }
}
