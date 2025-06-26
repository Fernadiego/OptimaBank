using OptimaBank.Domain;

namespace OptimaBank.Services.MultipleLanguage
{
    public interface IIdiomaObserver
    {
        void UpdatedLanguage(Idioma idioma);
    }
}
