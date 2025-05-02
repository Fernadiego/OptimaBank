using System.Collections;
using System.Data;
using System.Reflection;

namespace OptimaBank.SQLServerDataProvider.Helpers
{
    public class ReflectionHelp<T>
    {
        public static PropertyInfo[] GetPropertiesFromEntity(T entity)
        {
            return entity.GetType().GetProperties();
        }

        public static Type GetTypeFromEntity(PropertyInfo property)
        {
            return Type.GetType(property.PropertyType.FullName);
        }

        public static object GetValueFromEntity(PropertyInfo property, T entity)
        {
            return entity.GetType().GetProperty(property.Name).GetValue(entity, null);
        }

        public static SqlDbType GetSqlDbTypeFromDbType(Type type)
        {
            Hashtable dbTypeTable;
            dbTypeTable = new Hashtable();
            dbTypeTable.Add(typeof(Boolean), SqlDbType.Bit);
            dbTypeTable.Add(typeof(Int16), SqlDbType.SmallInt);
            dbTypeTable.Add(typeof(Int32), SqlDbType.Int);
            dbTypeTable.Add(typeof(Int64), SqlDbType.BigInt);
            dbTypeTable.Add(typeof(Double), SqlDbType.Float);
            dbTypeTable.Add(typeof(Decimal), SqlDbType.Decimal);
            dbTypeTable.Add(typeof(String), SqlDbType.VarChar);
            dbTypeTable.Add(typeof(DateTime), SqlDbType.DateTime);
            dbTypeTable.Add(typeof(Byte[]), SqlDbType.VarBinary);
            dbTypeTable.Add(typeof(Guid), SqlDbType.UniqueIdentifier);

            SqlDbType dbtype;
            try
            {
                dbtype = (SqlDbType)dbTypeTable[type];
            }
            catch
            {
                dbtype = SqlDbType.Variant;
            }
            return dbtype;
        }
    }
}
