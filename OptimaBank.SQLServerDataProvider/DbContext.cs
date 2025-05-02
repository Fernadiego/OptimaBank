using OptimaBank.Domain;
using OptimaBank.Services;
using System.Data;
using System.Data.SqlClient;

namespace OptimaBank.SQLServerDataProvider
{
    public class DbContext<T> : IDbContext<T>
    {
        DbAccess<T> acceso = new DbAccess<T>();

        public DbContext()
        {

        }

        public T GetUserByCredentials(string user, string password)
        {
            IList<T> lista = new List<T>();
            try 
            {
                acceso.Abrir();
                SqlParameter userParams = acceso.CrearParametro("@USER", user);
                SqlParameter passParams = acceso.CrearParametro("@PASS", password);
                SqlParameter[] parametros = new SqlParameter[2];
                parametros[0] = userParams;
                parametros[1] = passParams;

                lista = acceso.ExecuteSP("SP_USUARIO_BY_CRED", CommandType.StoredProcedure, parametros);
                acceso.Cerrar();
            }
            catch (Exception ex)
            {
                acceso.Cerrar();
                throw;
            }

            return lista.FirstOrDefault();
        }

        public IList<T> GetAllAsync()
        {
            IList<T> lista = new List<T>();
            try
            {
                acceso.Abrir();
                lista = acceso.CallProcedure();
                acceso.Cerrar();
            }
            catch (Exception ex)
            {
                acceso.Cerrar();
                throw;
            }

            return lista;
        }

        public T GetByIdAsync(int id)
        {
            IList<T> lista = new List<T>();
            try
            {
                acceso.Abrir();

                SqlParameter parametro = acceso.CrearParametro("@ID", id);
                SqlParameter[] parametros = new SqlParameter[1];
                parametros[0] = parametro;

                lista = acceso.ExecuteSP("SP_USUARIO_BY_ID", CommandType.StoredProcedure, parametros);
            }
            catch (Exception ex)
            {
                acceso.Cerrar();
                throw;
            }

            return lista.FirstOrDefault();
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
                acceso.Abrir();
                DataTable resp = acceso.CallProcedure(entity, TypeOperation.ALTA);
                acceso.Cerrar();
            }
            catch (Exception ex)
            {
                acceso.Cerrar();
                throw;
            }

            return lista.FirstOrDefault();
        }
    }
}