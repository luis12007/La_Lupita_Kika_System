using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace La_Lupita_Kika.UserRepository
{
    public class SubsidiaryRepository
    {
        private readonly string connectionString;

        public SubsidiaryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Subsidiary subsidiary)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO subsidiary (Name, Place, Address) VALUES (@Name, @Place, @Address)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", subsidiary.Name);
                command.Parameters.AddWithValue("@Place", subsidiary.Place);
                command.Parameters.AddWithValue("@Address", subsidiary.Address);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int FindIdByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subsidiary_ID FROM subsidiary WHERE Name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    return id;
                }
                return 1; // Si no se encuentra el nombre, devolver -1
            }
        }

        public List<Subsidiary> GetAll()
        {
            List<Subsidiary> subsidiaries = new List<Subsidiary>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subsidiary_ID, Name, Place, Address FROM subsidiary";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int subsidiaryId = Convert.ToInt32(reader["subsidiary_ID"]);
                    string name = Convert.ToString(reader["Name"]);
                    string place = Convert.ToString(reader["Place"]);
                    string address = Convert.ToString(reader["Address"]);
                    Subsidiary subsidiary = new Subsidiary(subsidiaryId, name, place, address);
                    subsidiaries.Add(subsidiary);
                }
            }
            return subsidiaries;
        }

        public async Task<List<Subsidiary>> GetAllAsync()
        {
            List<Subsidiary> subsidiaries = new List<Subsidiary>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subsidiary_ID, Name, Place, Address FROM subsidiary";
                MySqlCommand command = new MySqlCommand(query, connection);
                await connection.OpenAsync();

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        int subsidiaryId = Convert.ToInt32(reader["subsidiary_ID"]);
                        string name = Convert.ToString(reader["Name"]);
                        string place = Convert.ToString(reader["Place"]);
                        string address = Convert.ToString(reader["Address"]);
                        Subsidiary subsidiary = new Subsidiary(subsidiaryId, name, place, address);
                        subsidiaries.Add(subsidiary);
                    }
                }
            }
            return subsidiaries;
        }


        public void Update(Subsidiary subsidiary)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE subsidiary SET Name = @Name, Place = @Place, Address = @Address WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", subsidiary.Name);
                command.Parameters.AddWithValue("@Place", subsidiary.Place);
                command.Parameters.AddWithValue("@Address", subsidiary.Address);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiary.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM subsidiary WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string FindNameById(int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name FROM subsidiary WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return result.ToString();
                }
                return null;
            }
        }

        public Subsidiary FindById(int subsidiaryId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT subsidiary_ID, Name, Place, Address FROM subsidiary WHERE subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string name = Convert.ToString(reader["Name"]);
                    string place = Convert.ToString(reader["Place"]);
                    string address = Convert.ToString(reader["Address"]);
                    Subsidiary subsidiary = new Subsidiary(subsidiaryId, name, place, address);
                    return subsidiary;
                }
                return null;
            }
        }

        // Puedes agregar otros métodos según tus necesidades, como buscar por nombre, lugar, etc.
    }
}
