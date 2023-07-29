using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class CandyRepository
    {
        private readonly string connectionString;

        public CandyRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Candy candy)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO candy (name, category_id, price, codebar) VALUES (@Name, @CategoryId, @Price, @Codebar)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", candy.Name);
                command.Parameters.AddWithValue("@CategoryId", candy.Category_id);
                command.Parameters.AddWithValue("@Price", candy.Price);
                command.Parameters.AddWithValue("@Codebar", candy.Codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Candy> GetAll()
        {
            List<Candy> candies = new List<Candy>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar FROM candy";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, name, categoryId, price, codebar);
                    candies.Add(candy);
                }
            }
            return candies;
        }

        public void Update(Candy candy)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE candy SET name = @Name, category_id = @CategoryId, price = @Price, codebar = @Codebar WHERE candy_id = @CandyId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", candy.Name);
                command.Parameters.AddWithValue("@CategoryId", candy.Category_id);
                command.Parameters.AddWithValue("@Price", candy.Price);
                command.Parameters.AddWithValue("@Codebar", candy.Codebar);
                command.Parameters.AddWithValue("@CandyId", candy.Candy_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int candyId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM candy WHERE candy_id = @CandyId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CandyId", candyId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void DeleteByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM candy WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Candy FindByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar FROM candy WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    string candyName = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, candyName, categoryId, price, codebar);
                    return candy;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public List<string> FindNamesByCategory(int categoryId)
        {
            List<string> namesList = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM candy WHERE category_id = @CategoryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["name"]);
                        namesList.Add(name);
                    }
                }
            }
            return namesList;
        }
        public Candy FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar FROM candy WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    Candy candy = new Candy(candyId, name, categoryId, price, codebar);
                    return candy;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }

    }
}
