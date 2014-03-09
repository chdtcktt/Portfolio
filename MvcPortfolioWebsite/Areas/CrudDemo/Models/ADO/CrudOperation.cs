using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO
{
    public class CrudOperation
    {

        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection conn = DataLayer.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"CrudDemo_GetAllPersons";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;



                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        persons.Add(
                            new Person()
                            {
                                PersonId = Int32.Parse(reader["BusinessEntityId"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString()
                            });
                    }     

                    return persons;
                }
            }




        }
    }
}