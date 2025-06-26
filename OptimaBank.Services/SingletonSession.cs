using OptimaBank.Abstractions;
using OptimaBank.Domain;
using OptimaBank.Services.MultipleLanguage;

namespace OptimaBank.Services
{
    public class SingletonSession
    {
        private static object _lock = new object();
        private static Session _session;
        private static IList<IIdiomaObserver> _observers = new List<IIdiomaObserver>();
        private readonly ITraductorService _traductorService;

        private SingletonSession(ITraductorService traductorService)
        {
            _traductorService = traductorService;
        }

        public static Session GetInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_session == null)
                        _session = new Session();

                    return _session;
                }
            }
        }

        public static void Close()
        {
            _session = null;
        }

        public static void SuscribeObserver(IIdiomaObserver observer)
        {
            if (observer == null) return;
            _observers.Add(observer);
        }

        public static void NotifyObservers(Idioma idioma)
        {
            if (idioma == null) return;
            foreach (var observer in _observers)
            {
                observer.UpdatedLanguage(idioma);
            }
        }

        public static void UsubscribeObserver(IIdiomaObserver observer)
        {
            if (observer == null) return;
                _observers.Remove(observer);
        }

        public static void ChangeLanguage(Idioma idioma)
        {
            if (_session == null) 
                return;
            _session.Idioma = idioma;
            NotifyObservers(idioma);
        }
    }
}