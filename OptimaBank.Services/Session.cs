using OptimaBank.Abstractions;
using OptimaBank.Domain;

namespace OptimaBank.Services
{
    public class Session
    {
        private IUsuario _usuario;

        public IUsuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private DateTime _fechaInicio;

        public DateTime FechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        private UserProfile _perfil;

        public UserProfile Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }

        private List<Permiso> _patentes;

        public List<Permiso> Patentes
        {
            get { return _patentes; }
            set { _patentes = value; }
        }

        public void Init(IUsuario usuario, UserProfile perfil)
        {
            _usuario = usuario;
            _fechaInicio= DateTime.Now;
            _perfil = perfil;
        }

        public void Close()
        {
            _usuario = null;
        }

        public bool IsLogged()
        {
            return _usuario != null;
        }
    }
}
