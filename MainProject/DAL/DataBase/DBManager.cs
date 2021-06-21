using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace DAL.DataBase
{
    public class DBManager
    {

        private readonly string connectionString = "Data Source=mssql.fhict.local;Initial Catalog=dbi466933;User ID=dbi466933;Password=*********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //private readonly IConfiguration _configuration;

        //public DBManager(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public string GetConnectionString()
        {
            //return _configuration.GetConnectionString("ConnDb");
            return connectionString;
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public int UpdateData(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, parameters);
            }
        }

        public IEnumerable<T> LoadData<T>(string sql, DynamicParameters parameters)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {

                return cnn.Query<T>(sql, parameters);
            }
        }

        public IEnumerable<T> LoadAllData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {

                return cnn.Query<T>(sql);
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
