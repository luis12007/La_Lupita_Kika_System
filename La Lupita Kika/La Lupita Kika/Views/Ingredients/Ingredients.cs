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

namespace La_Lupita_Kika.Views.Ingredients
{
    public partial class Ingredients : Form
    {
        private string ConnectionString;
        private SubsidiaryRepository SubsidiaryRepository;
        private IngredientsRepository IngredientsRepository;
        private List<Models.Ingredients> IngredientsList = new List<Models.Ingredients>();

        private string subsidiary = "Juayua";
        private int subsidiarynumber = 2;
        public Ingredients(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.SubsidiaryRepository = new SubsidiaryRepository(connectionString);
            this.IngredientsRepository = new IngredientsRepository(connectionString);
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            // Agregar las tres columnas al DataGridView y definir sus propiedades
            Ingredients_dataGridView.ColumnCount = 7;      // Columna para el nombre del producto
            Ingredients_dataGridView.Columns[0].Name = "Nombre";
            Ingredients_dataGridView.Columns[1].Name = "Precio";
            Ingredients_dataGridView.Columns[2].Name = "Codigo";
            Ingredients_dataGridView.Columns[3].Name = "Cantidad";
            Ingredients_dataGridView.Columns[4].Name = "Tipo";
            Ingredients_dataGridView.Columns[5].Name = "Sucursal";
            Ingredients_dataGridView.Columns[6].Name = "Categoria";



            // Ajustar el ancho de las columnas
            Ingredients_dataGridView.Columns["Nombre"].Width = 340;
            Ingredients_dataGridView.Columns["Precio"].Width = 115;
            Ingredients_dataGridView.Columns["Codigo"].Width = 140;
            Ingredients_dataGridView.Columns["Cantidad"].Width = 150;
            Ingredients_dataGridView.Columns["Tipo"].Width = 120;
            Ingredients_dataGridView.Columns["Sucursal"].Width = 120;
            Ingredients_dataGridView.Columns["Categoria"].Width = 120;

        }

        private async void Ingredients_Load(object sender, EventArgs e)
        {
            await LoadInventarioAsync();

            RefreshDGV();
        }
        private void RefreshDGV()
        {

            IngredientsList = IngredientsRepository.FindBySubsidiary(subsidiarynumber);

            Ingredients_dataGridView.Rows.Clear();

            string subsidiary = "juayua";
            float number = 0;
            string type;
            foreach (var palettec in IngredientsList)
            {
                if (palettec.Subsidiary_ID == 2)
                {
                    subsidiary = "Juayua";
                }
                else if (palettec.Subsidiary_ID == 1)
                {
                    subsidiary = "Sonsonate";
                }

                number = palettec.Unit;
                type = palettec.Type;

                if (palettec.Name == "Alguashte")
                {
                    number = number * 0.0326f;
                    type = "LIBRAS";
                }
                else if (palettec.Name == "Chile liquido")
                {
                    number = number * 0.003906f;
                    type = "GALON";
                }
                else if (palettec.Name == "Arrayán")
                {
                    number = number / 6f;
                    type = "LIBRAS";
                }
                else if (palettec.Name == "Servilleta")
                {
                    type = "PAQUETES";
                    number = number / 40f;
                }

                switch (type)
                {

                    case "TBSP":
                        number = number * 0.0326f;
                        type = "LIBRA";
                        break;

                    case "TBS":
                        number = number * 0.0326f;
                        type = "LIBRA";
                        break;

                    /*case "GRAMOS":
                        number = number * 0.0022f;
                        type = "LIBRA";
                        break;*/

                    default: break;
                }

                // Redondear el número a dos decimales
                float roundedNumber = (float)Math.Round(number, 2);

                // Si el número redondeado es 0.00, mostrar un decimal más
                if (roundedNumber == 0.00f)
                {
                    roundedNumber = (float)Math.Round(number, 4);
                }

                String[] row2 = { $"{palettec.Name}", $"{palettec.Price}", $"{palettec.Code}", $"{roundedNumber}", $"{type}", $"{subsidiary}", $"{palettec.Category}" };
                Ingredients_dataGridView.Rows.Add(row2);


                foreach (DataGridViewRow row in Ingredients_dataGridView.Rows)
                {
                    if (row.Cells[3].Value != null)
                    {
                        float roundedNumbers = float.Parse(row.Cells[3].Value.ToString());

                        if (roundedNumbers < 0)
                        {
                            row.Cells[Ingredients_dataGridView.Columns[3].Index].Style.ForeColor = Color.Red;
                        }
                    }
                }

                Ingredients_dataGridView.ClearSelection();

            }
        }

