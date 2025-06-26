using OptimaBank.Domain;

namespace OptimaBank.Services.MultipleLanguage
{
    public interface ITraductorService
    {
        Dictionary<string, string> ObtenerTraducciones(Idioma idioma = null);
        Idioma ObtenerDefault();
        Dictionary<string, string> ReadLabelsStartsWith(Idioma idioma, string startLabel);
    }
}
