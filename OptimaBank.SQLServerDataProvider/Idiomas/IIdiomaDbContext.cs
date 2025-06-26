
using OptimaBank.Domain;

namespace OptimaBank.SQLServerDataProvider.Idiomas
{
    public interface IIdiomaDbContext : IDbContext<Idioma>
    {
        Dictionary<string, string> GetLabelByLanguage(Idioma idioma);
    }
}
