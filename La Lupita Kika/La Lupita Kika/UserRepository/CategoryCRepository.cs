using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class CategoryCRepository
    {
        private readonly string connectionString;

        public CategoryCRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(CategoryC categoryC)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO categoryc (Name) VALUES (@Name)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", categoryC.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<CategoryC> GetAll()
        {
            List<CategoryC> categoriesC = new List<CategoryC>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT categoryD_ID, Name FROM categoryc";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int categoryDId = Convert.ToInt32(reader["categoryD_ID"]);
                    string name = Convert.ToString(reader["Name"]);
                    CategoryC categoryC = new CategoryC(categoryDId, name);
                    categoriesC.Add(categoryC);
                }
            }
            return categoriesC;
        }

        public void Update(CategoryC categoryC)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE categoryc SET Name = @Name WHERE categoryD_ID = @CategoryDID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", categoryC.Name);
                command.Parameters.AddWithValue("@CategoryDID", categoryC.CategoryD_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string FindNameById(int categoryDId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name FROM categoryc WHERE categoryD_ID = @CategoryDID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryDID", categoryDId);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
                return "none"; // Si no se encuentra la categoría, devolver null
            }
        }

        public int FindIdByName(string categoryName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT categoryD_ID FROM categoryc WHERE Name = @CategoryName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryName", categoryName);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int categoryId))
                {
                    return categoryId;
                }
                return -1; // Devolver un valor negativo si no se encuentra la categoría
            }
        }


        public void Delete(int categoryDId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM categoryc WHERE categoryD_ID = @CategoryDID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryDID", categoryDId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
