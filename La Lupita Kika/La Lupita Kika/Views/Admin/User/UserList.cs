using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views.Admin.AddProduct;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Admin.User
{
    public partial class UserList : Form
    {
        private string ConnectionString;
        private UserRepository.UserRepository userrepo;
        private string UserSelected = "none";
        private RolRepository rolrepository;
        private SubsidiaryRepository subsidiaryrepo;
        public UserList(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.userrepo = new UserRepository.UserRepository(connectionString);
            this.rolrepository = new RolRepository(connectionString);
            this.subsidiaryrepo = new SubsidiaryRepository(connectionString);
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Userlist_dataGridView.ColumnCount = 6;      // Columna para el nombre del producto
            Userlist_dataGridView.Columns[0].Name = "Nombre";
            Userlist_dataGridView.Columns[1].Name = "Contraseña";
            Userlist_dataGridView.Columns[2].Name = "Correo";
            Userlist_dataGridView.Columns[3].Name = "Username";
            Userlist_dataGridView.Columns[4].Name = "Rol";
            Userlist_dataGridView.Columns[5].Name = "Sucursal";



            // Ajustar el ancho de las columnas
            Userlist_dataGridView.Columns["Nombre"].Width = 220;
            Userlist_dataGridView.Columns["Contraseña"].Width = 130;
            Userlist_dataGridView.Columns["Correo"].Width = 220;
            Userlist_dataGridView.Columns["Username"].Width = 112;
            Userlist_dataGridView.Columns["Rol"].Width = 75;
            Userlist_dataGridView.Columns["Sucursal"].Width = 120;

        }

        private void RefreshDGV()
        {
            List<Models.User> users = userrepo.GetAll();

            Userlist_dataGridView.Rows.Clear();

            string rol = "Staff";
            string Surucsal = "Sonsonate";
            foreach (var palettec in users)
            {

                rol = rolrepository.GetNameById(palettec.Rol_id);
                Surucsal = subsidiaryrepo.FindNameById(palettec.Subsidiary_ID);
                String[] row2 = { palettec.Name, $"{palettec.Password}", $"{palettec.Mail}", palettec.Username, $"{rol}", $"{Surucsal}" };
                Userlist_dataGridView.Rows.Add(row2);
                Userlist_dataGridView.ClearSelection();

            }
        }
        private void UserList_Load(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Abrir el nuevo formulario de facturación
            CreateUser formFacturation = new CreateUser(ConnectionString);
            formFacturation.ShowDialog();
            RefreshDGV();
            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();

        }

        private void Userlist_dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verificar que se haya hecho clic en una fila válida
            {
                // Obtener el valor de la celda correspondiente al nombre (suponiendo que está en la primera columna)
                DataGridViewRow row = Userlist_dataGridView.Rows[e.RowIndex];
                UserSelected = row.Cells["Username"].Value.ToString();
            }
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            if (UserSelected == "none")
            {
                MessageBox.Show("Ningun usuario seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("¿Deseas eliminar el usuario?", "Confirmar eliminación", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                userrepo.DeleteByUsername(UserSelected);
                RefreshDGV();
                UserSelected = "none";
            }

        }

        private void Userlist_dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();

            Models.User thisuser = userrepo.GetUserByUsername(UserSelected);

            EditUser formFacturation = new EditUser(ConnectionString, thisuser);
            formFacturation.ShowDialog();
            RefreshDGV();
            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }
    }
}
