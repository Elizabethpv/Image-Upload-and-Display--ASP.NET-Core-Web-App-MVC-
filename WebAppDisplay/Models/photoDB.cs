
using System.Data;
using System.Data.SqlClient;
namespace WebAppDisplay.Models
{
    public class PhotoDB
    {        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IT4CQOE\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");

        public string Fn_insert(Photo phcls)
        {
            try
            {              
                using (SqlCommand cmd = new SqlCommand("Sp_image", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@image", phcls.Image);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return "Inserted successfully";
                }
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return ex.Message; 
            }
        }
    }
}