        private async Task LoadInventarioAsync()
        {
            List<Subsidiary> subsidiary = await SubsidiaryRepository.GetAllAsync();

            // Crear una lista que contenga los nombres de las subsidiarias
            List<string> subsidiaryNames = new List<string>();

            // Recorrer la lista de subsidiarias y agregar los nombres a la lista
            foreach (var sub in subsidiary)
            {
                subsidiaryNames.Add(sub.Name);
            }
            subsidiaryNames.Add("Todos");


            // Asignar la lista como fuente de datos del ComboBox
            Subsidiary_cbb.DataSource = subsidiaryNames;
            Subsidiary_cbb.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Subsidiary_cbb_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            subsidiary = Subsidiary_cbb.SelectedItem.ToString();
            subsidiarynumber = SubsidiaryRepository.FindIdByName(subsidiary);

            switch (subsidiary)
            {
                case "Sonsonate":
                    RefreshDGV();
                    break;

                case "Juayua":
                    RefreshDGV();
                    break;

                case "Todos":
                    //todas las sucursales
                    IngredientsList.Clear();
                    List<Models.Ingredients> ingredients = IngredientsRepository.FindBySubsidiary(1);
                    IngredientsList.AddRange(ingredients);


                    List<Models.Ingredients> ingredients2 = IngredientsRepository.FindBySubsidiary(2);
                    IngredientsList.AddRange(ingredients2);

                    Ingredients_dataGridView.Rows.Clear();


                    string subsidiary = "juayua";
                    float number = 0;
                    string type;
                    foreach (var palettec in IngredientsList)
                    {
                        if (palettec.Subsidiary_ID == 2)
                        {
                            subsidiary = "Juayua";
                        }
                        else if (palettec.Subsidiary_ID == 1)
                        {
                            subsidiary = "Sonsonate";
                        }

                        number = palettec.Unit;
                        type = palettec.Type;

                        if (palettec.Name == "Alguashte")
                        {
                            number = number * 0.0326f;
                            type = "LIBRAS";
                        }
                        else if (palettec.Name == "Chile liquido")
                        {
                            number = number * 0.003906f;
                            type = "GALON";
                        }
                        else if (palettec.Name == "Arrayán")
                        {
                            number = number / 6f;
                            type = "LIBRAS";
                        }
                        else if (palettec.Name == "Servilleta")
                        {
                            type = "PAQUETES";
                            number = number / 40f;
                        }

                        switch (type)
                        {

                            case "TBSP":
                                number = number * 0.0326f;
                                type = "LIBRA";
                                break;

                            case "TBS":
                                number = number * 0.0326f;
                                type = "LIBRA";
                                break;

                            /*case "GRAMOS":
                                number = number * 0.0022f;
                                type = "LIBRA";
                                break;*/

                            default: break;
                        }

                        // Redondear el número a dos decimales
                        float roundedNumber = (float)Math.Round(number, 2);

                        // Si el número redondeado es 0.00, mostrar un decimal más
                        if (roundedNumber == 0.00f)
                        {
                            roundedNumber = (float)Math.Round(number, 4);
                        }


                        String[] row2 = { $"{palettec.Name}", $"{palettec.Price}", $"{palettec.Code}", $"{roundedNumber}", $"{type}", $"{palettec.Subsidiary_ID}", $"{palettec.Category}" };
                        Ingredients_dataGridView.Rows.Add(row2);


                        foreach (DataGridViewRow row in Ingredients_dataGridView.Rows)
                        {
                            if (row.Cells[3].Value != null)
                            {
                                float roundedNumbers = float.Parse(row.Cells[3].Value.ToString());

                                if (roundedNumbers < 0)
                                {
                                    row.Cells[Ingredients_dataGridView.Columns[3].Index].Style.ForeColor = Color.Red;
                                }
                            }
                        }

                        Ingredients_dataGridView.ClearSelection();

                    }

                    return;
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string find = Find.Texts.ToString();

            IngredientsList = FindByName(IngredientsList, find);


            Ingredients_dataGridView.Rows.Clear();

            foreach (var palettec in IngredientsList)
            {
                String[] row2 = { $"{palettec.Name}", $"{palettec.Price}", $"{palettec.Code}", $"{palettec.Unit}", $"{palettec.Type}", $"{palettec.Subsidiary_ID}" };
                Ingredients_dataGridView.Rows.Add(row2);
                Ingredients_dataGridView.ClearSelection();

            }
            Find.Texts = "";
        }

        public List<Models.Ingredients> FindByName(List<Models.Ingredients> ingredientsList, string searchText)
        {
            List<Models.Ingredients> matchingIngredients = ingredientsList
                .Where(ingredient => ingredient.Name.Contains(searchText))
                .ToList();
            return matchingIngredients;
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            List<Models.Ingredients> updateList = GetIngredientsFromDataGridView(Ingredients_dataGridView);
            IngredientsRepository.EditIngredientsList(updateList);
            MessageBox.Show("Editados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private List<Models.Ingredients> GetIngredientsFromDataGridView(DataGridView dataGridView)
        {
            List<Models.Ingredients> ingredientsList = new List<Models.Ingredients>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    string name = row.Cells["Nombre"].Value.ToString();
                    string code = row.Cells["Codigo"].Value.ToString();
                    float price = float.Parse(row.Cells["Precio"].Value.ToString());
                    float unit = float.Parse(row.Cells["Cantidad"].Value.ToString());
                    string type = row.Cells["Tipo"].Value.ToString();
                    string Category = row.Cells["Categoria"].Value.ToString();
                    string subsidiary = (row.Cells["Sucursal"].Value.ToString());
                    int subsidiaryInt = 1;
                    if (subsidiary == "Juayua")
                    {
                        subsidiaryInt = 2;
                    }

                    Models.Ingredients ingredient = new Models.Ingredients(name, code, price, unit, type, subsidiaryInt, Category);
                    ingredientsList.Add(ingredient);
                }
            }

            return ingredientsList;
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddIngredients addIngredients = new AddIngredients(ConnectionString);
            addIngredients.ShowDialog();

            RefreshDGV();
            this.Show();
        }

        private void Find_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento Login_button_Click
                button2.PerformClick();
            }
        }
    }
}
