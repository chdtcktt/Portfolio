using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
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
                    cmd.CommandType = CommandType.StoredProcedure;
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
            using (SqlConnection conn = DataLayer.GetSqlConnection())
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
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@FirstName", firstname));
                    cmd.Parameters.Add(new SqlParameter("@LastName", lastname));

                    int result = cmd.ExecuteNonQuery();
                    return result;


                }
            }
        }

        /// <summary>
        /// gets a person record by id for the edit page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person GetPersonById(int id)
        {
            using (SqlConnection conn = DataLayer.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //USE [DB_9ACB28_CrudDemo]
                    //GO
                    ///****** Object:  StoredProcedure [dbo].[CrudDemo_GetPeronsonById]    Script Date: 3/15/2014 10:13:58 AM ******/
                    //SET ANSI_NULLS ON
                    //GO
                    //SET QUOTED_IDENTIFIER ON
                    //GO
                    //-- =============================================
                    //-- Author:		Chad Tackett
                    //-- Create date: 3/15/14
                    //-- Description:	Takes in an ID and gets one record from the DB
                    //-- =============================================
                    //ALTER PROCEDURE [dbo].[CrudDemo_GetPeronsonById] 
                    //    -- Add the parameters for the stored procedure here
                    //    @ID int
                    //AS
                    //BEGIN
                    //    select TOP 1 *
                    //    From [Custom.Person]
                    //    WHERE ID = @ID


                    //    -- Check for an error creating new person
                    //    IF(@@ERROR <> 0)
                    //    BEGIN ROLLBACK TRAN RAISERROR ('Error finding person',16,1) RETURN @@ERROR 
                    //    END
	
                    //    ELSE
                    //    Return 0
                    //END

                    cmd.CommandText = @"CrudDemo_GetPeronsonById";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID",id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Person person = new Person();


                    while (reader.Read())
                    {
                        person.PersonId = Int32.Parse(reader["ID"].ToString());
                        person.FirstName = reader["FirstName"].ToString();
                        person.LastName = reader["LastName"].ToString();
                    }

                    return person;
                }
            }
        }

        /// <summary>
        /// takes in a person object and updates the record on the db
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public int UpdatePersonRecord(Person person)
        {
            using (SqlConnection conn = DataLayer.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"CrudDemo_EditPersonRecord";
                    cmd.CommandType = CommandType.StoredProcedure;

                    if(string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
                    {
                        throw new ArgumentException("Input cannot be empty");
                    }

                    cmd.Parameters.Add(new SqlParameter("@ID", person.PersonId));
                    cmd.Parameters.Add(new SqlParameter("FirstName", person.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", person.LastName));

                    int result = cmd.ExecuteNonQuery();
                    return result;
                }

            }
        }
    }
}