using OptimaBank.Domain;
using OptimaBank.Services;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace OptimaBank.SQLServerDataProvider
{
    public class DbContext<T> : IDbContext<T>
    {
        DbAccess<T> _acceso = new DbAccess<T>();

        public DbContext()
        {

        }

        //public T GetUserByCredentials(string user, string password)
        //{
        //    IList<T> lista = new List<T>();
        //    try 
        //    {
        //        acceso.Abrir();
        //        SqlParameter userParams = acceso.CrearParametro("@USUARIO", user);
        //        SqlParameter passParams = acceso.CrearParametro("@CONTRASENA", password);
        //        SqlParameter[] parametros = new SqlParameter[2];
        //        parametros[0] = userParams;
        //        parametros[1] = passParams;

        //        lista = acceso.ExecuteSP("SP_USUARIO_BY_CRED", CommandType.StoredProcedure, parametros);
        //        acceso.Cerrar();
        //    }
        //    catch (Exception ex)
        //    {
        //        acceso.Cerrar();
        //        throw;
        //    }

        //    return lista.FirstOrDefault();
        //}

        //public T GetUserByCredentials(string user, string password)
        //{
        //    if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
        //    {
        //        throw new ArgumentException("Usuario y contraseña son requeridos");
        //    }

        //    try
        //    {
        //        using (var scope = new TransactionScope(TransactionScopeOption.Required,
        //            new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
        //        {
        //            var parametros = new[]
        //            {
        //                new SqlParameter("@USUARIO", SqlDbType.VarChar, 50) { Value = user },
        //                new SqlParameter("@CONTRASENA", SqlDbType.VarChar, 80) { Value = password }
        //            };

        //            var resultado = acceso.ExecuteSP("SP_USUARIO_BY_CRED",
        //                CommandType.StoredProcedure,
        //                parametros)
        //                .FirstOrDefault();

        //            scope.Complete();
                    
        //            return Result<IList<T>>.Success(resultado);
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        //_logger.LogError($"Error de base de datos al validar credenciales: {ex.Message}");
        //        throw new DataAccessException("Error al validar credenciales", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError($"Error inesperado al validar credenciales: {ex.Message}");
        //        throw new DataAccessException("Error inesperado al validar credenciales", ex);
        //    }
        //}

        public IList<T> GetAll()
        {
            //IList<T> lista = new List<T>();
            //try
            //{
            //    _acceso.Abrir();
            //    lista = _acceso.CallProcedure();
            //    _acceso.Cerrar();
            //}
            //catch (Exception ex)
            //{
            //    _acceso.Cerrar();
            //    throw;
            //}

            //return lista;


            IList<T> result = new List<T>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
            {
                _acceso.Abrir();

                string tableName = typeof(T).Name;
                string selectQuery = $"SELECT * FROM {tableName}";

                using (var command = new SqlCommand(selectQuery, _acceso.connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(Helper.MapReaderToEntity<T>(reader));
                        }
                    }
                }

                _acceso.Cerrar();
                scope.Complete();
            }

            return result;
        }

        public T GetById(int id)
        {
            try
            {
                T result = default(T);
                using (var scope = new TransactionScope(TransactionScopeOption.Required,
                      new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
                {
                    _acceso.Abrir();

                    string tableName = typeof(T).Name;
                    string selectQuery = $"SELECT * FROM {tableName} WHERE Id = @Id";

                    using (var command = new SqlCommand(selectQuery, _acceso.connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Id", id));
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = Helper.MapReaderToEntity<T>(reader);
                            }
                        }
                    }
                    _acceso.Cerrar();
                    scope.Complete();
                }

                return result;
            }
            catch (Exception ex)
            {
                _acceso.Cerrar();
                throw;
            }
        }

        public bool Exists(T entity)
        {

            return false;

            //int lista = 0;
            //try
            //{
            //    acceso.Abrir();

            //    string[] Nombre = Helper.GetParameterExists(entity);

            //    SqlParameter parametro = acceso.CrearParametro("@NOMBRE", Nombre[0]);
            //    SqlParameter[] parametros = new SqlParameter[1];
            //    parametros[0] = parametro;

            //    lista = acceso.LeerScalar("SP_PATENTE_EXISTS", CommandType.StoredProcedure, parametros);
            //}
            //catch (Exception ex)
            //{
            //    acceso.Cerrar();
            //    throw;
            //}

            //return lista == 1 ? true : false;
        }

        public T SaveAs(T entity)
        {
            IList<T> lista = new List<T>();
            try
            {
                _acceso.Abrir();
                DataTable resp = _acceso.CallProcedure(entity, TypeOperation.ALTA);
                _acceso.Cerrar();
            }
            catch (Exception ex)
            {
                _acceso.Cerrar();
                throw;
            }

            return lista.FirstOrDefault();
        }

        public T Update(T entity)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
               new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _acceso.Abrir();
                string tableName = typeof(T).Name;

                //var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                          .Where(p => p.CanWrite)
                                          .ToList();

                var updateFields = new List<string>();
                var parameters = new List<SqlParameter>();
                string idField = "Id";

                foreach (var prop in properties)
                {
                    if (prop.Name != idField)
                    {
                        updateFields.Add($"{prop.Name} = @{prop.Name}");
                        parameters.Add(new SqlParameter($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value));
                    }
                }

                var idProperty = properties.FirstOrDefault(p => p.Name == idField);
                if (idProperty != null)
                {
                    parameters.Add(new SqlParameter($"@{idField}", idProperty.GetValue(entity)));
                }

                string updateQuery = $"UPDATE {tableName} SET {string.Join(", ", updateFields)} WHERE {idField} = @{idField}";

                using (var command = new SqlCommand(updateQuery, _acceso.connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    command.ExecuteNonQuery();
                }

                _acceso.Cerrar();
                scope.Complete();

                return entity;
            }
        }
    }
}