using OptimaBank.Domain;
using OptimaBank.SQLServerDataProvider.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace OptimaBank.SQLServerDataProvider
{
    public class UsuarioDbContext : DbContext<Usuario>, IUsuarioDbContext
    {
        private readonly DbAccess<Usuario> accessDB = new DbAccess<Usuario>();
        public UsuarioDbContext() : base()
        {
        }

        public Usuario GetUserByCredentials(string user, string password)
        {
            IList<Usuario> lista = new List<Usuario>();
            try
            {
                accessDB.Abrir();
                SqlParameter userParams = accessDB.CrearParametro("@USUARIO", user);
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = userParams;

                lista = accessDB.ExecuteSP("SP_USUARIO_BY_CRED", CommandType.StoredProcedure, parametros);
                accessDB.Cerrar();
            }
            catch (Exception ex)
            {
                accessDB.Cerrar();
                throw;
            }

            return lista.FirstOrDefault();
        }
    }
}
