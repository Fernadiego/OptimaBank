using OptimaBank.Domain;
using OptimaBank.SQLServerDataProvider.Composite.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OptimaBank.SQLServerDataProvider.Composite
{
    public class PatenteDbContext : DbContext<Patente>, IPatenteDbContext
    {
        private readonly DbAccess<Patente> accessDB = new DbAccess<Patente>();

        public PatenteDbContext() : base()
        {
            
        }

        public IList<Patente> GetAllPatentes()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                accessDB.Abrir();

                string query = @$"SELECT *
                                  FROM COMPOSITE_PERMISO
                                  WHERE Permiso IS NOT NULL";

                var patentes = new List<Patente>();

                using (var command = new SqlCommand(query, accessDB.connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patente patente = new Patente(
                                reader["Nombre"].ToString(),
                                reader["Permiso"].ToString())
                            {
                                Id = (int)reader["Id"]
                            };

                            patentes.Add(patente);
                        }
                    }
                }

                return patentes;
            }
        }
    }
}
