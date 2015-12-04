using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PruvanAPI_13.Models
{
    public class DataManager
    {
        public string ConnectionString { get; set; }
        public DataManager(string ConnString)
        {
            this.ConnectionString = ConnString;
        }

        public DataTable DataReturnDataTable(string StoredProc, List<SqlParameter> Params)
        {
            DataTable returnDT = new DataTable();
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(StoredProc, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (Params.Count > 0)
                    {
                        foreach (SqlParameter s in Params)
                        {
                            command.Parameters.Add(s);
                        }
                    }
                    var dataReader = command.ExecuteReader();
                    returnDT.Load(dataReader);
                }
                con.Close();
                con.Dispose();
            }
            return returnDT;
        }

        public List<string> DataReturnListofItems(string StoredProc, int ColumnPosition, List<SqlParameter> Params)
        {
            List<string> returnList = new List<string>();
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(StoredProc, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (Params.Count > 0)
                    {
                        foreach (SqlParameter s in Params)
                        {
                            command.Parameters.Add(s);
                        }
                    }
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            do
                            {
                                returnList.Add(reader.GetString(ColumnPosition));
                            } while (reader.Read());
                        }
                    }
                }
                con.Close();
                con.Dispose();
            }
            return returnList;
        }

        public int ExecuteNonQuery(string StoredProc, List<SqlParameter> Params)
        {
            using (SqlConnection con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(StoredProc, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (Params.Count > 0)
                    {
                        foreach (SqlParameter s in Params)
                        {
                            command.Parameters.Add(s);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
                con.Close();
                con.Dispose();
            }
        }

        public string ReturnSerializedJOSNString(Object o)
        {
            try
            {
                return JsonConvert.SerializeObject(o);
            }
            catch { return null; }
        }
    }
}
