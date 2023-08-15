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
                string query = "INSERT INTO ingredients (name, code, price, unit, type, Subsidiary_ID, Category) VALUES (@Name, @Code, @Price, @Unit, @Type, @Subsidiary_ID , @Category)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Code", ingredient.Code);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@Subsidiary_ID", ingredient.Subsidiary_ID);
                command.Parameters.AddWithValue("@Category",ingredient.Category);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<Ingredients> FindByNameContaining(string partialName)
        {
            List<Ingredients> matchingIngredients = new List<Ingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID, Category FROM ingredients WHERE name LIKE @PartialName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@PartialName", $"%{partialName}%");
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
                    string Category = Convert.ToString(reader["Category"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);

                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID, Category);
                    matchingIngredients.Add(ingredient);
                }
            }
            return matchingIngredients;
        }


        public List<Ingredients> FindBySubsidiary(int subsidiaryId)
        {
            List<Ingredients> matchingIngredients = new List<Ingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID, Category FROM ingredients WHERE Subsidiary_ID = @SubsidiaryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryID", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string code = Convert.ToString(reader["code"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float unit = Convert.ToSingle(reader["unit"]);
                    string Category = Convert.ToString(reader["Category"]);
                    string type = Convert.ToString(reader["type"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID, Category);
                    matchingIngredients.Add(ingredient);
                }
            }
            return matchingIngredients;
        }


        public List<Ingredients> GetAll()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID,Category FROM ingredients";
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
                    string Category = Convert.ToString(reader["Category"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID, Category);
                    ingredients.Add(ingredient);
                }
            }
            return ingredients;
        }
        public void EditIngredientsList(List<Ingredients> ingredientsList)
        {
            foreach (Ingredients ingredient in ingredientsList)
            {
                EditIngredient(ingredient);
            }
        }

        public void EditIngredient(Ingredients ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ingredients WHERE name = @Name AND Subsidiary_ID = @SubsidiaryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@SubsidiaryID", ingredient.Subsidiary_ID);
                connection.Open();

                int existingCount = Convert.ToInt32(command.ExecuteScalar());

                if (existingCount > 0)
                {
                    // El ingrediente existe, actualizarlo
                    query = "UPDATE ingredients SET code = @Code, price = @Price, unit = @Unit, type = @Type, Category = @Category WHERE name = @Name AND Subsidiary_ID = @SubsidiaryID";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Code", ingredient.Code);
                    command.Parameters.AddWithValue("@Price", ingredient.Price);
                    command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                    command.Parameters.AddWithValue("@Type", ingredient.Type);
                    command.Parameters.AddWithValue("@Category", ingredient.Category);
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@SubsidiaryID", ingredient.Subsidiary_ID);
                    command.ExecuteNonQuery();
                }
                else
                {
                    // El ingrediente no existe, agregarlo
                    query = "INSERT INTO ingredients (name, code, price, unit, type, Subsidiary_ID, Category) VALUES (@Name, @Code, @Price, @Unit, @Type, @Subsidiary_ID, @Category)";
                    command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", ingredient.Name);
                    command.Parameters.AddWithValue("@Code", ingredient.Code);
                    command.Parameters.AddWithValue("@Price", ingredient.Price);
                    command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                    command.Parameters.AddWithValue("@Type", ingredient.Type);
                    command.Parameters.AddWithValue("@Category", ingredient.Category);
                    command.Parameters.AddWithValue("@Subsidiary_ID", ingredient.Subsidiary_ID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Ingredients FindByNameAndSubsidiary(string ingredientName, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID,Category FROM ingredients WHERE name = @Name AND Subsidiary_ID = @SubsidiaryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredientName);
                command.Parameters.AddWithValue("@SubsidiaryID", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int ingredientsId = Convert.ToInt32(reader["ingredients_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string code = Convert.ToString(reader["code"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string Category = Convert.ToString(reader["Category"]);
                    float unit = Convert.ToSingle(reader["unit"]);
                    string type = Convert.ToString(reader["type"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);

                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID, Category);
                    return ingredient;
                }

                return null; // Si no se encontró ningún ingrediente con el nombre y la ID de la sucursal proporcionados
            }
        }


        public void EditUnitByNameAndSubsidiaryId(string ingredientName, int subsidiaryId, float newUnit)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE ingredients SET unit = @NewUnit WHERE name = @Name AND Subsidiary_ID = @SubsidiaryID";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewUnit", newUnit);
                command.Parameters.AddWithValue("@Name", ingredientName);
                command.Parameters.AddWithValue("@SubsidiaryID", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Update(Ingredients ingredient)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE ingredients SET name = @Name, code = @Code, price = @Price, unit = @Unit, type = @Type, Category = @Category WHERE ingredients_id = @IngredientsId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", ingredient.Name);
                command.Parameters.AddWithValue("@Code", ingredient.Code);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@Unit", ingredient.Unit);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@Category", ingredient.Category);
                command.Parameters.AddWithValue("@IngredientsId", ingredient.Ingredients_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Ingredients> FindBySubsidiaryAndCategory(int subsidiaryId, string category)
        {
            List<Ingredients> matchingIngredients = new List<Ingredients>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ingredients_id, name, code, price, unit, type, Subsidiary_ID, Category FROM ingredients WHERE Subsidiary_ID = @SubsidiaryID AND Category = @Category";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryID", subsidiaryId);
                command.Parameters.AddWithValue("@Category", category);
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
                    string Category = Convert.ToString(reader["Category"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Ingredients ingredient = new Ingredients(ingredientsId, name, code, price, unit, type, Subsidiary_ID, Category);
                    matchingIngredients.Add(ingredient);
                }
            }
            return matchingIngredients;
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
