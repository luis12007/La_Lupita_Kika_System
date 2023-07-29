using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class RegisterXSalesRepository
    {
        private readonly string connectionString;

        public RegisterXSalesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Registerxsales registerXSales)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO registerxsales (register_id, sales_id) VALUES (@RegisterId, @SalesId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegisterId", registerXSales.Register_id);
                command.Parameters.AddWithValue("@SalesId", registerXSales.Sales_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Registerxsales> GetAll()
        {
            List<Registerxsales> registerXSalesList = new List<Registerxsales>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT list_id, register_id, sales_id FROM registerxsales";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int listId = Convert.ToInt32(reader["list_id"]);
                    int registerId = Convert.ToInt32(reader["register_id"]);
                    int salesId = Convert.ToInt32(reader["sales_id"]);
                    Registerxsales registerXSales = new Registerxsales( registerId, salesId);
                    registerXSalesList.Add(registerXSales);
                }
            }
            return registerXSalesList;
        }

        public void Update(Registerxsales registerXSales)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE registerxsales SET register_id = @RegisterId, sales_id = @SalesId WHERE list_id = @ListId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegisterId", registerXSales.Register_id);
                command.Parameters.AddWithValue("@SalesId", registerXSales.Sales_id);
                command.Parameters.AddWithValue("@ListId", registerXSales.List_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<Registerxsales> GetAllByRegisterId(int registerId)
        {
            List<Registerxsales> registerXSalesList = new List<Registerxsales>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT list_id, register_id, sales_id FROM registerxsales WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegisterId", registerId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int listId = Convert.ToInt32(reader["list_id"]);
                    int salesId = Convert.ToInt32(reader["sales_id"]);
                    Registerxsales registerXSales = new Registerxsales(registerId, salesId);
                    registerXSales.List_id = listId; // Asignamos el list_id al objeto Registerxsales
                    registerXSalesList.Add(registerXSales);
                }
            }
            return registerXSalesList;
        }

        public void Delete(int listId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM registerxsales WHERE list_id = @ListId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListId", listId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
