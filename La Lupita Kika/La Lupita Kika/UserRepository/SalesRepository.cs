using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class SalesRepository
    {
        private readonly string connectionString;

        public SalesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Sales sales)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO sales (name, lot, total) VALUES (@Name, @Lot, @Total)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", sales.Name);
                command.Parameters.AddWithValue("@Lot", sales.Lot);
                command.Parameters.AddWithValue("@Total", sales.Total);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public List<Sales> GetAll()
        {
            List<Sales> salesList = new List<Sales>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT sales_id, name, lot, total FROM sales";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["sales_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float lot = Convert.ToSingle(reader["lot"]);
                    float total = Convert.ToSingle(reader["total"]);
                    Sales sales = new Sales(id, name, lot, total);
                    salesList.Add(sales);
                }
            }
            return salesList;
        }

        public void Update(Sales sales)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE sales SET name = @Name, product_id = @ProductId, lot = @Lot, total = @Total WHERE sales_id = @SalesId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", sales.Name);
                command.Parameters.AddWithValue("@Lot", sales.Lot);
                command.Parameters.AddWithValue("@Total", sales.Total);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Sales> GetAllByIds(List<int> salesIds)
        {
            List<Sales> salesList = new List<Sales>();
            if (salesIds == null || salesIds.Count == 0)
            {
                return salesList; // Si la lista de IDs está vacía o es nula, retornamos la lista vacía.
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Generamos la consulta dinámicamente para obtener las ventas con los IDs especificados.
                string query = "SELECT sales_id, name, lot, total FROM sales WHERE sales_id IN (";
                for (int i = 0; i < salesIds.Count; i++)
                {
                    query += "@SalesId" + i;
                    if (i < salesIds.Count - 1)
                    {
                        query += ", ";
                    }
                }
                query += ")";

                MySqlCommand command = new MySqlCommand(query, connection);

                // Agregamos los parámetros para los IDs de ventas.
                for (int i = 0; i < salesIds.Count; i++)
                {
                    command.Parameters.AddWithValue("@SalesId" + i, salesIds[i]);
                }

                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["sales_id"]);
                    string name = Convert.ToString(reader["name"]);
                    float lot = Convert.ToSingle(reader["lot"]);
                    float total = Convert.ToSingle(reader["total"]);
                    Sales sales = new Sales(id, name, lot, total);
                    salesList.Add(sales);
                }
            }
            return salesList;
        }

        public void Delete(int salesId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM sales WHERE sales_id = @SalesId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SalesId", salesId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
