using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class InvestXIngredientsRepository
    {
        private readonly string connectionString;

        public InvestXIngredientsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Investxingredients investXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO investxingredients (ingredients_id, invest_id) VALUES (@IngredientsId, @InvestId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", investXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@InvestId", investXIngredients.Invest_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Investxingredients> GetAll()
        {
            List<Investxingredients> investXIngredientsList = new List<Investxingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT snowXin_id, ingredients_id, invest_id FROM investxingredients";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int investXinId = Convert.ToInt32(reader["snowXin_id"]);
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    int investId = Convert.ToInt32(reader["invest_id"]);
                    Investxingredients investXIngredients = new Investxingredients(investXinId, ingredientsId, investId);
                    investXIngredientsList.Add(investXIngredients);
                }
            }
            return investXIngredientsList;
        }

        public void Update(Investxingredients investXIngredients)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE investxingredients SET ingredients_id = @IngredientsId, invest_id = @InvestId WHERE snowXin_id = @InvestXinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@IngredientsId", investXIngredients.Ingredients_id);
                command.Parameters.AddWithValue("@InvestId", investXIngredients.Invest_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int investXinId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM investxingredients WHERE snowXin_id = @InvestXinId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@InvestXinId", investXinId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
