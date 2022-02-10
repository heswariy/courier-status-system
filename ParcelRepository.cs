using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ParcelRepository : IParcelRepository
    {
        public IConfiguration Configuration { get; }
        public string connectionString;

        public ParcelRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Parcel> GetAllParcels()
        {
            List<Parcel> parcels = new List<Parcel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectParcel]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Parcel parcel = new Parcel();

                        parcel.id = Convert.ToInt32(rdr["id"]);
                        parcel.trackingNum = rdr["trackingNum"].ToString();
                        parcel.parcelStatus = rdr["parcelStatus"].ToString();
                        parcel.senderName = rdr["senderName"].ToString();
                        parcel.senderEmail = rdr["senderEmail"].ToString();
                        parcel.senderAddressLine1 = rdr["senderAddressLine1"].ToString();
                        parcel.senderAddressLine2 = rdr["senderAddressLine2"].ToString();
                        parcel.senderPostcode = rdr["senderPostcode"].ToString();
                        parcel.senderCity = rdr["senderCity"].ToString();
                        parcel.senderState = rdr["senderState"].ToString();
                        parcel.senderContact = rdr["senderContact"].ToString();
                        parcel.senderAltContact = rdr["senderAltContact"].ToString();
                        parcel.recipientName = rdr["recipientName"].ToString();
                        parcel.recipientEmail = rdr["recipientEmail"].ToString();
                        parcel.recipientAddressLine1 = rdr["recipientAddressLine1"].ToString();
                        parcel.recipientAddressLine2 = rdr["recipientAddressLine2"].ToString();
                        parcel.recipientPostcode = rdr["recipientPostcode"].ToString();
                        parcel.recipientCity = rdr["recipientCity"].ToString();
                        parcel.recipientState = rdr["recipientState"].ToString();
                        parcel.recipientContact = rdr["recipientContact"].ToString();
                        parcel.recipientAltContact = rdr["recipientAltContact"].ToString();
                        parcels.Add(parcel);
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();                   
                    parcels = null;
                }
            }
            return parcels;
        }

        public Parcel GetParcelByTrackingNum(string trackingNum)
        {
            Parcel parcel = new Parcel();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[spSelectParcelByTrackingNum]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@trackingNum", trackingNum);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        parcel.id = Convert.ToInt32(rdr["id"]);
                        parcel.trackingNum = trackingNum;
                        parcel.parcelStatus = rdr["parcelStatus"].ToString();
                        parcel.senderName = rdr["senderName"].ToString();
                        parcel.senderEmail = rdr["senderEmail"].ToString();
                        parcel.senderAddressLine1 = rdr["senderAddressLine1"].ToString();
                        parcel.senderAddressLine2 = rdr["senderAddressLine2"].ToString();
                        parcel.senderPostcode = rdr["senderPostcode"].ToString();
                        parcel.senderCity = rdr["senderCity"].ToString();
                        parcel.senderState = rdr["senderState"].ToString();
                        parcel.senderContact = rdr["senderContact"].ToString();
                        parcel.senderAltContact = rdr["senderAltContact"].ToString();
                        parcel.recipientName = rdr["recipientName"].ToString();
                        parcel.recipientEmail = rdr["recipientEmail"].ToString();
                        parcel.recipientAddressLine1 = rdr["recipientAddressLine1"].ToString();
                        parcel.recipientAddressLine2 = rdr["recipientAddressLine2"].ToString();
                        parcel.recipientPostcode = rdr["recipientPostcode"].ToString();
                        parcel.recipientCity = rdr["recipientCity"].ToString();
                        parcel.recipientState = rdr["recipientState"].ToString();
                        parcel.recipientContact = rdr["recipientContact"].ToString();
                        parcel.recipientAltContact = rdr["recipientAltContact"].ToString();
                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                    parcel = null;
                }
            }
            return parcel;
        }
    }
}
