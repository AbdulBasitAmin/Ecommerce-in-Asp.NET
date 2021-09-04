using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication21.Model
{
    public class insert
    {
        private string cs = ConfigurationManager.ConnectionStrings["ecom"].ConnectionString;
        public string signup_admin(admin a)
        {
            string k;
            SqlConnection con = new SqlConnection(cs);

            try
            {
                SqlCommand cmd = new SqlCommand("spinsert_admin", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ad_email", SqlDbType.NVarChar, 50).Value = a.email;
                cmd.Parameters.Add("@ad_password", SqlDbType.NVarChar, 50).Value = a.password;
                cmd.Parameters.Add("@ad_phone", SqlDbType.NVarChar, 50).Value = a.phone;

                SqlParameter para = new SqlParameter();
                para.SqlDbType = SqlDbType.Int;
                para.Direction = ParameterDirection.Output;
                para.ParameterName = "@id";
                cmd.Parameters.Add(para);

                con.Open();
                cmd.ExecuteNonQuery();
                k = para.Value.ToString();

            }
            catch (Exception)
            {

                k = "-1";
            }
            finally
            {
                con.Close();

            }
            return k;
        }



    }
}