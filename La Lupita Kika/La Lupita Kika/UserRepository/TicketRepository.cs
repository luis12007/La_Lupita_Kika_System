using La_Lupita_Kika.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace La_Lupita_Kika.UserRepository
{
    public class TicketRepository
    {
        private readonly string connectionString;

        public TicketRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Ticket ticket)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO ticket (image, Title, Address, Date, Time, CashierName, Products, Subtotal, Cancelled, `Change`, FarewellMessage) VALUES (@Image, @Title, @Address, @Date, @Time, @CashierName, @Products, @Subtotal, @Cancelled, @Change, @FarewellMessage)";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Image", null);
                command.Parameters.AddWithValue("@Title", ticket.Title);
                command.Parameters.AddWithValue("@Address", ticket.Address);
                command.Parameters.AddWithValue("@Date", ticket.DateTicket);
                command.Parameters.AddWithValue("@Time", ticket.TimeTicket);
                command.Parameters.AddWithValue("@CashierName", ticket.CashierName);
                command.Parameters.AddWithValue("@Subtotal", ticket.Subtotal);
                command.Parameters.AddWithValue("@Cancelled", ticket.Cancelled);
                command.Parameters.AddWithValue("@Change", ticket.Change);
                command.Parameters.AddWithValue("@FarewellMessage", ticket.FarewellMessage);
                command.Parameters.AddWithValue("@Products", null);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Ticket> GetAll()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ticket_ID, image, Title, Address, Date, Time, CashierName, Subtotal, Cancelled, `Change`, FarewellMessage FROM ticket";
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ticketId = Convert.ToInt32(reader["ticket_ID"]);
                    Image image = ConvertImageFromBase64(Convert.ToString(reader["image"]));
                    string title = Convert.ToString(reader["Title"]);
                    string address = Convert.ToString(reader["Address"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    TimeSpan time = TimeSpan.Parse(reader["Time"].ToString());
                    string cashierName = Convert.ToString(reader["CashierName"]);
                    float subtotal = Convert.ToSingle(reader["Subtotal"]);
                    float cancelled = Convert.ToSingle(reader["Cancelled"]);
                    float change = Convert.ToSingle(reader["Change"]);
                    string farewellMessage = Convert.ToString(reader["FarewellMessage"]);

                    Ticket ticket = new Ticket(ticketId, image, title, address, date, time, cashierName, null, subtotal, cancelled, change, farewellMessage);
                    tickets.Add(ticket);
                }
            }
            return tickets;
        }

        public void Update(Ticket ticket)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "UPDATE ticket SET image = @Image, Title = @Title, Address = @Address, Date = @Date, Time = @Time, CashierName = @CashierName, Subtotal = @Subtotal, Cancelled = @Cancelled, Change = @Change, FarewellMessage = @FarewellMessage WHERE ticket_ID = @TicketId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Image", ConvertImageToBase64(ticket.Image));
                command.Parameters.AddWithValue("@Title", ticket.Title);
                command.Parameters.AddWithValue("@Address", ticket.Address);
                command.Parameters.AddWithValue("@Date", ticket.DateTicket);
                command.Parameters.AddWithValue("@Time", ticket.TimeTicket);
                command.Parameters.AddWithValue("@CashierName", ticket.CashierName);
                command.Parameters.AddWithValue("@Subtotal", ticket.Subtotal);
                command.Parameters.AddWithValue("@Cancelled", ticket.Cancelled);
                command.Parameters.AddWithValue("@Change", ticket.Change);
                command.Parameters.AddWithValue("@FarewellMessage", ticket.FarewellMessage);
                command.Parameters.AddWithValue("@TicketId", ticket.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int ticketId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "DELETE FROM ticket WHERE ticket_ID = @TicketId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TicketId", ticketId);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Ticket GetById(int ticketId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ticket_ID, image, Title, Address, Date, Time, CashierName, Subtotal, Cancelled, Change, FarewellMessage FROM ticket WHERE ticket_ID = @TicketId";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TicketId", ticketId);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Image image = ConvertImageFromBase64(Convert.ToString(reader["image"]));
                    string title = Convert.ToString(reader["Title"]);
                    string address = Convert.ToString(reader["Address"]);
                    DateTime date = Convert.ToDateTime(reader["Date"]);
                    TimeSpan time = TimeSpan.Parse(reader["Time"].ToString());
                    string cashierName = Convert.ToString(reader["CashierName"]);
                    float subtotal = Convert.ToSingle(reader["Subtotal"]);
                    float cancelled = Convert.ToSingle(reader["Cancelled"]);
                    float change = Convert.ToSingle(reader["Change"]);
                    string farewellMessage = Convert.ToString(reader["FarewellMessage"]);

                    return new Ticket(ticketId, image, title, address, date, time, cashierName, null, subtotal, cancelled, change, farewellMessage);
                }
                return null;
            }
        }

        private Image ConvertImageFromBase64(string base64Image)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64Image);
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch
            {
                return null;
            }
        }

        private string ConvertImageToBase64(Image image)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    return Convert.ToBase64String(imageBytes);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
