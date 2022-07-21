using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WpfHomeAppliance.DataModel
    {
    internal class User
        { 
            public static string Id
                {
                get; private set;
                }
            public string Username
                {
                get; set;
                }
            public string Password
                {
                get; set;
                }
            public static string LoggedUsername
                {
                get; private set;
                }
            public bool Login()
                {
            DataTable table = new DataTable();
            var query = $"SELECT UserId,Username FROM users WHERE Username =@username  AND Password=@password ";
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@username" , this.Username);
                command.Parameters.AddWithValue("@password" , this.Password);
                SqlDataReader sdr = command.ExecuteReader();
                table.Load(sdr);
               
                }
            
                if (table.Rows.Count > 0)
                    {
                    foreach (DataRow item in table.Rows)
                        {
                        LoggedUsername = item["Username"].ToString();
                        Id = item["UserId"].ToString();
                        return true;
                        }
                    return false;
                    }
                else
                    {
                    return false;
                    }
                }

            public bool Register()
                {
                var query = $"INSERT INTO users(Username,Password) VALUES(@username, @password)";  
            var operation = false;
            using (SqlConnection connenction = ClassCreator.CreateConnection().GetConnection())
                {
                connenction.Open();
                SqlCommand command = connenction.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("@username" , this.Username);
                command.Parameters.AddWithValue("@password" , this.Password);
                command.ExecuteNonQuery();
                operation = true;
                }
            return operation;
            }
            }
        }
 
