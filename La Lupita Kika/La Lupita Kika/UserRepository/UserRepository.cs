using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class UserRepository
    {
        private readonly string connectionString;

        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(User user)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO user (name, password, username, mail, rol_id,subsidiary_ID) VALUES (@Name, @Password, @Username, @Mail, @RolId,@subsidiary_ID)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Mail", user.Mail);
                command.Parameters.AddWithValue("@RolId", user.Rol_id);
                command.Parameters.AddWithValue("@subsidiary_ID", user.Subsidiary_ID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT user_id, name, password, username, mail, rol_id, subsidiary_ID FROM user";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string password = Convert.ToString(reader["password"]);
                    string username = Convert.ToString(reader["username"]);
                    string mail = Convert.ToString(reader["mail"]);
                    int rolId = Convert.ToInt32(reader["rol_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    User user = new User(userId, name, password, username, mail, rolId, subsidiary_ID);
                    users.Add(user);
                }
            }
            return users;
        }

        public void Update(User user, string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = $"UPDATE user SET name = @Name, password = @Password, username = @Username, mail = @Mail, rol_id = @RolId, subsidiary_ID =@subsidiary_ID WHERE Username = @olduser";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Mail", user.Mail);
                command.Parameters.AddWithValue("@RolId", user.Rol_id);
                command.Parameters.AddWithValue("@UserId", user.User_id);
                command.Parameters.AddWithValue("@subsidiary_ID", user.Subsidiary_ID);
                command.Parameters.AddWithValue("@olduser", username);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM user WHERE user_id = @UserId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public User GetUserByUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT user_id, name, password, username, mail, rol_id, subsidiary_ID FROM user WHERE username = @Username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string password = Convert.ToString(reader["password"]);
                    string mail = Convert.ToString(reader["mail"]);
                    int rolId = Convert.ToInt32(reader["rol_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    User user = new User(userId, name, password, username, mail, rolId, subsidiary_ID);
                    return user;
                }
                else
                {
                    return null; // Si no se encuentra el usuario, devolver null
                }
            }
        }
        public User GetUserById(int userId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT user_id, name, password, username, mail, rol_id, subsidiary_ID FROM user WHERE user_id = @UserId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string name = Convert.ToString(reader["name"]);
                    string password = Convert.ToString(reader["password"]);
                    string username = Convert.ToString(reader["username"]);
                    string mail = Convert.ToString(reader["mail"]);
                    int rolId = Convert.ToInt32(reader["rol_id"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    User user = new User(userId, name, password, username, mail, rolId, subsidiary_ID);
                    return user;
                }
                else
                {
                    return null; // Si no se encuentra el usuario, devolver null
                }
            }
        }

        public List<User> GetUsersByRol(int rolId)
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT user_id, name, password, username, mail, subsidiary_ID FROM user WHERE rol_id = @RolId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RolId", rolId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int userId = Convert.ToInt32(reader["user_id"]);
                    string name = Convert.ToString(reader["name"]);
                    string password = Convert.ToString(reader["password"]);
                    string username = Convert.ToString(reader["username"]);
                    string mail = Convert.ToString(reader["mail"]);
                    int subsidiary_ID = Convert.ToInt32(reader["subsidiary_ID"]);
                    User user = new User(userId, name, password, username, mail, rolId, subsidiary_ID);
                    users.Add(user);
                }
            }
            return users;
        }

        public void DeleteByUsername(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM user WHERE username = @Username";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
