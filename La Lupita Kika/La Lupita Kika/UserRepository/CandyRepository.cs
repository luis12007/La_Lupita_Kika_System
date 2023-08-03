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
                string query = "INSERT INTO candy (name, category_id, price, codebar, Subsidiary_ID, cuantity) VALUES (@Name, @CategoryId, @Price, @Codebar, @Subsidiary_ID, @cuantity)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", candy.Name);
                command.Parameters.AddWithValue("@CategoryId", candy.Category_id);
                command.Parameters.AddWithValue("@Price", candy.Price);
                command.Parameters.AddWithValue("@Codebar", candy.Codebar);
                command.Parameters.AddWithValue("@Subsidiary_ID", candy.Subsidiary_ID);
                command.Parameters.AddWithValue("@cuantity", candy.Cuantity);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Candy> GetAll()
        {
            List<Candy> candies = new List<Candy>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, name, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    candies.Add(candy);
                }
            }
            return candies;
        }
        public List<Candy> GetAllFind(string productName = null)
        {
            List<Candy> candies = new List<Candy>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy";

                if (!string.IsNullOrEmpty(productName))
                {
                    query += " WHERE name LIKE @ProductName";
                }

                MySqlCommand command = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(productName))
                {
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                }

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, name, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    candies.Add(candy);
                }
            }
            return candies;
        }

        public void UpdateCuantityByCodebarPlus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE candy SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCuantityByCodebarMinus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE candy SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void Update(Candy candy)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE candy SET name = @Name, category_id = @CategoryId, price = @Price, codebar = @Codebar, Subsidiary_ID=@Subsidiary_ID WHERE candy_id = @CandyId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", candy.Name);
                command.Parameters.AddWithValue("@CategoryId", candy.Category_id);
                command.Parameters.AddWithValue("@Price", candy.Price);
                command.Parameters.AddWithValue("@Codebar", candy.Codebar);
                command.Parameters.AddWithValue("@CandyId", candy.Candy_id);
                command.Parameters.AddWithValue("@Subsidiary_ID", candy.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCandy(string name, float price, string codebar, int candyId, int subsidiaryId, string oldName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE candy SET name = @Name, price = @Price, codebar = @Codebar, Subsidiary_ID = @Subsidiary_ID WHERE name = @OldName AND candy_id = @CandyId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@CandyId", candyId);
                command.Parameters.AddWithValue("@Subsidiary_ID", subsidiaryId);
                command.Parameters.AddWithValue("@OldName", oldName);
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
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy WHERE name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string candyName = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, candyName, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    return candy;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public List<Candy> FindAllBySubsidiaryId(int subsidiaryId)
        {
            List<Candy> candyList = new List<Candy>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy WHERE Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string candyName = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, candyName, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    candyList.Add(candy);
                }
            }
            return candyList;
        }
        public List<Candy> FindAllBySubsidiaryIdFind(int subsidiaryId, string productName = null)
        {
            List<Candy> candyList = new List<Candy>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy WHERE Subsidiary_ID = @SubsidiaryId";

                if (!string.IsNullOrEmpty(productName))
                {
                    query += " AND name LIKE @ProductName";
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);

                if (!string.IsNullOrEmpty(productName))
                {
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                }

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string candyName = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, candyName, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    candyList.Add(candy);
                }
            }
            return candyList;
        }

        public Candy FindCandyByNameAndSubsidiary(string name, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID, cuantity FROM candy WHERE name = @Name AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string candyName = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    Candy candy = new Candy(candyId, candyName, categoryId, price, codebar, Subsidiary_ID, cuantity);
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

        public List<string> FindNamesByCategoryAndSubsidiary(int categoryId, int subsidiaryId)
        {
            List<string> namesList = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM candy WHERE category_id = @CategoryId AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
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
                string query = "SELECT candy_id, name, category_id, price, codebar, Subsidiary_ID,cuantity FROM candy WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int candyId = Convert.ToInt32(reader["candy_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Candy candy = new Candy(candyId, name, categoryId, price, codebar, Subsidiary_ID, cuantity);
                    return candy;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }

    }
}
