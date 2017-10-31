using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.DataAccess
{
    public class DbDataAccess
    {

        public static string ConnectionString { get; set; }



        public List<Dictionary<string, object>> ExecuteStoredProcedure(string procedureName, List<SPParam> parameters)
        {
            List<Dictionary<string, object>> retVal = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (DbCommand cmd = connection.CreateCommand())
                    {
                        SqlParameter par;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandText = procedureName;

                        for (int i = 0; i < parameters.Count; i++)
                        {
                            par = new SqlParameter();
                            par.ParameterName = parameters[i].Name;
                            //par.DbType = DbType.Int32;
                            par.Value = parameters[i].Value;
                            cmd.Parameters.Add(par);
                        }

                        connection.Open();
                        using (DbDataReader reader = cmd.ExecuteReader())
                        {
                            retVal = new List<Dictionary<string, object>>();

                            Dictionary<string, object> element;
                            while (reader.Read())
                            {
                                element = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    element.Add(reader.GetName(i), (reader.GetValue(i) != DBNull.Value) ? reader.GetValue(i) : null);
                                }
                                retVal.Add(element);
                            }
                        }

                    }

                }
                return retVal;
            }
            catch (Exception ex)
            {

                return null;

            }


        }
    }
}
