using JustRent.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JustRent.Controller
{
    class UserManager 
    {
        public static readonly UserManager instance = new UserManager();
        private User currentuser;
       

        private UserManager()
        {
            
        }
        
        public void signUp(User u)
        {

            User user = getUser(u.getUsername());

            if (user != null)
            {
                throw new Exception("taken username");
            }
            else
            {
                SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C6TL2JQK\SQLEXPRESS;Initial Catalog=JustRent;Integrated Security=True");
                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User] (Username,[Password],Gender,Birthdate,Country)VALUES(@Username,@Password,@Gender,@Birthdate,@Country)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Username", u.getUsername());
                    cmd.Parameters.AddWithValue("@Password", u.getPassword());
                    cmd.Parameters.AddWithValue("@Gender", u.getGender());
                    cmd.Parameters.AddWithValue("@Birthdate", u.getbirthdate());
                    cmd.Parameters.AddWithValue("@Country", u.getCountry());

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                }
                finally
                {
                    conn.Close();
                }


            }
        }
        public User SignIn(String username,String Password)  
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C6TL2JQK\SQLEXPRESS;Initial Catalog=JustRent;Integrated Security=True");

            
                conn.Open();
                String sql = string.Format("EXEC [SignIn] '%s','%s'", username, Password);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                {
                    currentuser = getUserFromDataReader(dr);
                }
                return currentuser;
              

        }
        public User getUser(String username)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-C6TL2JQK\SQLEXPRESS;Initial Catalog=JustRent;Integrated Security=True");
            conn.Open();
            String sql = string.Format("SELECT * FROM [User] WHERE Username = '%s'", username);
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return getUserFromDataReader(dr);
            }
            return null;
        }
        private User getUserFromDataReader(SqlDataReader dr)  
        {
            int id = dr.GetInt32(0);
            String u = dr.GetString(1).ToString();
            String pass = dr.GetString(2).ToString();
            int gender = dr.GetInt32(3);
            DateTime birthdate = dr.GetDateTime(4);
            String country = dr.GetString(5);
            return new User(id, u, pass, gender, birthdate, country);

        }
    }
}
