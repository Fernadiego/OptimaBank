using OptimaBank.Domain;
using OptimaBank.Repository;

namespace OptimaBank.ApplicationLogic.Idiomas
{
    public interface IIdiomaAplicationService<T>
    {
        IList<T> TraerIdiomasDisponibles();
        Idioma ObtenerDefault();
        int ActualizarDefault(Idioma idioma);
        Idioma GetIdiomaById(int id);
        Idioma InsertIdioma(T idioma);
        Idioma UpdateIdioma(T idioma);
        void DeleteIdioma(int id);
    }
    public class IdiomaApplicationService : IIdiomaAplicationService<Idioma>
    {
        IRepositoryManager<Idioma> _idiomaRepositoryManager;

        public IdiomaApplicationService(IRepositoryManager<Idioma> idiomaRepositoryManager)
        {
            _idiomaRepositoryManager = idiomaRepositoryManager;
        }

        public IList<Idioma> TraerIdiomasDisponibles()
        {
            return _idiomaRepositoryManager.GetAll();
        }

        public Idioma GetIdiomaById(int id)
        {
            return _idiomaRepositoryManager.GetById(id);
        }

        public Idioma InsertIdioma(Idioma idioma)
        {
            return _idiomaRepositoryManager.Insert(idioma);
        }

        public Idioma UpdateIdioma(Idioma idioma)
        {
            return _idiomaRepositoryManager.Update(idioma);
        }

        public void DeleteIdioma(int id)
        {
            _idiomaRepositoryManager.Delete(id);
        }

        public Idioma ObtenerDefault()
        {
            return TraerIdiomasDisponibles()
                .Where(t => t.Is_Default)
                .FirstOrDefault();
        }

        public int ActualizarDefault(Idioma idioma)
        {
            var idiomas = TraerIdiomasDisponibles();
            foreach (var lang in idiomas)
            {
                if (lang.Is_Default && lang.Id != idioma.Id)
                {
                    lang.Is_Default = false;
                    _idiomaRepositoryManager.Update(lang);
                }
            }
            idioma.Is_Default = true;
            return _idiomaRepositoryManager.Update(idioma).Id;
        }
    }
}
