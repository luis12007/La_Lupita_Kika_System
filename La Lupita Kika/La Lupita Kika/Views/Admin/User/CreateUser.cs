using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views
{
    public partial class CreateUser : Form
    {
        private string connectionString;
        private UserRepository.UserRepository Userrepo;
        private RolRepository RolRepository;
        public CreateUser(string connectionString)
        {
            this.connectionString = connectionString;
            this.Userrepo = new UserRepository.UserRepository(connectionString); // Inicializar el repositorio aquí
            this.RolRepository = new UserRepository.RolRepository(connectionString);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddUser_button_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string name = NameUser_textBox.Text;
            string password = PasswordUser_textBox.Text;
            string username = Username_textBox.Text;
            string mail = MailUser_textBox.Text;
            string roleName = RolUser_comboBox.SelectedItem.ToString();

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(roleName))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Obtener el ID del rol seleccionado
                int roleId = RolRepository.GetRoleIdByName(roleName);

                // Crear una instancia del objeto User con los datos ingresados por el usuario
                User newUser = new User
                {
                    Name = name,
                    Password = password,
                    Username = username,
                    Mail = mail,
                    Rol_id = roleId
                };

                // Agregar el usuario utilizando el repositorio
                Userrepo.Add(newUser);

                MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
