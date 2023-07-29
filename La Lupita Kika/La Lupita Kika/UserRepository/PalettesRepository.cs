using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class PalettesRepository
    {
        private readonly string connectionString;

        public PalettesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Palettes palette)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO palettes (name, category_Id, price, codebar, codigo) VALUES (@Name, @CategoryId, @Price, @Codebar, @Codigo)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", palette.Name);
                command.Parameters.AddWithValue("@CategoryId", palette.Category_Id);
                command.Parameters.AddWithValue("@Price", palette.Price);
                command.Parameters.AddWithValue("@Codebar", palette.Codebar);
                command.Parameters.AddWithValue("@Codigo", palette.Codigo);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Palettes> GetAll()
        {
            List<Palettes> palettes = new List<Palettes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo,cuantity FROM palettes";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int paletteId = Convert.ToInt32(reader["Palette_id"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_Id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string codigo = Convert.ToString(reader["codigo"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity);
                    palettes.Add(palette);
                }
            }
            return palettes;
        }

        public void UpdateCuantityByCodebarPlus(string codebar,int cuantityplus)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE palettes SET cuantity = cuantity + {cuantityplus} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCuantityByCodebarmin(string codebar, int cuantitymin)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE palettes SET cuantity = cuantity - {cuantitymin} WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Palettes palette)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE palettes SET name = @Name, category_Id = @CategoryId, price = @Price, codebar = @Codebar, codigo = @Codigo WHERE Palette_id = @PaletteId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", palette.Name);
                command.Parameters.AddWithValue("@CategoryId", palette.Category_Id);
                command.Parameters.AddWithValue("@Price", palette.Price);
                command.Parameters.AddWithValue("@Codebar", palette.Codebar);
                command.Parameters.AddWithValue("@Codigo", palette.Codigo);
                command.Parameters.AddWithValue("@PaletteId", palette.Palette_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int paletteId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM palettes WHERE Palette_id = @PaletteId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@PaletteId", paletteId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<string> GetNamesByCategoryId(int categoryId)
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM palettes WHERE category_Id = @CategoryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
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

        public Palettes FindProductByName(string productName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity FROM palettes WHERE name = @ProductName";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int paletteId = Convert.ToInt32(reader["Palette_id"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_Id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string codigo = Convert.ToString(reader["codigo"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity);
                    return palette;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public Palettes FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity FROM palettes WHERE codebar = @Codebar";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int paletteId = Convert.ToInt32(reader["Palette_id"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_Id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codigo = Convert.ToString(reader["codigo"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity);
                    return palette;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
    }
}
