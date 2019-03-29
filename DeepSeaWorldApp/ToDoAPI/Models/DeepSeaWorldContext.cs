using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAPI.Models
{
    public class DeepSeaWorldContext
    {
        public string ConnectionString { get; set; }

        public DeepSeaWorldContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<FAQ> GetFAQs()
        {
            List<FAQ> list = new List<FAQ>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from faq where FAQ_ID <=1000", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new FAQ()
                        {
                            FAQ_ID = Convert.ToInt32(reader["FAQ_ID"]),
                            FAQ_Questions = reader["FAQ_Question"].ToString(),
                            FAQ_Anwswere = reader["FAQ_Anwswere"].ToString()
                        });
                    }
                }
            }
            return list;
        }

    }
}
