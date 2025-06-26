using OptimaBank.Domain;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;
using OptimaBank.Services.MultipleLanguage;

namespace OptimaBank.ApplicationLogic.MultipleLanguage
{
    public class TraductorApplicationService : ITraductorService
    {
        private readonly IRepositoryManager<Idioma> _usuarioRepositoryManager;
        private readonly IIdiomaRepository _idiomaRepository;

        public TraductorApplicationService(IRepositoryManager<Idioma> usuarioRepositoryManager, IIdiomaRepository idiomaRepository)
        {
            _usuarioRepositoryManager = usuarioRepositoryManager;
            _idiomaRepository = idiomaRepository;
        }

        public Dictionary<string, string> ObtenerTraducciones(Idioma idioma = null)
        {
            if (idioma == null)
            {
                idioma = ObtenerDefault();
            }
            return BuscarTraducciones(idioma);
        }

        public Idioma ObtenerDefault()
        {
            return ObtenerIdiomas()
                .Where(t => t.Is_Default)
                .FirstOrDefault();
        }

        private IList<Idioma> ObtenerIdiomas()
        {
            return _usuarioRepositoryManager.GetAll();
        }

        private Dictionary<string, string> BuscarTraducciones(Idioma idioma)
        {
            return _idiomaRepository.GetLabelByLanguage(idioma);
        }

        public Dictionary<string, string> ReadLabelsStartsWith(Idioma idioma, string startLabel)
        {
            return BuscarTraducciones(idioma)
                .Where(kvp => kvp.Key.StartsWith(startLabel))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }
}
