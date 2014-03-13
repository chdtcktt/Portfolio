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

                    //SELECT ID, FirstName , LastName 
                    //FROM [Custom.Person] 


                    //END


                    cmd.CommandText = @"CrudDemo_GetAllPersons";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        persons.Add(
                            new Person()
                            {
                                PersonId = Int32.Parse(reader["ID"].ToString()),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString()
                            });
                    }


                    return persons;
                }
            }
        }
       

        
       /// <summary>
       /// takes in two strings from the view then calls a stored proc to insert a new entry into the DB
       /// </summary>
       /// <param name="firstname"></param>
       /// <param name="lastname"></param>
       public int CreateNewPerson(string firstname, string lastname)
        {
           using(SqlConnection conn = DataLayer.GetSqlConnection())
           {
               using (SqlCommand cmd = conn.CreateCommand())
               {

                    // USE [DB_9ACB28_CrudDemo]
                    //GO
                    ///****** Object:  StoredProcedure [dbo].[CrudDemo_InsertEntry]    Script Date: 3/12/2014 9:37:03 PM ******/
                    //SET ANSI_NULLS ON
                    //GO
                    //SET QUOTED_IDENTIFIER ON
                    //GO
                    //-- =============================================
                    //-- Author:		<Chad Tackett>
                    //-- Create date: <3/12/14>
                    //-- Description:	Create and entry in the database
                    //-- =============================================
                    //ALTER PROCEDURE [dbo].[CrudDemo_InsertEntry] 
                    //    -- Add the parameters for the stored procedure here
                    //    @LastName nvarchar(50), 
                    //    @FirstName nvarchar(50)
                    //AS
                    //BEGIN
                    //    INSERT INTO [Custom.Person]
                    //    (FirstName,LastName)
                    //    VALUES
                    //    (@FirstName,@LastName);

                    //    -- Check for an error creating new person
                    //    IF(@@ERROR <> 0)
                    //    BEGIN ROLLBACK TRAN RAISERROR ('Error creating
                    //    person entry',16,1) RETURN @@ERROR 
                    //    END
	
                    //    ELSE
                    //    Return 0
                    //END


                   cmd.CommandText = @"CrudDemo_InsertEntry";
                   cmd.CommandType = System.Data.CommandType.StoredProcedure;

                   cmd.Parameters.Add(new SqlParameter("@FirstName",firstname));
                   cmd.Parameters.Add(new SqlParameter("@LastName", lastname));

                   int result = cmd.ExecuteNonQuery();
                   return result;

                   
               }
           }
        }
    }
}