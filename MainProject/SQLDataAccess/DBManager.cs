using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace SQLDataAccess
{
    public class DBManager
    {
        public static string GetConnectionString()
        {
            return "Data Source=DESKTOP-KQ65BAV;Initial Catalog=Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static int SaveData<T>(string sql, T data)
        {
            using( IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static IEnumerable<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    return cnn.Query<T>(sql);
                }
                catch
                {
                    throw new Exception();
                }
  
            }
        }

        public static int DeleteData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql);
            }
        }

    }
}
