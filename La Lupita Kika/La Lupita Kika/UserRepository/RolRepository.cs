using La_Lupita_Kika.Models;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class RolRepository
    {
        private readonly string connectionString;

        public RolRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Rol rol)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO rol (Name) VALUES (@Name)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", rol.Name);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public int FindIdByName(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT rol_id FROM rol WHERE Name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    return id;
                }
                return -1; // Si no se encuentra el nombre, devolver -1
            }
        }

        public List<Rol> GetAll()
        {
            List<Rol> roles = new List<Rol>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT rol_id, Name FROM rol";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int rolId = Convert.ToInt32(reader["rol_id"]);
                    string name = Convert.ToString(reader["Name"]);
                    Rol rol = new Rol(rolId, name);
                    roles.Add(rol);
                }
            }
            return roles;
        }
        public string GetNameById(int rolId)
        {
            string name = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Name FROM rol WHERE rol_id = @RolId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RolId", rolId);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    name = result.ToString();
                }
            }
            return name;
        }

        public void Update(Rol rol)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE rol SET Name = @Name WHERE rol_id = @rol_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", rol.Name);
                command.Parameters.AddWithValue("@rol_id", rol.Rol_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int GetRoleIdByName(string roleName)
        {
            int roleId = -1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT rol_id FROM rol WHERE Name = @Name";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", roleName);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    roleId = id;
                }
            }
            return roleId;
        }

        public void Delete(int rolId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM rol WHERE rol_id = @rol_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@rol_id", rolId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
