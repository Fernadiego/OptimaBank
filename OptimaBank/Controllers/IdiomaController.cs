using OptimaBank.ApplicationLogic.Idiomas;
using OptimaBank.Domain;
using OptimaBank.Services.MultipleLanguage;

namespace OptimaBank.UI.Controllers
{
    public class IdiomaController
    {
        private readonly IIdiomaAplicationService<Idioma> _idiomaAplicationService;
        private readonly IEtiquetaAplicationService<Etiqueta> _etiquetaAplicationService;
        private readonly ITraductorService _traductorService;

        public IdiomaController(IIdiomaAplicationService<Idioma> idiomaAplicationService, IEtiquetaAplicationService<Etiqueta> etiquetaAplicationService, ITraductorService traductorService)
        {
            _idiomaAplicationService = idiomaAplicationService;
            _traductorService = traductorService;
            _etiquetaAplicationService = etiquetaAplicationService;
        }

        public IList<Idioma> ObtenerIdiomas()
        {
            return _idiomaAplicationService.TraerIdiomasDisponibles();
        }

        public Dictionary<string, string> ObtenerTraducciones(Idioma idioma = null)
        {
            return _traductorService.ObtenerTraducciones(idioma);
        }

        public Idioma ObtenerIdiomaById(int Id)
        {
            return _idiomaAplicationService.GetIdiomaById(Id);
        }

        public Idioma ObtenerIdiomaDefault()
        {
            return _traductorService.ObtenerDefault();
        }

        public IList<Etiqueta> ObtenerEtiquetasByIdioma(Idioma idioma)
        {
            return _etiquetaAplicationService.TraerEtiquetasDisponibles();
        }

        public Idioma Insertar(Idioma idioma)
        {
            return _idiomaAplicationService.InsertIdioma(idioma);
        }

        public Idioma Actualizar(Idioma idioma)
        {
            return _idiomaAplicationService.UpdateIdioma(idioma);
        }

        public void Eliminar(int id)
        {
            _idiomaAplicationService.DeleteIdioma(id);
        }

        public int SetDefault(Idioma idioma)
        {
            return _idiomaAplicationService.ActualizarDefault(idioma);
        }
    }
}
