using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GreenTest.Components
{
    
    public class Newsletter
    {
        public static String ConnectionString = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public static bool InsertSubmit(string email, int idSource, string reason)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("SPG_NewsletterSubmit");

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@idSource", idSource);
            cmd.Parameters.AddWithValue("@reason", reason);

            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            bool value = Convert.ToBoolean(dt.Rows[0]["Result"]);

            conn.Close();
            conn.Dispose();
            

            return value;

        }

        public static DataTable GetSources()
        {
            DataTable subjects = new DataTable();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SPG_GetAllSources", con);
                    adapter.Fill(subjects);
                }
                catch (Exception ex)
                {
                    // Handle the error
                }

            }

            return subjects;
        }

    }
}