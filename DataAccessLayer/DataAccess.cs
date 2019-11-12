namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using DataAccessLayer.DataClasses;
    using System.Configuration;
    using System.Data;

    /// <summary>
    /// AUTHOR: Giancarlo Rhodes
    /// COMPANY: Onshore Outsourcing
    /// DESCRIPTION: 
    /// </summary>
    public class DataAccess
    {
        // connection string
        // private static string connectionString = @"Data Source=LAPTOP-1RTOL5OV\SQLEXPRESS;Initial Catalog=LetterLabel;Integrated Security=True";
        // LOVE THIS SITE https://www.connectionstrings.com/
        public static string conn = ConfigurationManager.ConnectionStrings["connSqlServerAuth"].ConnectionString;

        /// <summary>
        /// DESCRIPTION: 
        /// </summary>
        /// <param name="inUserId"></param>
        /// <returns></returns>
        public List<UserDO> GetUsers(int inUserId) {

            List<UserDO> _list = new List<UserDO>();

            try
            {

                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand cmd = new SqlCommand("SP_USERS_SELECT", connection))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("parmUserId", inUserId);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {

                                UserDO u = new UserDO();
                                u.UserId = (Int64)reader["UserId"];
                                u.LMSId = (Int64)reader["LMSId"];
                                u.Username = (string)reader["Username"];
                                u.FirstName = (string)reader["FirstName"];
                                u.LastName = (string)reader["LastName"];
                                u.Password = (string)reader["Password"];
                                u.Role = (string)reader["Role"];
                                u.Active = reader.GetBoolean(7) ? 1 : 0;  // active column index          // reader["Active"];
                                u.GroupId = (Int64)reader["GroupId"];
                                u.CourseId = (Int64)reader["CourseId"];
                                _list.Add(u);
                            }
                        }
                    }
                }


            }
            catch (Exception error)
            {
                this.LogError(error);
            }


            return _list;
        }

        public void LogError(Exception error)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public int CreateUser(UserDO u) {

            int _result = 0; // default in failure

            try
            {
                using (SqlConnection connectionSQL = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_USERS_INSERT", connectionSQL))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connectionSQL.Open();
                        command.Parameters.AddWithValue("parmLMSId", u.LMSId);
                        command.Parameters.AddWithValue("parmUsername", u.Username);
                        command.Parameters.AddWithValue("parmFirstName", u.FirstName);
                        command.Parameters.AddWithValue("parmLastName", u.LastName);
                        command.Parameters.AddWithValue("parmPassword", u.Password);
                        command.Parameters.AddWithValue("parmRole", u.Role);
                        command.Parameters.AddWithValue("parmActive", u.Active);
                        command.Parameters.AddWithValue("parmGroupId", u.GroupId);
                        command.Parameters.AddWithValue("parmCourseId", u.CourseId);
                        command.Parameters.AddWithValue("parmCreatedDate", u.CreatedDate);
                        command.Parameters.AddWithValue("parmCreatedUserId", u.CreatedUserId);
                        command.Parameters.AddWithValue("parmEmail", u.Email);
                        _result = (int)command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception error)
            {
                this.LogError(error);
            }
            finally
            {

            }
   
            return _result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inUserId"></param>
        /// <returns></returns>
        public int DeleteUser(int inUserId)
        {
            int _result = 0; // assume failure

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {

                    using (SqlCommand command = new SqlCommand("SP_USERS_DELTE", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("parmUserId", inUserId);
                        connection.Open();
                        _result = command.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception error)
            {

                this.LogError(error);
            }

            return _result;
        }


        public int UpdateUser(UserDO u)
        {
            int _result = 0;  // assume failture

            try
            {
                using (SqlConnection connection = new SqlConnection(conn))
                {
                    using (SqlCommand command = new SqlCommand("SP_USERS_UPDATE", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("parmUserId", u.UserId);
                        command.Parameters.AddWithValue("parmLMSId", u.LMSId);
                        command.Parameters.AddWithValue("parmUsername", u.Username);
                        command.Parameters.AddWithValue("parmFirstName", u.LastName);
                        command.Parameters.AddWithValue("parmLastName", u.LastName);
                        command.Parameters.AddWithValue("parmPassword", u.Password);
                        command.Parameters.AddWithValue("parmRole", u.Role);
                        command.Parameters.AddWithValue("parmActive", u.Active);
                        command.Parameters.AddWithValue("parmGroupId", u.GroupId);
                        command.Parameters.AddWithValue("parmCourseId", u.CourseId);

                        connection.Open();
                       _result = command.ExecuteNonQuery();
      
                    }
                }

            }
            catch (Exception error)
            {
                this.LogError(error);
            }

            return _result;
        }


    }

}
