using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcPortfolioWebsite.Areas.CrudDemo.Models.ADO
{
    public class CrudOperation
    {
        /// <summary>
        /// this method calls a stored procedure that gets all values needed from the DB 
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection conn = DataLayer.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {


                    //USE [DB_9ACB28_CrudDemo]
                    //GO
                    ///****** Object:  StoredProcedure [dbo].[CrudDemo_GetAllPersons]    Script Date: 3/8/2014 10:15:49 PM ******/
                    //SET ANSI_NULLS ON
                    //GO
                    //SET QUOTED_IDENTIFIER ON
                    //GO
                    //-- =============================================
                    //-- Author:		Chad Tackett
                    //-- Create date:   3/8/14
                    //-- Description:	Gets all Persons from Database
                    //-- =============================================
                    //ALTER PROCEDURE [dbo].[CrudDemo_GetAllPersons] 

                    //AS
                    //BEGIN

                    //SELECT TOP 1000 BusinessEntityID, FirstName , LastName 
                    //FROM Person.Person 


                    //END
                    
                    
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


       public void CreateNewPerson()
        {

        }
    }
}