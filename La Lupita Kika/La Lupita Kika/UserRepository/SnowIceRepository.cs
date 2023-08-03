using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class SnowIceRepository
    {
        private readonly string connectionString;

        public SnowIceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(SnowIce snowIce)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO snowice (name, price, codebar) VALUES (@Name, @Price, @Codebar)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", snowIce.Name);
                command.Parameters.AddWithValue("@Price", snowIce.Price);
                command.Parameters.AddWithValue("@Codebar", snowIce.Codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<SnowIce> GetAll()
        {
            List<SnowIce> snowIceList = new List<SnowIce>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity,subsidiary_ID FROM snowice";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity, subsidiary_ID);
                    snowIceList.Add(snowIce);
                }
            }
            return snowIceList;
        }

        public List<SnowIce> GetAllFind(string productName = null)
        {
            List<SnowIce> snowIceList = new List<SnowIce>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice";

                if (!string.IsNullOrEmpty(productName))
                {
                    query += " WHERE name LIKE @ProductName";
                }

                MySqlCommand command = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(productName))
                {
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                }

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                        int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                        string name = Convert.ToString(reader["name"]);
                        float price = Convert.ToSingle(reader["price"]);
                        string codebar = Convert.ToString(reader["codebar"]);
                        float cuantity = Convert.ToSingle(reader["cuantity"]);
                        SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity, subsidiary_ID);
                        snowIceList.Add(snowIce);
                    }
                }
            }
            return snowIceList;
        }


        public void Update(SnowIce snowIce)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE snowice SET name = @Name, price = @Price, codebar = @Codebar, Subsidiary_ID=@Subsidiary_ID WHERE snowIce_id = @SnowIceId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", snowIce.Name);
                command.Parameters.AddWithValue("@Price", snowIce.Price);
                command.Parameters.AddWithValue("@Codebar", snowIce.Codebar);
                command.Parameters.AddWithValue("@SnowIceId", snowIce.SnowIce_id);
                command.Parameters.AddWithValue("@Subsidiary_ID", snowIce.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Updateplus(string name, float price, string codebar, float cuantity, int subsidiaryId, string oldname)
{
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        string query = "UPDATE snowice SET name = @Name, price = @Price, codebar = @Codebar, cuantity = @Cuantity WHERE name = @Name_old AND Subsidiary_ID = @SubsidiaryId";
        MySqlCommand command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@Name", name);
        command.Parameters.AddWithValue("@Price", price);
        command.Parameters.AddWithValue("@Codebar", codebar);
        command.Parameters.AddWithValue("@Cuantity", cuantity);
        command.Parameters.AddWithValue("@Name_old", oldname);
        command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
        connection.Open();
        command.ExecuteNonQuery();
    }
}

        public void IncrementCuantityByCodebarPlus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE snowice SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void IncrementCuantityByCodebarMinus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE snowice SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void IncrementCuantityByCodebarmin(string codebar, int cuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE snowice SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM snowice WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public SnowIce FindByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    string productName = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, productName, price, codebar, cuantity, subsidiary_ID);
                    return snowIce;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public SnowIce FindSnowIceByNameAndSubsidiary(string name, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice WHERE name = @Name AND subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    string productName = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, productName, price, codebar, cuantity, subsidiary_ID);
                    return snowIce;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }

        public List<string> GetAllProductNames()
        {
            List<string> productNames = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM snowice";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    productNames.Add(name);
                }
            }
            return productNames;
        }

        public List<string> GetAllProductNamesBySubsidiaryId(int subsidiaryId)
        {
            List<string> productNames = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM snowice WHERE Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    productNames.Add(name);
                }
            }
            return productNames;
        }
        public SnowIce FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity, subsidiary_ID);
                    return snowIce;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public List<SnowIce> FindBySubsidiaryId(int subsidiaryId)
        {
            List<SnowIce> snowIceList = new List<SnowIce>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity, subsidiary_ID);
                    snowIceList.Add(snowIce);
                }
            }
            return snowIceList;
        }

        public List<SnowIce> FindBySubsidiaryIdfind(int subsidiaryId, string productName = null)
        {
            List<SnowIce> snowIceList = new List<SnowIce>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity, subsidiary_ID FROM snowice WHERE subsidiary_ID = @SubsidiaryId";

                if (!string.IsNullOrEmpty(productName))
                {
                    query += " AND name LIKE @ProductName";
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
                        int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                        int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                        string name = Convert.ToString(reader["name"]);
                        float price = Convert.ToSingle(reader["price"]);
                        float cuantity = Convert.ToSingle(reader["cuantity"]);
                        string codebar = Convert.ToString(reader["codebar"]);
                        SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity, subsidiary_ID);
                        snowIceList.Add(snowIce);
                    }
                }
            }
            return snowIceList;
        }


    }
}
