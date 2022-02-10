using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class LoginRepository : ILoginRepository
    {

        public IConfiguration Configuration { get; }
        public string connectionString;

        public LoginRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Login> GetAllLogins()
        {
            List<Login> logins = new List<Login>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectLogin]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Login login = new Login();                           
                        login.Username = rdr["Username"].ToString();
                        login.Password = rdr["Password"].ToString();         
                        logins.Add(login);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //_logger.LogError(ex, "Error at GetAllCustomers() :(");
                    logins = null;
                }
            }
            return logins;
        }

        public Login GetLoginByUsername(string Username)
        {
            Login login = new Login();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectLoginByUsername]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Username", Username);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        login.Username = Username;
                        login.Password = rdr["Password"].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //_logger.LogError(ex, "Error at GetCustomerById() :(");
                    login = null;
                }
            }
            return login;
        }

        public Login UpdateLogin(Login login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spUpdateLogin]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Username", login.Username);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    login = null;
                }
            }

            return login;
        }

        //public int LoginCheck(Login login)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {

        //        SqlCommand com = new SqlCommand("Sp_Login", con);
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.Parameters.AddWithValue("@Username", login.Username);
        //        com.Parameters.AddWithValue("@Password", login.Password);
        //        SqlParameter oblogin = new SqlParameter();
        //        oblogin.ParameterName = "@IsValid";
        //        oblogin.SqlDbType = SqlDbType.Bit;
        //        oblogin.Direction = ParameterDirection.Output;
        //        com.Parameters.Add(oblogin);
        //        int res = Convert.ToInt32(oblogin.Value);
        //        return res;                
        //    }
        //}
    }
}
