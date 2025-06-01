using Microsoft.VisualBasic.ApplicationServices;
using OptimaBank.Abstractions;
using OptimaBank.Domain;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;
using OptimaBank.Services;

namespace OptimaBank.ApplicationLogic
{
    public interface ILoginAppService<T>
    {
        LoginResult Login(T Credenciales);
    }

    public class LoginAppService : ILoginAppService<Usuario>
    {
        IUsuarioRepository _usuarioRepository;
        IRepositoryManager<Usuario> _usuarioRepositoryManager;

        //IRepositoryManager<Permiso> _permiso;
        //IRepositoryManager<UsuarioPermiso> _usuPermiso;

        public LoginAppService(IUsuarioRepository usuarioRepository, IRepositoryManager<Usuario> usuarioRepositoryManager)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioRepositoryManager = usuarioRepositoryManager;
        }

        public LoginResult Login(Usuario Credenciales)
        {
            try
            {
                if (string.IsNullOrEmpty(Credenciales.NombreUsuario) || string.IsNullOrEmpty(Credenciales.Contrasena))
                    return LoginResult.UserOPassNull;

                if (SingletonSession.GetInstance.IsLogged())
                    throw new Exception("Ya hay una sesión iniciada");

                //var user = _usuarioRepositoryManager.GetById(Credenciales.Id);
                var user = _usuarioRepository.GetCredentials(Credenciales.NombreUsuario, Credenciales.Contrasena);

                if (user != null && user.NombreUsuario == Credenciales.NombreUsuario)
                {
                    if (user.Contrasena == Credenciales.Contrasena)
                    {
                        if (user.Activo)
                        {
                            //var perfil = AppHelper.GetEnumUserProfileByString(GetProfileUser(patentes));
                            SingletonSession.GetInstance.Init((IUsuario)user, UserProfile.ADMINISTRADOR);
                            UpdateValidatedUser(user);
                            return LoginResult.ValidUser;

                        }
                        else
                            return LoginResult.UserDisabled;
                    }
                    else
                    {
                        UpdateAttempts(user);
                        return LoginResult.InvalidUsername;
                    }
                }
                else
                    return LoginResult.InvalidUsername;
            }
            catch (Exception ex)
            {
                return LoginResult.InvalidPassword;
                //return _exceptionHandler.HandleException(ex);
            }
        }

        public void Logout()
        {
            SingletonSession.GetInstance.Close();
        }

        private void UpdateValidatedUser(Usuario user)
        {
            user.UltimoAcceso = DateTime.Now;
            user.CantidadIntentos = 0;
            _usuarioRepositoryManager.Update(user);
        }

        private void UpdateAttempts(Usuario user)
        {
            user.CantidadIntentos =+ 1;
            _usuarioRepositoryManager.Update(user);
        }

        private IList<Permiso> GetPermisos()
        {
            //IList<UsuarioPermiso> usuPermisos = _usuPermiso.GetAllAsync();
            //IList<Permiso> permiso =  _permiso.GetAllAsync();

            //var PatenteLogin = from a in usuPermisos
            //                   join p in permiso
            //                   on a.UsuarioId equals p.Id
            //                   where p.EsFamilia == false && p.Nombre == "LOGIN"
            //                   select new 
            //                   { 
            //                       Nombre = p.Nombre, 
            //                       EsFamilia = p.EsFamilia
            //                   };

            //var FamiliaUsuario = from a in usuPermisos
            //                   join p in permiso
            //                   on a.UsuarioId equals p.Id
            //                   where p.EsFamilia == true && p.Nombre != "LOGIN"
            //                   select new 
            //                   {
            //                       Nombre = p.Nombre,
            //                       EsFamilia = p.EsFamilia
            //                   };

            //List<Permiso> Patentes = new List<Permiso>();
            //foreach (var item in PatenteLogin)
            //    Patentes.Add(new Permiso() { Nombre = item.Nombre, EsFamilia = item.EsFamilia });

            //foreach (var item in FamiliaUsuario)
            //    Patentes.Add(new Permiso() { Nombre = item.Nombre, EsFamilia = item.EsFamilia });
            //return Patentes;
            return null;
        }

        private bool HasLoginPermissions(IList<Permiso> patentes)
        {
            return patentes.Where(login => login.Nombre == "LOGIN"
                        && login.EsFamilia == false) != null
                        ? true : false;
        }

        private string GetProfileUser(IList<Permiso> patentes)
        {
            List<Permiso> profile = patentes.Where(login => login.Nombre != "LOGIN"
                        && login.EsFamilia == true).ToList();
   
            return profile != null && profile.Count > 0 ? profile[0].Nombre : "DEFAULT";
        }
    }
}