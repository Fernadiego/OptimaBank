using OptimaBank.Domain;
using OptimaBank.Services;
using System;
using System.CodeDom;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;

namespace OptimaBank.SQLServerDataProvider
{
    public class Helper
    {
        //    public static List<T> ConvertDataTable<T>(DataTable dt)
        //    {
        //        List<T> data = new List<T>();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            T item = GetItem<T>(row);
        //            data.Add(item);
        //        }
        //        return data;
        //    }

        public static string GetSqlOperation(TypeOperation op) => op switch
        {
            TypeOperation.ALTA => "INSERT",
            TypeOperation.BAJA => "DELETE",
            TypeOperation.MODIFICACION => "UPDATE",
            TypeOperation.LISTAR => "LISTAR",
            TypeOperation.EXISTE => "EXISTS",
            TypeOperation.POR_PARAMETRO => "BY",
            _ => "",
        };

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //    public static void SetParameters<T>(T entity, out SqlCommand com)
        //    {
        //        com = new SqlCommand();
        //        if (entity.ToString().Contains("Telefono"))
        //        {
        //            PropertyInfo[] propiedades = entity.GetType().GetProperties();

        //            foreach (PropertyInfo propiedad in propiedades)
        //            {
        //                Console.WriteLine(string.Format("Propiedad {0} >> {1}", propiedad.Name, propiedad.PropertyType));

        //                Type tipo = Type.GetType(propiedad.PropertyType.FullName);
        //                com.Parameters.AddWithValue($"@{propiedad.Name}", tipo);
        //            }
        //        }
        //    }

        //    internal static string[] GetParameterExists<T>(T entity)
        //    {
        //        string[] props = new string[2];

        //        SqlParameter[] dq = new SqlParameter[3];
        //        //if (typeof(T).Name == "Patente")
        //        //{
        //        //    return ((Patente)Convert.ChangeType(entity, typeof(T))).Nombre;
        //        //}

        //        if (entity.ToString().Contains("Telefono"))
        //        {
        //            Telefono cuenta = new Telefono() { Id = 1, TipoId = 1, Numero = "1234567890" };
        //            PropertyInfo[] propiedades = cuenta.GetType().GetProperties();

        //            foreach (PropertyInfo propiedad in propiedades)
        //            {
        //                //Console.WriteLine(string.Format("Propiedad {0} >> {1}", propiedad.Name, propiedad.PropertyType));

        //                Type tipo = Type.GetType(propiedad.PropertyType.FullName);
        //                SqlCommand com = new SqlCommand();
        //                com.Parameters.AddWithValue($"@{propiedad.Name}", tipo);
        //            }

        //            object saldo = cuenta.GetType().GetProperty("TipoId").GetValue(cuenta, null);

        //            var barProperty = entity.GetType().GetProperty("TipoId");
        //            string s = barProperty.GetValue(entity, null) as string;

        //            var barProperty1 = entity.GetType().GetProperty("Numero");
        //            string s1 = barProperty.GetValue(entity, null) as string;

        //            props[0] = s;
        //            props[1] = s1;
        //            return props;
        //        }

        //        if (entity.ToString().Equals("Patente"))
        //        {
        //            var barProperty = entity.GetType().GetProperty("Nombre");
        //            string s = barProperty.GetValue(entity, null) as string;

        //            var barProperty1 = entity.GetType().GetProperty("Nodo");
        //            string s1 = barProperty.GetValue(entity, null) as string;

        //            props[0] = s;
        //            props[1] = s1;
        //            return props;
        //        }

        //        return null;
        //    }


        //    public static SqlDbType GetDbType(Type giveType)
        //    {
        //        Tuple<Type, SqlDbType> DICCIONARIO;

        //        DICCIONARIO = new Tuple<Type, SqlDbType>(typeof(string), SqlDbType.Int);

        //        //switch (DICCIONARIO.Item1)
        //        //{
        //        //    case Type.GetType(""):
        //        //        return SqlDbType.Int;
        //        //    default:
        //        //        return SqlDbType.Int;
        //        //}

        //        return SqlDbType.Int;
        //    }

        //public static SqlDbType GetDbType<T>()
        //{
        //    return GetDbType(typeof(T));
        //}
    }
}
