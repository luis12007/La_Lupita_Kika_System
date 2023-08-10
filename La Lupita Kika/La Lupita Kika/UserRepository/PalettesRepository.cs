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
                string query = "INSERT INTO palettes (name, category_Id, price, codebar, codigo,cuantity,Subsidiary_ID) VALUES (@Name, @CategoryId, @Price, @Codebar, @Codigo,@cuantity , @Subsidiary_ID)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", palette.Name);
                command.Parameters.AddWithValue("@CategoryId", palette.Category_Id);
                command.Parameters.AddWithValue("@Price", palette.Price);
                command.Parameters.AddWithValue("@Codebar", palette.Codebar);
                command.Parameters.AddWithValue("@Codigo", palette.Codigo);
                command.Parameters.AddWithValue("@cuantity", palette.Cuantity);
                command.Parameters.AddWithValue("@Subsidiary_ID", palette.Subsidiary_ID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Palettes> GetAll()
        {
            List<Palettes> palettes = new List<Palettes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo,cuantity,Subsidiary_ID FROM palettes";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int paletteId = Convert.ToInt32(reader["Palette_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_Id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string codigo = Convert.ToString(reader["codigo"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    palettes.Add(palette);
                }
            }
            return palettes;
        }

        public List<Palettes> GetAllfind(string productName = null)
        {
            List<Palettes> palettes = new List<Palettes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes";

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
                    int paletteId = Convert.ToInt32(reader["Palette_id"]);
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    string name = Convert.ToString(reader["name"]);
                    int categoryId = Convert.ToInt32(reader["category_Id"]);
                    float price = Convert.ToSingle(reader["price"]);
                    string codebar = Convert.ToString(reader["codebar"]);
                    string codigo = Convert.ToString(reader["codigo"]);
                    float cuantity = Convert.ToSingle(reader["cuantity"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    palettes.Add(palette);
                }
            }
            return palettes;
        }


        public void UpdateCuantityByCodebarAndSubsidiary(string codebar, int cuantityplus, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE palettes SET cuantity = cuantity + {cuantityplus} WHERE codebar = @Codebar AND subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void UpdateCuantityByCodebarmin(string codebar, int cuantitymin, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE palettes SET cuantity = cuantity - {cuantitymin} WHERE codebar = @Codebar AND subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                command.Parameters.AddWithValue("@Codebar", codebar);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Palettes palette)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE palettes SET name = @Name, category_Id = @CategoryId, price = @Price, codebar = @Codebar, codigo = @Codigo, Subsidiary_ID=@Subsidiary_ID WHERE Palette_id = @PaletteId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", palette.Name);
                command.Parameters.AddWithValue("@CategoryId", palette.Category_Id);
                command.Parameters.AddWithValue("@Price", palette.Price);
                command.Parameters.AddWithValue("@Codebar", palette.Codebar);
                command.Parameters.AddWithValue("@Codigo", palette.Codigo);
                command.Parameters.AddWithValue("@PaletteId", palette.Palette_id);
                command.Parameters.AddWithValue("@Subsidiary_ID", palette.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdatePalette(string name, float price, string codebar, float quantity, int subsidiaryId,string oldname)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE palettes SET price = @Price, codebar = @Codebar, cuantity = @Quantity WHERE name = @Name_old AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Codebar", codebar);
                command.Parameters.AddWithValue("@Quantity", quantity);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                command.Parameters.AddWithValue("@Name_old", oldname);
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
        public List<string> GetNamesByCategoryIdAndSubsidiaryId(int categoryId, int subsidiaryId)
        {
            List<string> names = new List<string>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT name FROM palettes WHERE category_Id = @CategoryId AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@CategoryId", categoryId);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = Convert.ToString(reader["name"]);
                        names.Add(name);
                    }
                }
            }
            return names;
        }

        public Palettes FindProductByName(string productName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes WHERE name = @ProductName";
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
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    return palette;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public Palettes FindProductByNameAndSubsidiary(string productName, int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes WHERE name = @ProductName AND Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
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
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    return palette;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
        public List<Palettes> FindProductsBySubsidiaryId(int subsidiaryId)
        {
            List<Palettes> palettes = new List<Palettes>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes WHERE Subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
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
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    palettes.Add(palette);
                }
            }
            return palettes;
        }

        public List<Palettes> FindProductsBySubsidiaryId2(int subsidiaryId, string productName = null)
{
    List<Palettes> palettes = new List<Palettes>();
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes WHERE Subsidiary_ID = @SubsidiaryId";

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
            int paletteId = Convert.ToInt32(reader["Palette_id"]);
            string name = Convert.ToString(reader["name"]);
            int categoryId = Convert.ToInt32(reader["category_Id"]);
            float price = Convert.ToSingle(reader["price"]);
            string codebar = Convert.ToString(reader["codebar"]);
            string codigo = Convert.ToString(reader["codigo"]);
            float cuantity = Convert.ToSingle(reader["cuantity"]);
            int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
            Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
            palettes.Add(palette);
        }
    }
    return palettes;
}



        public Palettes FindByCodebar(string codebar)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Palette_id, name, category_Id, price, codebar, codigo, cuantity, Subsidiary_ID FROM palettes WHERE codebar = @Codebar";
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
                    int Subsidiary_ID = Convert.ToInt32(reader["Subsidiary_ID"]);
                    Palettes palette = new Palettes(paletteId, name, categoryId, price, codebar, codigo, cuantity, Subsidiary_ID);
                    return palette;
                }
                return null; // Si no se encuentra la entidad, retornar null
            }
        }
    }
}
