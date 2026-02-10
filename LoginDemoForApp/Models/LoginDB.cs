using Microsoft.Data.SqlClient;

namespace LoginDemoForApp.Models
{
    public class LoginDB
    {
        private readonly IConfiguration configuration;
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;


        public LoginDB(IConfiguration configuration)
        {
            this.configuration = configuration;
            conn = new SqlConnection(this.configuration.GetConnectionString("DefaultConnection"));
        }



        public int LoginUser(Login lg)
        {

            string query = "insert into Login values(@Email,@Password)";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Email", lg.Email);
            cmd.Parameters.AddWithValue("@Password", lg.Password);
            int res = cmd.ExecuteNonQuery();
            
            return res;
            conn.Close();
        }


    }
}
