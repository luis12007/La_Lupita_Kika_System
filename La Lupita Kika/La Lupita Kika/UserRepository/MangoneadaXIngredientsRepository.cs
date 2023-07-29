using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class MangoneadaXIngredientsRepository
    {
        private readonly string connectionString;

        public MangoneadaXIngredientsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Mangoneadaxingredients mangoneadaXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO mangoneadaxingredients (ingredients_id, mangoneada_id) VALUES (@IngredientsId, @MangoneadaId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", mangoneadaXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@MangoneadaId", mangoneadaXIngredients.Mangoneada_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Mangoneadaxingredients> GetAll()
        {
            List<Mangoneadaxingredients> mangoneadaXIngredientsList = new List<Mangoneadaxingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneaxin_id, ingredients_id, mangoneada_id FROM mangoneadaxingredients";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int mangoneaxinId = Convert.ToInt32(reader["mangoneaxin_id"]);
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    int mangoneadaId = Convert.ToInt32(reader["mangoneada_id"]);
                    Mangoneadaxingredients mangoneadaXIngredients = new Mangoneadaxingredients(mangoneaxinId, ingredientsId, mangoneadaId);
                    mangoneadaXIngredientsList.Add(mangoneadaXIngredients);
                }
            }
            return mangoneadaXIngredientsList;
        }

        public void Update(Mangoneadaxingredients mangoneadaXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE mangoneadaxingredients SET ingredients_id = @IngredientsId, mangoneada_id = @MangoneadaId WHERE mangoneaxin_id = @MangoneaxinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", mangoneadaXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@MangoneadaId", mangoneadaXIngredients.Mangoneada_id);
                command.Parameters.AddWithValue("@MangoneaxinId", mangoneadaXIngredients.Mangoneaxin_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int mangoneaxinId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM mangoneadaxingredients WHERE mangoneaxin_id = @MangoneaxinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@MangoneaxinId", mangoneaxinId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
