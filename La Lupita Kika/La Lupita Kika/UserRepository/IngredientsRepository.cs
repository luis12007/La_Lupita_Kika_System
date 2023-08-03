using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class IngredientsRepository
    {
        private readonly string connectionString;

        public IngredientsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Ingredients ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO ingredients (name, code, price, unit, type, Subsidiary_ID) VALUES (@Name, @Code, @Price, @Unit, @Type, @Subsidiary_ID )";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Code", ingredient.Code);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@Subsidiary_ID", ingredient.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Ingredients> GetAll()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID FROM ingredients";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string code = Convert.ToString(reader["code"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float unit = Convert.ToSingle(reader["unit"]);
                    string type = Convert.ToString(reader["type"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID);
                    ingredients.Add(ingredient);
                }
            }
            return ingredients;
        }

        public void Update(Ingredients ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE ingredients SET name = @Name, code = @Code, price = @Price, unit = @Unit, type = @Type WHERE ingredients_id = @IngredientsId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Code", ingredient.Code);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@IngredientsId", ingredient.Ingredients_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ingredientsId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM ingredients WHERE ingredients_id = @IngredientsId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", ingredientsId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
