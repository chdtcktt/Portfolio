using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO
{
    public class DataLayer
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["AWConnection"].ToString();
            }
        }

        /// <summary>
        /// this method returns an open connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

    }
}