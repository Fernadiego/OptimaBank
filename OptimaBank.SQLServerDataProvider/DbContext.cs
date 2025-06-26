using OptimaBank.Domain;
using System.Data;
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

        public IList<T> GetAll()
        {
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

        public T Insert(T entity)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted }))
            {
                _acceso.Abrir();
                string tableName = typeof(T).Name;

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        .Where(p => p.CanWrite)
                                        .ToList();

                var insertFields = new List<string>();
                var parameterNames = new List<string>();
                var parameters = new List<SqlParameter>();
                string idField = "Id";

                foreach (var prop in properties)
                {
                    if (prop.Name != idField)
                    {
                        insertFields.Add(prop.Name);
                        parameterNames.Add($"@{prop.Name}");
                        parameters.Add(new SqlParameter($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value));
                    }
                }

                string insertQuery = $@"INSERT INTO {tableName} ({string.Join(", ", insertFields)}) 
                                          VALUES ({string.Join(", ", parameterNames)});
                                          SELECT SCOPE_IDENTITY();";


                using (var command = new SqlCommand(insertQuery, _acceso.connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    var newId = command.ExecuteScalar();

                    if (newId != null && newId != DBNull.Value)
                    {
                        var idProperty = properties.FirstOrDefault(p => p.Name == idField);
                        if (idProperty != null)
                        {
                            var idInt = Convert.ToInt32(newId);
                            if (idProperty.PropertyType == typeof(int))
                            {
                                idProperty.SetValue(entity, idInt);
                            }
                        }
                    }
                }

                _acceso.Cerrar();
                scope.Complete();

                return entity;
            }
        }

        public T Update(T entity)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
               new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _acceso.Abrir();
                string tableName = typeof(T).Name;

                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                          .Where(p => p.CanWrite)
                                          .ToList();

                var updateFields = new List<string>();
                var parameters = new List<SqlParameter>();
                string idField = "Id";

                foreach (var prop in properties)
                {
                    if (prop.Name != idField)
                        updateFields.Add($"{prop.Name} = @{prop.Name}");
                    parameters.Add(new SqlParameter($"@{prop.Name}", prop.GetValue(entity) ?? DBNull.Value));
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

        public void Delete(int id)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _acceso.Abrir();
                string tableName = typeof(T).Name;
                string idField = "Id";

                string deleteQuery = $"DELETE FROM {tableName} WHERE {idField} = @{idField}";

                using (var command = new SqlCommand(deleteQuery, _acceso.connection))
                {
                    command.Parameters.AddWithValue($"@{idField}", id);
                    command.ExecuteNonQuery();
                }

                _acceso.Cerrar();
                scope.Complete();
            }
        }
    }
}