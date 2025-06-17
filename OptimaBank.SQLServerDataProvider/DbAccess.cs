using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using OptimaBank.SQLServerDataProvider.Helpers;
using OptimaBank.Services;

namespace OptimaBank.SQLServerDataProvider
{
    public class DbAccess<T>
    {
        public SqlConnection connection = new SqlConnection();

        public DbAccess()
        {
            
        }

        public void Abrir()
        {
            if (connection != null && connection.State == ConnectionState.Closed || connection == null)
            {

                //Server=localhost\MSSQLSERVER01;Database=master;Trusted_Connection=True;
                connection = new SqlConnection();
                //connection.ConnectionString = "Initial Catalog=OptimaBank; Data Source=.; Integrated Security=SSPI";
                connection.ConnectionString = "Initial Catalog=OptimaBank; Data Source=(localdb)\\LocalDB;Integrated Security=SSPI";
                connection.Open();
            }
        }

        public void Cerrar()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection = null;
                GC.Collect();
            }
        }

        public SqlCommand CrearComando(string SQL, CommandType Tipo,SqlParameter[] parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            comando.CommandType = Tipo;
            comando.CommandText = SQL;
            if (parametros != null)
            {
                comando.Parameters.AddRange(parametros);
            }

            return comando;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter P = new SqlParameter();
            P.ParameterName = nombre;
            P.SqlDbType = SqlDbType.Int;
            P.Value = valor;
            return P;
        }

        public SqlParameter CrearParametro(string nombre, float valor)
        {
            SqlParameter P = new SqlParameter();
            P.ParameterName = nombre;
            P.SqlDbType = SqlDbType.Float;
            P.Value = valor;
            return P;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter P = new SqlParameter();
            P.ParameterName = nombre;
            P.SqlDbType = SqlDbType.VarChar;
            P.Value = valor;
            return P;
        }

        public SqlParameter CrearParametro(string nombre, Guid valor)
        {
            SqlParameter P = new SqlParameter();
            P.ParameterName = nombre;
            P.SqlDbType = SqlDbType.UniqueIdentifier;
            P.Value = valor;
            return P;
        }

        private SqlCommand CrearComando(string SQL, CommandType tipo, List<SqlParameter> parametros = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SQL;
            cmd.CommandType = tipo;
            if (parametros != null)
            {
                foreach (var p in parametros)
                {
                    cmd.Parameters.Add(p);
                }
            }
            return cmd;
        }

        public int Escribir(string SQL, SqlParameter[] parametros)
        {
            int ret = 0;
            SqlCommand cmd = CrearComando(SQL, CommandType.Text, parametros);
            try
            {
                ret = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ret = -1;
            }

            return ret;
        }

        public DataTable Leer(string sql, CommandType tipo, SqlParameter[] parametros)
        {
            DataTable tabla = new DataTable();
            //SqlCommand cmd = CrearComando(SQL, tipo, parametros);
            //SqlDataAdapter adaptador = new SqlDataAdapter();

            //adaptador.SelectCommand = cmd;
            //adaptador.Fill(tabla);


            using (var command = new SqlCommand(sql))
            {
                command.CommandType = tipo;

                if (parametros != null && parametros.Length > 0)
                {
                    command.Parameters.AddRange(parametros);
                }

                using (var reader = command.ExecuteReader())
                {
                    tabla.Load(reader);
                }
            }

            return tabla;
        }

        public int LeerScalar(string SQL, CommandType tipo, SqlParameter[] parametros)
        {
            object ret;
            SqlCommand cmd = CrearComando(SQL, tipo, parametros);
            try
            {
                ret = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                ret = -1;
            }

            return int.Parse(ret.ToString());
        }

        public IList<T> ExecuteSP(string SQL, CommandType Tipo, SqlParameter[] Parametros)
        {
            IList<T> lista = new List<T>();
            DataTable tabla = new DataTable();
            SqlCommand cmd = CrearComando(SQL, CommandType.StoredProcedure, Parametros);
            SqlDataAdapter adaptador = new SqlDataAdapter();

            adaptador.SelectCommand = cmd;
            adaptador.Fill(tabla);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(Helper.GetItem<T>(row));
            }

            return lista;
        }

        private SqlCommand CrearProcedureCommand(string SQL, CommandType Tipo, T entity)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = connection;
            comando.CommandType = Tipo;
            comando.CommandText = SQL;

            PropertyInfo[] propiedades = ReflectionHelp<T>.GetPropertiesFromEntity(entity);

            foreach (PropertyInfo propiedad in propiedades)
            {
                if (propiedad.Name == "Id")
                    continue;

                Type tipo = ReflectionHelp<T>.GetTypeFromEntity(propiedad);

                SqlDbType sqlTipo = ReflectionHelp<T>.GetSqlDbTypeFromDbType(tipo);
                var valueOfProperty = ReflectionHelp<T>.GetValueFromEntity(propiedad, entity);

                SqlParameter P = new SqlParameter();
                P.ParameterName = $"@{propiedad.Name}";
                P.SqlDbType = sqlTipo;
                P.Value = valueOfProperty;

                comando.Parameters.Add(P);
            }
            return comando;
        }
        /// <summary>
        /// Ejecuta los stored procedures del tipo LISTAR()
        /// </summary>
        /// <returns></returns>
        public IList<T> CallProcedure()
        {
            IList<T> lista = new List<T>();
            DataTable tabla = new DataTable();

            SqlParameter[] parametros = new SqlParameter[1];
            SqlParameter param = new SqlParameter();
            param.ParameterName = $"@ENTIDAD";
            param.SqlDbType = SqlDbType.VarChar;
            param.Value = typeof(T).Name.ToUpper();
            parametros[0] = param;

            SqlCommand cmd = CrearComando("SP_LISTAR", CommandType.StoredProcedure, parametros);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            adaptador.Fill(tabla);

            foreach (DataRow row in tabla.Rows)
            {
                lista.Add(Helper.GetItem<T>(row));
            }

            return lista;
        }

        public DataTable CallProcedure(T entity, TypeOperation operation)
        {
            DataTable tabla = new DataTable();
            SqlCommand cmd = 
                CrearProcedureCommand($"SP_{typeof(T).Name.ToUpper()}_{Helper.GetSqlOperation(operation)}",
                                        CommandType.StoredProcedure, entity);

            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = cmd;
            adaptador.Fill(tabla);

            return tabla;
        }
    }
}
