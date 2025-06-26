
using OptimaBank.Domain;

namespace OptimaBank.Repository.Interfaces
{
    public interface IIdiomaRepository
    {
        Dictionary<string, string> GetLabelByLanguage(Idioma idioma);
    }
}
