using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace La_Lupita_Kika.UserRepository
{
    public class RegisterRepository
    {
        private readonly string connectionString;

        public RegisterRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Register register)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO register (inhour, outhour, daygains, user_id) VALUES (@Inhour, @Outhour, @DayGains, @UserId)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Inhour", register.Inhour);
                command.Parameters.AddWithValue("@Outhour", register.Outhour);
                command.Parameters.AddWithValue("@DayGains", register.Daygains);
                command.Parameters.AddWithValue("@UserId", register.User_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public Register GetById(int registerId)
        {
            Register register = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT register_id, inhour, outhour, daygains, user_id FROM register WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegisterId", registerId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    DateTime inhour = Convert.ToDateTime(reader["inhour"]);

                    // Verificar si el campo 'outhour' es nulo
                    TimeSpan? outhour = reader.IsDBNull(reader.GetOrdinal("outhour"))
                        ? (TimeSpan?)null
                        : TimeSpan.Parse(reader["outhour"].ToString());

                    // Verificar si el campo 'daygains' es nulo
                    float? dayGains = reader.IsDBNull(reader.GetOrdinal("daygains"))
                        ? (float?)null
                        : Convert.ToSingle(reader["daygains"]);

                    int userId = Convert.ToInt32(reader["user_id"]);
                    register = new Register(registerId, inhour, outhour, dayGains, userId);
                }
                reader.Close();
            }
            return register;
        }

        public List<Register> GetAll()
        {
            List<Register> registers = new List<Register>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT register_id, inhour, outhour, daygains, user_id FROM register";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int registerId = Convert.ToInt32(reader["register_id"]);
                    DateTime inhour = Convert.ToDateTime(reader["inhour"]);

                    // Verificar si el campo 'outhour' es nulo
                    TimeSpan? outhour = reader.IsDBNull(reader.GetOrdinal("outhour"))
                        ? (TimeSpan?)null
                        : TimeSpan.Parse(reader["outhour"].ToString());

                    // Verificar si el campo 'daygains' es nulo
                    float? dayGains = reader.IsDBNull(reader.GetOrdinal("daygains"))
                        ? (float?)null
                        : Convert.ToSingle(reader["daygains"]);

                    int userId = Convert.ToInt32(reader["user_id"]);
                    Register register = new Register(registerId, inhour, outhour, dayGains, userId);
                    registers.Add(register);
                }
            }
            return registers;
        }

        public void Update(Register register)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE register SET inhour = @Inhour, outhour = @Outhour, daygains = @DayGains, user_id = @UserId WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Inhour", register.Inhour);
                command.Parameters.AddWithValue("@Outhour", register.Outhour);
                command.Parameters.AddWithValue("@DayGains", register.Daygains);
                command.Parameters.AddWithValue("@UserId", register.User_id);
                command.Parameters.AddWithValue("@RegisterId", register.Register_id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Register GetByInhour(DateTime inhour)
        {
            Register register = null;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT register_id, inhour, outhour, daygains, user_id FROM register WHERE inhour = @Inhour";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Inhour", inhour);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) // Verificar si se encontró algún registro
                {
                    MySqlDataReader reader = (MySqlDataReader)result;
                    if (reader.Read())
                    {
                        int registerId = Convert.ToInt32(reader["register_id"]);
                        DateTime inhourResult = Convert.ToDateTime(reader["inhour"]);
                        TimeSpan outhour = TimeSpan.Parse(reader["outhour"].ToString());
                        float dayGains = Convert.ToSingle(reader["daygains"]);
                        int userId = Convert.ToInt32(reader["user_id"]);
                        register = new Register(registerId, inhourResult, outhour, dayGains, userId);
                    }
                    reader.Close();
                }
            }
            return register;
        }

        public void UpdateOuthourById(int registerId, TimeSpan? outhour)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE register SET outhour = @Outhour WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Outhour", outhour);
                command.Parameters.AddWithValue("@RegisterId", registerId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDayGainsById(int registerId, float? dayGains)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE register SET daygains = @DayGains WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@DayGains", dayGains);
                command.Parameters.AddWithValue("@RegisterId", registerId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<SalesWithRegisterData> GetSalesWithRegisterDataByDateRange(DateTime startDate, DateTime endDate, int subsidiaryId)
        {
            List<SalesWithRegisterData> salesWithRegisterDataList = new List<SalesWithRegisterData>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"SELECT s.sales_id, r.inhour, s.name AS sales_name, s.lot, s.total, r.user_id
                        FROM sales s
                        INNER JOIN registerxsales rs ON s.sales_id = rs.sales_id
                        INNER JOIN register r ON rs.register_id = r.register_id
                        INNER JOIN user u ON r.user_id = u.user_id
                        WHERE r.inhour BETWEEN @StartDate AND @EndDate AND u.subsidiary_ID = @SubsidiaryId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@SubsidiaryId", subsidiaryId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int salesId = Convert.ToInt32(reader["sales_id"]);
                    DateTime registerInhour = Convert.ToDateTime(reader["inhour"]);
                    string salesName = Convert.ToString(reader["sales_name"]);
                    float lot = Convert.ToSingle(reader["lot"]);
                    float total = Convert.ToSingle(reader["total"]);
                    int userId = Convert.ToInt32(reader["user_id"]);

                    SalesWithRegisterData salesData = new SalesWithRegisterData(salesId, registerInhour, salesName, lot, total, userId);
                    salesWithRegisterDataList.Add(salesData);
                }
            }
            return salesWithRegisterDataList;
        }





        public void Delete(int registerId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM register WHERE register_id = @RegisterId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegisterId", registerId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



    }
}
