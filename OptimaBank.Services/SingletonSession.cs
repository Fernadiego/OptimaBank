
namespace OptimaBank.Services
{
    public class SingletonSession
    {
        private static object _lock = new object();
        private static Session _session;

        private SingletonSession()
        {
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
    }
}