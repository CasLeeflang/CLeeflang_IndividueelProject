using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DAL.DataBase
{
    public class DBManager
    {
        private readonly IConfiguration _configuration;

        public DBManager(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public DBManager()
        {
        }

        public string GetConnectionString()
        {
            //return _configuration.GetConnectionString("ConnDb");
            return "Data Source=DESKTOP-KQ65BAV;Initial Catalog=Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public IEnumerable<T> LoadData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    return cnn.Query<T>(sql, parameters);
                }
                catch
                {
                    throw new Exception();
                }

            }
        }

        public IEnumerable<T> LoadAllData<T>(string sql)
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

        public int DeleteData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, parameters);
            }
        }

    }
}
