using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class PaletteXIngredientsRepository
    {
        private readonly string connectionString;

        public PaletteXIngredientsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Palettexingedients paletteXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO palettexingedients (ingredients_id, palette_id) VALUES (@IngredientsId, @PaletteId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", paletteXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@PaletteId", paletteXIngredients.Palette_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Palettexingedients> GetAll()
        {
            List<Palettexingedients> paletteXIngredientsList = new List<Palettexingedients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT palettexin_id, ingredients_id, palette_id FROM palettexingedients";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int palettexinId = Convert.ToInt32(reader["palettexin_id"]);
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    int paletteId = Convert.ToInt32(reader["palette_id"]);
                    Palettexingedients paletteXIngredients = new Palettexingedients(palettexinId, ingredientsId, paletteId);
                    paletteXIngredientsList.Add(paletteXIngredients);
                }
            }
            return paletteXIngredientsList;
        }

        public void Update(Palettexingedients paletteXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE palettexingedients SET ingredients_id = @IngredientsId, palette_id = @PaletteId WHERE palettexin_id = @PaletteXinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", paletteXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@PaletteId", paletteXIngredients.Palette_id);
                command.Parameters.AddWithValue("@PaletteXinId", paletteXIngredients.Palettexin_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int paletteXinId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM palettexingedients WHERE palettexin_id = @PaletteXinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaletteXinId", paletteXinId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}