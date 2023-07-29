using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class CategoryRepository
    {
        private readonly string connectionString;

        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Category category)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO category (Name) VALUES (@Name)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", category.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT category_ID, Name FROM category";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int categoryId = Convert.ToInt32(reader["category_ID"]);
                    string name = Convert.ToString(reader["Name"]);
                    Category category = new Category(categoryId, name);
                    categories.Add(category);
                }
            }
            return categories;
        }

        public void Update(Category category)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE category SET Name = @Name WHERE category_ID = @CategoryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", category.Name);
                command.Parameters.AddWithValue("@CategoryID", category.CategoryID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int categoryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM category WHERE category_ID = @CategoryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryID", categoryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
