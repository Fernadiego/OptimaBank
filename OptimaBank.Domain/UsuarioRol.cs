
namespace OptimaBank.Domain
{
    public class UsuarioRol
    {
        public UsuarioRol(int usuarioId, int rolId)
        {
            _UsuarioId = usuarioId;
            _RolId = rolId; 
        }

        private int _UsuarioId;

        public int UsuarioId
        {
            get { return _UsuarioId; }
            set { _UsuarioId = value; }
        }

        private int _RolId;

        public int RolId
        {
            get { return _RolId; }
            set { _RolId = value; }
        }
    }
}
