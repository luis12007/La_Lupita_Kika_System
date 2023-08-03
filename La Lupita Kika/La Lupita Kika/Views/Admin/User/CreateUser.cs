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
        private SubsidiaryRepository SubsidiaryRepository;
        public CreateUser(string connectionString)
        {
            this.connectionString = connectionString;
            this.Userrepo = new UserRepository.UserRepository(connectionString); // Inicializar el repositorio aquí
            this.RolRepository = new UserRepository.RolRepository(connectionString);
            this.SubsidiaryRepository = new SubsidiaryRepository(connectionString);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddUser_button_Click(object sender, EventArgs e)
        {

        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            List<Rol> rollist = RolRepository.GetAll();
            string[] RolNames = new string[rollist.Count];

            for (int i = 0; i < rollist.Count; i++)
            {
                RolNames[i] = rollist[i].Name;
            }

            RolUser_comboBox.DataSource = RolNames;
            RolUser_comboBox.DisplayMember = "Seleccionar";

            List<Subsidiary> placeList = SubsidiaryRepository.GetAll();
            string[] placeListNames = new string[placeList.Count];

            for (int i = 0; i < placeList.Count; i++)
            {
                placeListNames[i] = placeList[i].Name;
            }

            Place_cbb.DataSource = placeListNames;
            Place_cbb.DisplayMember = "Seleccionar";
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string name = NameUser_textBox.Texts;
            string password = PasswordUser_textBox.Texts;
            string username = Username_textBox.Texts;
            string mail = MailUser_textBox.Texts;
            string roleName = RolUser_comboBox.SelectedItem.ToString();
            string place = Place_cbb.SelectedItem.ToString();

            // Verificar que los campos no estén vacíos
            if (string.IsNullOrEmpty(name)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(username)
                || string.IsNullOrEmpty(mail)
                || string.IsNullOrEmpty(roleName)
                || string.IsNullOrEmpty(place))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            User user = Userrepo.GetUserByUsername(username);

            if (user != null)
            {
                MessageBox.Show("Username no disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear una instancia del objeto User con los datos ingresados por el usuario
            User newUser = new User
            {
                Name = name,
                Password = password,
                Username = username,
                Mail = mail,
                Rol_id = RolRepository.FindIdByName(roleName),
                Subsidiary_ID = SubsidiaryRepository.FindIdByName(roleName)
            };

            // Agregar el usuario utilizando el repositorio
            Userrepo.Add(newUser);

            MessageBox.Show("Usuario agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NameUser_textBox__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
