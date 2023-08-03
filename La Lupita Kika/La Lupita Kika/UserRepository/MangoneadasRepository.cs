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
                string query = "INSERT INTO mangoneadas (name, price, codebar, code, category_id, Subsidiary_ID) VALUES (@Name, @Price, @Codebar, @Code, @CategoryId, @Subsidiary_ID)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", mangoneada.Name);
                command.Parameters.AddWithValue("@Price", mangoneada.Price);
                command.Parameters.AddWithValue("@Codebar", mangoneada.Codebar);
                command.Parameters.AddWithValue("@Code", mangoneada.Code);
                command.Parameters.AddWithValue("@CategoryId", mangoneada.Category_id);
                command.Parameters.AddWithValue("@Subsidiary_ID", mangoneada.Subsidiary_ID);
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

        public List<string> GetAllNamesBySubsidiaryId(int subsidiaryId)
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM mangoneadas WHERE Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
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
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity, Subsidiary_ID FROM mangoneadas WHERE name = @ProductName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = 1;
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                    return mangoneada;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public List<Mangoneadas> FindBySubsidiaryId(int subsidiaryId)
        {
            List<Mangoneadas> mangoneadasList = new List<Mangoneadas>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity, Subsidiary_ID FROM mangoneadas WHERE Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                        int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                        string name = Convert.ToString(reader["name"]);
                        float price = Convert.ToSingle(reader["price"]);
                        string codebar = Convert.ToString(reader["codebar"]);
                        string code = Convert.ToString(reader["code"]);
                        int categoryId = 1; // Cambiar este valor si la categoría se encuentra en la tabla.
                        float cuantity = Convert.ToSingle(reader["cuantity"]);
                        Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                        mangoneadasList.Add(mangoneada);
                    }
                }
            }
            return mangoneadasList;
        }

        public Mangoneadas FindByProductNameAndSubsidiary(string productName, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity, Subsidiary_ID FROM mangoneadas WHERE name = @ProductName AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = 1; // Cambiar este valor si la categoría se encuentra en la tabla.
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
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
                string query = "SELECT mangoneadas_id, name, price, codebar, code, category_id, cuantity, Subsidiary_ID FROM mangoneadas";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float cuantity = Convert.ToSingle(reader["Cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                    mangoneadas.Add(mangoneada);
                }
            }
            return mangoneadas;
        }


        public void UpdateCuantityByCodebarPlus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE mangoneadas SET cuantity = cuantity + {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateMangoneadas(string name, float price, string codebar, float cuantity, int subsidiaryId, string oldname)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE mangoneadas SET price = @Price, codebar = @Codebar, cuantity = @Cuantity WHERE name = @Name_old AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@Cuantity", cuantity);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                command.Parameters.AddWithValue("@Name_old", oldname);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<Mangoneadas> FindMangoneadasBySubsidiaryId(int subsidiaryId, string productName = null)
        {
            List<Mangoneadas> mangoneadasList = new List<Mangoneadas>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity, Subsidiary_ID FROM mangoneadas WHERE Subsidiary_ID = @SubsidiaryId";

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
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                        int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                        string name = Convert.ToString(reader["name"]);
                        float price = Convert.ToSingle(reader["price"]);
                        string codebar = Convert.ToString(reader["codebar"]);
                        string code = Convert.ToString(reader["code"]);
                        int categoryId = 1; // Cambiar este valor si la categoría se encuentra en la tabla.
                        float cuantity = Convert.ToSingle(reader["cuantity"]);
                        Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                        mangoneadasList.Add(mangoneada);
                    }
                }
            }
            return mangoneadasList;
        }

        public List<Mangoneadas> FindAllMangoneadas(string productName = null)
        {
            List<Mangoneadas> mangoneadas = new List<Mangoneadas>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT mangoneadas_id, name, price, codebar, code, category_id, cuantity, Subsidiary_ID FROM mangoneadas";

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
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = Convert.ToInt32(reader["category_id"]);
                    float cuantity = Convert.ToSingle(reader["Cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                    mangoneadas.Add(mangoneada);
                }
            }
            return mangoneadas;
        }

        public void UpdateCuantityByCodebarMinus(string codebar, int cuantity, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE mangoneadas SET cuantity = cuantity - {cuantity} WHERE codebar = @Codebar AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Mangoneadas mangoneada)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE mangoneadas SET name = @Name, price = @Price, codebar = @Codebar, code = @Code, category_id = @CategoryId,Subsidiary_ID =@Subsidiary_ID  WHERE mangoneadas_id = @MangoneadasId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", mangoneada.Name);
                command.Parameters.AddWithValue("@Price", mangoneada.Price);
                command.Parameters.AddWithValue("@Codebar", mangoneada.Codebar);
                command.Parameters.AddWithValue("@Code", mangoneada.Code);
                command.Parameters.AddWithValue("@CategoryId", mangoneada.Category_id);
                command.Parameters.AddWithValue("@MangoneadasId", mangoneada.Mangoneadas_id);
                command.Parameters.AddWithValue("@Subsidiary_ID", mangoneada.Subsidiary_ID);
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
                string query = "SELECT mangoneadas_id, name, price, codebar, code, cuantity,Subsidiary_ID FROM mangoneadas WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int mangoneadasId = Convert.ToInt32(reader["mangoneadas_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string code = Convert.ToString(reader["code"]);
                    int categoryId = 1;
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Mangoneadas mangoneada = new Mangoneadas(mangoneadasId, name, price, codebar, code, categoryId, cuantity, Subsidiary_ID);
                    return mangoneada;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
    }
}
