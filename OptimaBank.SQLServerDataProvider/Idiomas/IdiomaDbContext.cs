using OptimaBank.Domain;
using System.Data.SqlClient;
using System.Transactions;

namespace OptimaBank.SQLServerDataProvider.Idiomas
{
    public class IdiomaDbContext : DbContext<Idioma>, IIdiomaDbContext
    {
        private readonly DbAccess<Traduccion> accessDB = new DbAccess<Traduccion>();
        public IdiomaDbContext() : base()
        {
        }

        public Dictionary<string, string> GetLabelByLanguage(Idioma idioma)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
        new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                accessDB.Abrir();

                string query = @$"SELECT t.EtiquetaId, e.Nombre, t.Texto
                                  FROM TRADUCCION t
                                  INNER JOIN ETIQUETA e 
                                  ON t.EtiquetaId = e.Id
                                  WHERE t.IdiomaId = @IdiomaId";

                var traducciones = new Dictionary<string, string>();

                using (var command = new SqlCommand(query, accessDB.connection))
                {
                    command.Parameters.Add(new SqlParameter("@IdiomaId", idioma.Id));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombre = reader["Nombre"].ToString();
                            string traduccion = reader["Texto"].ToString();
                            traducciones.Add(nombre, traduccion);
                        }
                    }
                }

                return traducciones;
            }
        }
    }
}
