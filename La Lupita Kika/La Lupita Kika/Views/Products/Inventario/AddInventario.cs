using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Products.Inventario
{
    public partial class AddInventario : Form
    {
        private string Conection;
        private string type;
        private CategoryRepository categoryRepository;
        private CategoryCRepository categoryCRepository;
        private SubsidiaryRepository subsidiaryRepository;

        private MangoneadasRepository MangoneadasRepository;
        private PalettesRepository PalettesRepository;
        private SnowIceRepository SnowIceRepository;
        private CandyRepository CandyRepository;
        private OtherRepository OtherRepository;

        private string name;
        private string category;
        private string codebar;
        private float number;
        private float price;
        private string subsidiary;


        public AddInventario(string connection)
        {
            this.Conection = connection;
            this.categoryRepository = new CategoryRepository(connection);
            this.categoryCRepository = new CategoryCRepository(connection);
            this.subsidiaryRepository = new SubsidiaryRepository(connection);
            this.MangoneadasRepository = new MangoneadasRepository(connection);
            this.PalettesRepository = new PalettesRepository(connection);
            this.SnowIceRepository = new SnowIceRepository(connection);
            this.CandyRepository = new CandyRepository(connection);
            this.OtherRepository = new OtherRepository(connection);
            InitializeComponent();
        }

        private async void AddInventario_Load(object sender, EventArgs e)
        {
            await LoadInventarioAsync();
        }
        private async Task LoadInventarioAsync()
        {
            List<Subsidiary> subsidiary = await subsidiaryRepository.GetAllAsync();

            // Crear una lista que contenga los nombres de las subsidiarias
            List<string> subsidiaryNames = new List<string>();

            // Recorrer la lista de subsidiarias y agregar los nombres a la lista
            foreach (var sub in subsidiary)
            {
                subsidiaryNames.Add(sub.Name);
            }

            // Asignar la lista como fuente de datos del ComboBox
            Subsidiary_cbb.DataSource = subsidiaryNames;
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void type_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            type = type_cbb.SelectedItem.ToString();
            switch (type)
            {
                case "Paleta":
                    Name_textbox.Enabled = true;
                    Category_cbb.Enabled = true;
                    Price_textbox.Enabled = true;
                    Codebar_textbox.Enabled = true;
                    Number_textbox.Enabled = true;
                    Subsidiary_cbb.Enabled = true;
                    List<Category> categoriesList = categoryRepository.GetAll();

                    string[] categoryNames = new string[categoriesList.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < categoriesList.Count; i++)
                    {
                        categoryNames[i] = categoriesList[i].Name;
                    }

                    Category_cbb.DataSource = categoryNames;
                    Category_cbb.DisplayMember = "Seleccionar";

                    break;

                case "Mangonada":

                    Name_textbox.Enabled = true;
                    Category_cbb.Enabled = false;
                    Price_textbox.Enabled = true;
                    Codebar_textbox.Enabled = true;
                    Number_textbox.Enabled = true;
                    Subsidiary_cbb.Enabled = true;


                    break;



                case "Helados":
                    Name_textbox.Enabled = true;
                    Category_cbb.Enabled = false;
                    Price_textbox.Enabled = true;
                    Codebar_textbox.Enabled = true;
                    Number_textbox.Enabled = true;
                    Subsidiary_cbb.Enabled = true;

                    break;


                case "Dulces":
                    Name_textbox.Enabled = true;
                    Category_cbb.Enabled = true;
                    Price_textbox.Enabled = true;
                    Codebar_textbox.Enabled = true;
                    Number_textbox.Enabled = true;
                    Subsidiary_cbb.Enabled = true;
                    List<CategoryC> categoriesListc = categoryCRepository.GetAll();

                    string[] categoryNamesc = new string[categoriesListc.Count];

                    // Recorrer la lista de categorías y guardar los nombres en el arreglo de strings
                    for (int i = 0; i < categoriesListc.Count; i++)
                    {
                        categoryNamesc[i] = categoriesListc[i].Name;
                    }

                    Category_cbb.DataSource = categoryNamesc;
                    Category_cbb.DisplayMember = "Seleccionar";

                    break;

                case "Otros(Snacks)":
                    Name_textbox.Enabled = true;
                    Category_cbb.Enabled = false;
                    Price_textbox.Enabled = true;
                    Codebar_textbox.Enabled = true;
                    Number_textbox.Enabled = true;
                    Subsidiary_cbb.Enabled = true;

                    break;


                default:
                    break;

            }
        }

        private void Number_textbox__TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            if (type_cbb.Texts == "Seleccionar")
            {
                return;
            }
            type = type_cbb.Texts.ToString();
            if (Name_textbox.Texts == "" ||
                Price_textbox.Texts == "" ||
                Number_textbox.Texts == "" ||
                Codebar_textbox.Texts == "")
            {
                MessageBox.Show("Llenar todos los campos.", "Precaución", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            name = Name_textbox.Texts;
            category = Category_cbb.SelectedItem.ToString();
            price = float.Parse(Price_textbox.Texts);
            number = float.Parse(Number_textbox.Texts);
            codebar = Codebar_textbox.Texts;
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            int subsidiarynumber = subsidiaryRepository.FindIdByName(subsidiary); ;
            switch (type)
            {
                case "Paleta":
                    //get ids
                    int categorynumber = categoryRepository.FindIdByName(category);
                    Models.Palettes palettes = new Models.Palettes(name, categorynumber, price, codebar, codebar, number, subsidiarynumber);
                    PalettesRepository.Add(palettes);
                    MessageBox.Show("Guardado con exitosamente.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "Mangonada":
                    Mangoneadas mangoneada = new Mangoneadas(name, price, codebar, codebar, 5, number, subsidiarynumber);
                    MangoneadasRepository.Add(mangoneada);
                    MessageBox.Show("Guardado con exitosamente.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;



                case "Helados":
                    SnowIce snow = new SnowIce(name, price, codebar, number, subsidiarynumber);
                    SnowIceRepository.Add(snow);
                    MessageBox.Show("Guardado con exitosamente.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "Dulces":
                    int categoryCnumber = categoryCRepository.FindIdByName(category);
                    Candy candy = new Candy(name, categoryCnumber, price, codebar, subsidiarynumber, number);
                    CandyRepository.Add(candy);
                    MessageBox.Show("Guardado con exitosamente.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;

                case "Otros(Snacks)":
                    Other other = new Other(name, price, codebar, number, subsidiarynumber);
                    OtherRepository.AddOther(other);
                    MessageBox.Show("Guardado con exitosamente.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;


                default:
                    MessageBox.Show("No agregado .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;


            }
            this.Close();
        }
    }
}
