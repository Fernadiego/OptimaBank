using OptimaBank.Domain;
using OptimaBank.SQLServerDataProvider.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace OptimaBank.SQLServerDataProvider.Usuarios
{
    public class UsuarioDbContext : DbContext<Usuario>, IUsuarioDbContext
    {
        private readonly DbAccess<Usuario> accessDB = new DbAccess<Usuario>();
        public UsuarioDbContext() : base()
        {
        }

        public bool GetUserByName(string NombreUsuario)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
            {
                accessDB.Abrir();

                string query = $"SELECT COUNT(1) FROM USUARIO WHERE NombreUsuario = @NombreUsuario";

                using (var command = new SqlCommand(query, accessDB.connection))
                {
                    command.Parameters.Add(new SqlParameter("@NombreUsuario", NombreUsuario));
                    var result = command.ExecuteScalar();

                    accessDB.Cerrar();
                    scope.Complete();

                    return Convert.ToInt32(result) > 0;
                }
            }
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
