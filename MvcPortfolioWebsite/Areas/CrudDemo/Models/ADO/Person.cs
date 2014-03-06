using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        //public void Load(SqlDataReader reader)
        //{
        //    PersonId = Int32.Parse(reader["Business"])
        //}
    }
}