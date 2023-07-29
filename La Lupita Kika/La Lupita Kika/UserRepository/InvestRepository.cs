using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class InvestRepository
    {
        private readonly string connectionString;

        public InvestRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Invest invest)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO invest (date, price) VALUES (@Date, @Price)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", invest.Date);
                command.Parameters.AddWithValue("@Price", invest.Price);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Invest> GetAll()
        {
            List<Invest> invests = new List<Invest>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT invest_id, date, price FROM invest";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int investId = Convert.ToInt32(reader["invest_id"]);
                    DateTime date = Convert.ToDateTime(reader["date"]);
                    float price = Convert.ToSingle(reader["price"]);
                    Invest invest = new Invest(investId, date, price);
                    invests.Add(invest);
                }
            }
            return invests;
        }

        public void Update(Invest invest)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE invest SET date = @Date, price = @Price WHERE invest_id = @InvestId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", invest.Date);
                command.Parameters.AddWithValue("@Price", invest.Price);
                command.Parameters.AddWithValue("@InvestId", invest.Invest_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int investId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM invest WHERE invest_id = @InvestId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@InvestId", investId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
