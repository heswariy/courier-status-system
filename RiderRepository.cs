using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class RiderRepository : IRiderRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;

        public RiderRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];

        }

        public IEnumerable<Rider> GetAllRiders()
        {
            List<Rider> riders = new List<Rider>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectRider]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Rider rider = new Rider();
                        rider.riderId = Convert.ToInt32(rdr["riderId"]);
                        rider.riderName = rdr["riderName"].ToString();
                        rider.riderEmail = rdr["riderEmail"].ToString();
                        rider.riderContact = rdr["riderContact"].ToString();
                        rider.riderAddressLine1 = rdr["riderAddressLine1"].ToString();
                        rider.riderAddressLine2 = rdr["riderAddressLine2"].ToString();
                        rider.riderCity = rdr["riderCity"].ToString();
                        rider.riderPostcode = rdr["riderPostcode"].ToString();
                        rider.riderState = rdr["riderState"].ToString();
                        rider.riderUsername = rdr["riderUsername"].ToString();
                        rider.riderPassword = rdr["riderPassword"].ToString();
                        riders.Add(rider);

                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    riders = null;
                }
            }
            return riders;
        }

        public Rider AddRider(Rider rider)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spInsertIntoRider]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@riderName", rider.riderName);
                    cmd.Parameters.AddWithValue("@riderEmail", rider.riderEmail);
                    cmd.Parameters.AddWithValue("@riderContact", rider.riderContact);
                    cmd.Parameters.AddWithValue("@riderAddressLine1", rider.riderAddressLine1);
                    cmd.Parameters.AddWithValue("@riderAddressLine2", rider.riderAddressLine2);
                    cmd.Parameters.AddWithValue("@riderCity", rider.riderCity);
                    cmd.Parameters.AddWithValue("@riderPostcode", rider.riderPostcode);
                    cmd.Parameters.AddWithValue("@riderState", rider.riderState);
                    cmd.Parameters.AddWithValue("@riderUsername", rider.riderUsername);
                    cmd.Parameters.AddWithValue("@riderPassword", rider.riderPassword);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    rider = null;
                }

            }
            return rider;
        }

        public void DeleteRider(int? riderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spDeleteRider]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@riderId", riderId);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();

                }
            }
        }

        public Rider UpdateRider(Rider rider)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spUpdateRider]", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@riderId", rider.riderId);
                    cmd.Parameters.AddWithValue("@riderName", rider.riderName);
                    cmd.Parameters.AddWithValue("@riderEmail", rider.riderEmail);
                    cmd.Parameters.AddWithValue("@riderContact", rider.riderContact);
                    cmd.Parameters.AddWithValue("@riderAddressLine1", rider.riderAddressLine1);
                    cmd.Parameters.AddWithValue("@riderAddressLine2", rider.riderAddressLine2);
                    cmd.Parameters.AddWithValue("@riderCity", rider.riderCity);
                    cmd.Parameters.AddWithValue("@riderPostcode", rider.riderPostcode);
                    cmd.Parameters.AddWithValue("@riderState", rider.riderState);
                    cmd.Parameters.AddWithValue("@riderUsername", rider.riderUsername);
                    cmd.Parameters.AddWithValue("@riderPassword", rider.riderPassword);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    //_logger.LogError(ex, "Error at UpdateCustomer() :(");
                    rider = null;
                }
            }

            return rider;
        }

        public Rider GetRiderById(int riderId)
        {
            Rider rider = new Rider();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectRiderById]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@riderId", riderId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        rider.riderId = riderId;
                        rider.riderName = rdr["riderName"].ToString();
                        rider.riderEmail = rdr["riderEmail"].ToString();
                        rider.riderContact = rdr["riderContact"].ToString();
                        rider.riderAddressLine1 = rdr["riderAddressLine1"].ToString();
                        rider.riderAddressLine2 = rdr["riderAddressLine2"].ToString();
                        rider.riderCity = rdr["riderCity"].ToString();
                        rider.riderPostcode = rdr["riderPostcode"].ToString();
                        rider.riderState = rdr["riderState"].ToString();
                        rider.riderUsername = rdr["riderUsername"].ToString();
                        rider.riderPassword = rdr["riderPassword"].ToString();
                    }


                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    rider = null;
                }
            }
            return rider;
        }
                    
    }
}
