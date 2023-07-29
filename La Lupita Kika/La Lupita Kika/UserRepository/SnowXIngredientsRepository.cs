using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class SnowXIngredientsRepository
    {
        private readonly string connectionString;

        public SnowXIngredientsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Snowxingredients snowXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO snowxingredients (ingredients_id, snow_id) VALUES (@IngredientsId, @SnowId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", snowXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@SnowId", snowXIngredients.Snow_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Snowxingredients> GetAll()
        {
            List<Snowxingredients> snowXIngredientsList = new List<Snowxingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowxIngredients_id, ingredients_id, snow_id FROM snowxingredients";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int snowXIngredientsId = Convert.ToInt32(reader["snowxIngredients_id"]);
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    int snowId = Convert.ToInt32(reader["snow_id"]);
                    Snowxingredients snowXIngredients = new Snowxingredients(snowXIngredientsId, ingredientsId, snowId);
                    snowXIngredientsList.Add(snowXIngredients);
                }
            }
            return snowXIngredientsList;
        }

        public void Update(Snowxingredients snowXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE snowxingredients SET ingredients_id = @IngredientsId, snow_id = @SnowId WHERE snowxIngredients_id = @SnowXIngredientsId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", snowXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@SnowId", snowXIngredients.Snow_id);
                command.Parameters.AddWithValue("@SnowXIngredientsId", snowXIngredients.SnowxIngredients_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int snowXIngredientsId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM snowxingredients WHERE snowxIngredients_id = @SnowXIngredientsId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SnowXIngredientsId", snowXIngredientsId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
