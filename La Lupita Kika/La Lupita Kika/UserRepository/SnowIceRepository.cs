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
                string query = "SELECT snowIce_id, name, price, codebar, cuantity FROM snowice";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity);
                    snowIceList.Add(snowIce);
                }
            }
            return snowIceList;
        }

        public void Update(SnowIce snowIce)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE snowice SET name = @Name, price = @Price, codebar = @Codebar WHERE snowIce_id = @SnowIceId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", snowIce.Name);
                command.Parameters.AddWithValue("@Price", snowIce.Price);
                command.Parameters.AddWithValue("@Codebar", snowIce.Codebar);
                command.Parameters.AddWithValue("@SnowIceId", snowIce.SnowIce_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int snowIceId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM snowice WHERE snowIce_id = @SnowIceId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SnowIceId", snowIceId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void IncrementCuantityByCodebarplus(string codebar,int cuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE snowice SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
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
                string query = "SELECT snowIce_id, name, price, codebar, cuantity FROM snowice WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    string productName = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, productName, price, codebar, cuantity);
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
        public SnowIce FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowIce_id, name, price, codebar, cuantity FROM snowice WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int snowIceId = Convert.ToInt32(reader["snowIce_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    SnowIce snowIce = new SnowIce(snowIceId, name, price, codebar, cuantity);
                    return snowIce;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
    }
}
