using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class User
    {
        public int User_id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        public int Rol_id { get; set; }

        public User() { }

        public User(int userId, string name, string password, string username, string mail, int rolId)
        {
            User_id = userId;
            Name = name;
            Password = password;
            Username = username;
            Mail = mail;
            Rol_id = rolId;
        }
    }
}
