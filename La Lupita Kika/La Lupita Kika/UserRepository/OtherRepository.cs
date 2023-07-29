using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.Models
{
    internal class OtherRepository
    {
        private readonly string connectionString;

        public OtherRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Other> GetAllOthers()
        {
            List<Other> othersList = new List<Other>();
            string query = "SELECT * FROM others";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int othersId = reader.GetInt32("Others_ID");
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");
                            string codebar = reader.GetString("CodeBar");

                            Other other = new Other(othersId, name, price, codebar);
                            othersList.Add(other);
                        }
                    }
                }
            }

            return othersList;
        }

        public Other GetOtherById(int othersId)
        {
            string query = "SELECT * FROM others WHERE Others_ID = @OthersId";
            Other other = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OthersId", othersId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");
                            string codebar = reader.GetString("CodeBar");

                            other = new Other(othersId, name, price, codebar);
                        }
                    }
                }
            }

            return other;
        }

        public Other FindByCodebar(string codebar)
        {
            string query = "SELECT * FROM others WHERE CodeBar = @Codebar";
            Other other = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codebar", codebar);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int othersId = reader.GetInt32("Others_ID");
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");

                            other = new Other(othersId, name, price, codebar);
                        }
                    }
                }
            }

            return other;
        }

        public void AddOther(Other other)
        {
            string query = "INSERT INTO others (Name, Price, CodeBar) VALUES (@Name, @Price, @Codebar)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", other.Name);
                    command.Parameters.AddWithValue("@Price", other.Price);
                    command.Parameters.AddWithValue("@Codebar", other.Codebar);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOther(Other other)
        {
            string query = "UPDATE others SET Name = @Name, Price = @Price, CodeBar = @Codebar WHERE Others_ID = @OthersId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", other.Name);
                    command.Parameters.AddWithValue("@Price", other.Price);
                    command.Parameters.AddWithValue("@Codebar", other.Codebar);
                    command.Parameters.AddWithValue("@OthersId", other.Others_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOther(int othersId)
        {
            string query = "DELETE FROM others WHERE Others_ID = @OthersId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OthersId", othersId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public Other FindByName(string name)
        {
            string query = "SELECT * FROM others WHERE Name = @Name";
            Other other = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int othersId = reader.GetInt32("Others_ID");
                            float price = reader.GetFloat("Price");
                            string codebar = reader.GetString("CodeBar");

                            other = new Other(othersId, name, price, codebar);
                        }
                    }
                }
            }

            return other;
        }
        public List<string> GetAllNames()
        {
            List<string> namesList = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name FROM others";
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = Convert.ToString(reader["Name"]);
                            namesList.Add(name);
                        }
                    }
                }
            }

            return namesList;
        }

        public void DeleteByCodebar(string codebar)
        {
            string query = "DELETE FROM others WHERE CodeBar = @Codebar";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codebar", codebar);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}