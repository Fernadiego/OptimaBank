using OptimaBank.Domain;
using OptimaBank.SQLServerDataProvider.Composite.Interfaces;
using System.Data.SqlClient;
using System.Transactions;

namespace OptimaBank.SQLServerDataProvider.Composite
{
    public class FamiliaDbContext : DbContext<Familia>, IFamiliaDbContext
    {
        private readonly DbAccess<Familia> accessDB = new DbAccess<Familia>();
        public FamiliaDbContext() : base()
        {
            
        }

        public IList<Familia> GetAllFamilias()
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                accessDB.Abrir();

                string query = @$"SELECT *
                                  FROM COMPOSITE_PERMISO
                                  WHERE Permiso IS NULL";

                var familias = new List<Familia>();

                using (var command = new SqlCommand(query, accessDB.connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Familia familia = new Familia(
                                reader["Nombre"].ToString(),
                                reader["Permiso"].ToString())
                            {
                                Id = (int)reader["Id"]
                            };

                            familias.Add(familia);
                        }
                    }
                }

                return familias;
            }
        }
    }
}
