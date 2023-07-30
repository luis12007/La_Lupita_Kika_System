using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class MangoneadasRepository
    {
        private readonly string connectionString;

        public MangoneadasRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Mangoneadas mangoneada)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO mangoneadas (name, price, codebar, code, category_id) VALUES (@Name, @Price, @Codebar, @Code, @CategoryId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", mangoneada.Name);
                command.Parameters.AddWithValue("@Price", mangoneada.Price);
                command.Parameters.AddWithValue("@Codebar", mangoneada.Codebar);
                command.Parameters.AddWithValue("@Code", mangoneada.Code);
                command.Parameters.AddWithValue("@CategoryId", mangoneada.Category_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<string> GetAllNames()
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM mangoneadas";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    names.Add(name);
                }
            }
            return names;
        }
        public Mangoneadas FindByProductName(string productName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity FROM mangoneadas WHERE name = @ProductName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = 1;
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity);
                    return mangoneada;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }

        public List<Mangoneadas> GetAll()
        {
            List<Mangoneadas> mangoneadas = new List<Mangoneadas>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, category_id, cuantity FROM mangoneadas";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float cuantity = Convert.ToSingle(reader["Cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity);
                    mangoneadas.Add(mangoneada);
                }
            }
            return mangoneadas;
        }
        public void UpdateCuantityByCodebarplus(string codebar, int cuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE mangoneadas SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCuantityByCodebarmin(string codebar, int cuantity)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE mangoneadas SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Update(Mangoneadas mangoneada)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE mangoneadas SET name = @Name, price = @Price, codebar = @Codebar, code = @Code, category_id = @CategoryId WHERE mangoneadas_id = @MangoneadasId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", mangoneada.Name);
                command.Parameters.AddWithValue("@Price", mangoneada.Price);
                command.Parameters.AddWithValue("@Codebar", mangoneada.Codebar);
                command.Parameters.AddWithValue("@Code", mangoneada.Code);
                command.Parameters.AddWithValue("@CategoryId", mangoneada.Category_id);
                command.Parameters.AddWithValue("@MangoneadasId", mangoneada.Mangoneadas_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int mangoneadasId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM mangoneadas WHERE mangoneadas_id = @MangoneadasId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@MangoneadasId", mangoneadasId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Mangoneadas FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity FROM mangoneadas WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = 1;
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity);
                    return mangoneada;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
    }
}
