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
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");
                            float cuantity = reader.GetFloat("cuantity");
                            string codebar = reader.GetString("CodeBar");

                            Other other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
                            othersList.Add(other);
                        }
                    }
                }
            }

            return othersList;
        }

        public List<Other> GetAllOthersFind(string productName = null)
        {
            List<Other> othersList = new List<Other>();
            string query = "SELECT * FROM others";

            // Si se proporciona el nombre del producto, agregamos el filtro a la consulta SQL
            if (!string.IsNullOrEmpty(productName))
            {
                query += " WHERE Name LIKE @ProductName";
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Si se proporciona el nombre del producto, agregamos el parámetro correspondiente
                    if (!string.IsNullOrEmpty(productName))
                    {
                        command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                    }

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int othersId = reader.GetInt32("Others_ID");
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");
                            float cuantity = reader.GetFloat("cuantity");
                            string codebar = reader.GetString("CodeBar");

                            Other other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
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
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            string name = reader.GetString("Name");
                            float price = reader.GetFloat("Price");
                            float cuantity = reader.GetFloat("cuantity");
                            string codebar = reader.GetString("CodeBar");

                            other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
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
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            int othersId = reader.GetInt32("Others_ID");
                            string name = reader.GetString("Name");
                            float cuantity = reader.GetFloat("cuantity");
                            float price = reader.GetFloat("Price");

                            other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
                        }
                    }
                }
            }

            return other;
        }

        public void AddOther(Other other)
        {
            string query = "INSERT INTO others (Name, Price, CodeBar, cuantity, subsidiary_ID) VALUES (@Name, @Price, @Codebar, @cuantity,@subsidiary_ID )";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", other.Name);
                    command.Parameters.AddWithValue("@Price", other.Price);
                    command.Parameters.AddWithValue("@Codebar", other.Codebar);
                    command.Parameters.AddWithValue("@cuantity", other.Cuantity);
                    command.Parameters.AddWithValue("@subsidiary_ID", other.Subsidiary_ID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateOther(Other other)
        {
            string query = "UPDATE others SET Name = @Name, Price = @Price, CodeBar = @Codebar, Cuantity=@Cuantity,Subsidiary_ID= @Subsidiary_ID  WHERE Others_ID = @OthersId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", other.Name);
                    command.Parameters.AddWithValue("@Price", other.Price);
                    command.Parameters.AddWithValue("@Codebar", other.Codebar);
                    command.Parameters.AddWithValue("@OthersId", other.Others_id);
                    command.Parameters.AddWithValue("@cuantity", other.Cuantity);
                    command.Parameters.AddWithValue("@subsidiary_ID", other.Subsidiary_ID);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateOtherplus(string name, float price, string codebar, float cuantity, int subsidiary_ID, string oldName)
        {
            string query = "UPDATE others SET Name = @Name, Price = @Price, CodeBar = @Codebar, Cuantity = @Cuantity WHERE subsidiary_ID = @subsidiary_ID AND Name = @OldName";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Codebar", codebar);
                    command.Parameters.AddWithValue("@subsidiary_ID", subsidiary_ID);
                    command.Parameters.AddWithValue("@Cuantity", cuantity);
                    command.Parameters.AddWithValue("@OldName", oldName);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCuantityByCodebarPlus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE others SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCuantityByCodebarMinus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE others SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
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
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            float price = reader.GetFloat("Price");
                            float cuantity = reader.GetFloat("cuantity");
                            string codebar = reader.GetString("CodeBar");

                            other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
                        }
                    }
                }
            }

            return other;
        }
        public List<Other> FindAllBySubsidiaryId(int subsidiaryId)
        {
            List<Other> otherList = new List<Other>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM others WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int othersId = reader.GetInt32("Others_ID");
                        int Subsidiary_ID = reader.GetInt32("subsidiary_ID");
                        string name = reader.GetString("Name");
                        float price = reader.GetFloat("Price");
                        float cuantity = reader.GetFloat("cuantity");
                        string codebar = reader.GetString("CodeBar");

                        Other other = new Other(othersId, name, price, codebar, cuantity, Subsidiary_ID);
                        otherList.Add(other);
                    }
                }
            }
            return otherList;
        }

        public List<Other> FindAllBySubsidiaryIdFind(int subsidiaryId, string productName = null)
        {
            List<Other> otherList = new List<Other>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM others WHERE subsidiary_ID = @SubsidiaryId";

                if (!string.IsNullOrEmpty(productName))
                {
                    query += " AND Name LIKE @ProductName";
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);

                if (!string.IsNullOrEmpty(productName))
                {
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                }

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int othersId = reader.GetInt32("Others_ID");
                        int Subsidiary_ID = reader.GetInt32("subsidiary_ID");
                        string name = reader.GetString("Name");
                        float price = reader.GetFloat("Price");
                        float cuantity = reader.GetFloat("cuantity");
                        string codebar = reader.GetString("CodeBar");

                        Other other = new Other(othersId, name, price, codebar, cuantity, Subsidiary_ID);
                        otherList.Add(other);
                    }
                }
            }
            return otherList;
        }


        public Other FindOtherByNameAndSubsidiary(string name, int subsidiaryId)
        {
            string query = "SELECT * FROM others WHERE Name = @Name AND Subsidiary_ID = @SubsidiaryId";
            Other other = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int othersId = reader.GetInt32("Others_ID");
                            int subsidiary_ID = reader.GetInt32("subsidiary_ID");
                            float price = reader.GetFloat("Price");
                            float cuantity = reader.GetFloat("cuantity");
                            string codebar = reader.GetString("CodeBar");

                            other = new Other(othersId, name, price, codebar, cuantity, subsidiary_ID);
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

        public List<string> GetAllNamesBySubsidiaryId(int subsidiaryId)
        {
            List<string> namesList = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name FROM others WHERE Subsidiary_ID = @SubsidiaryId";
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
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