
namespace OptimaBank.Domain
{
    public class Idioma : Entity
    {
        public Idioma()
        {
            
        }
        public Idioma(int id, string nombre, string descripcion, string imagen, bool is_Default)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
            Is_Default = is_Default;
        }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Is_Default { get; set; }

        public string Imagen { get; set; }
    }
}
