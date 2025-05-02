using OptimaBank.Abstractions;
using OptimaBank.Domain;
using OptimaBank.Repository;
using OptimaBank.Repository.Interfaces;
using OptimaBank.Services;
using Microsoft.VisualBasic.Logging;
using System.Collections.Generic;

namespace OptimaBank.ApplicationLogic
{
    public interface ILoginAppService<T>
    {
        LoginResult Login(T Credenciales);
    }

    public class LoginAppService : ILoginAppService<Usuario>
    {
        IUsuarioRepository _repository;
        IRepositoryManager<Permiso> _permiso;
        IRepositoryManager<UsuarioPermiso> _usuPermiso;

        public LoginAppService(IUsuarioRepository repository,
            IRepositoryManager<Permiso> permiso,
            IRepositoryManager<UsuarioPermiso> usuPermiso)
        {
            _repository = repository;
            _permiso = permiso;
            _usuPermiso = usuPermiso;
        }

        public LoginResult Login(Usuario Credenciales)
        {
            if (string.IsNullOrEmpty(Credenciales.User) || string.IsNullOrEmpty(Credenciales.Password)) 
                return LoginResult.UserOPassNull;

            if (SingletonSession.GetInstance.IsLogged())
                throw new Exception("Ya hay una sesión iniciada");

            var user = _repository.GetUserByCredentials(Credenciales.User, Credenciales.Password);

            if (user != null && user.User == Credenciales.User && user.Password == Credenciales.Password)
            {
                if (user.Habilitado)
                {
                    IList<Permiso> patentes = GetPermisos();
                    if (HasLoginPermissions(patentes))
                    {
                        var perfil = AppHelper.GetEnumUserProfileByString(GetProfileUser(patentes));
                        
                        SingletonSession.GetInstance.Init((IUsuario)user, perfil);
                        return LoginResult.ValidUser;
                    }
                    else
                        return LoginResult.UserWithgoutPermissions;
                }
                else
                    return LoginResult.UserDisabled;
            }
            else
                return LoginResult.InvalidUsername;

        }

        public void Logout()
        {
            SingletonSession.GetInstance.Close(); 
        }

        private IList<Permiso> GetPermisos()
        {
            IList<UsuarioPermiso> usuPermisos = _usuPermiso.GetAllAsync();
            IList<Permiso> permiso =  _permiso.GetAllAsync();

            var PatenteLogin = from a in usuPermisos
                               join p in permiso
                               on a.UsuarioId equals p.Id
                               where p.EsFamilia == false && p.Nombre == "LOGIN"
                               select new 
                               { 
                                   Nombre = p.Nombre, 
                                   EsFamilia = p.EsFamilia
                               };

            var FamiliaUsuario = from a in usuPermisos
                               join p in permiso
                               on a.UsuarioId equals p.Id
                               where p.EsFamilia == true && p.Nombre != "LOGIN"
                               select new 
                               {
                                   Nombre = p.Nombre,
                                   EsFamilia = p.EsFamilia
                               };

            List<Permiso> Patentes = new List<Permiso>();
            foreach (var item in PatenteLogin)
                Patentes.Add(new Permiso() { Nombre = item.Nombre, EsFamilia = item.EsFamilia });

            foreach (var item in FamiliaUsuario)
                Patentes.Add(new Permiso() { Nombre = item.Nombre, EsFamilia = item.EsFamilia });
            return Patentes;
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