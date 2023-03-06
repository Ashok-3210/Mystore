 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Mystore.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<Clientinfo> ListClients = new List<Clientinfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\LT-ASHOKKUMAR-3\\SQLEXPRESS;Initial Catalog=Mystore;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = " SELECT * FROM clients";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader()) 
                        {
                            while (reader.Read())
                            {
                                Clientinfo clientinfo = new Clientinfo();
                                clientinfo.id =  ""+reader.GetInt32(0);
                                clientinfo.name = reader.GetString(1);
                                clientinfo.Email = reader.GetString(2);
                                clientinfo.phone = reader.GetString(3);
                                clientinfo.address = reader.GetString(4);
                                clientinfo.created_at = reader.GetDateTime(5).ToString();

                                ListClients.Add(clientinfo);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
            
        }
    }

    public class Clientinfo
    {
        public string id;
        public string name;
        public string Email;
        public string phone;
        public string address;
        public string created_at;
    }
}
