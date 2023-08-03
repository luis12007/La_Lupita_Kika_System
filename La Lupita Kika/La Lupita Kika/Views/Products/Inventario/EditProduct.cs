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

namespace La_Lupita_Kika.Views.Products.Inventario
{
    public partial class EditProduct : Form
    {
        private Models.Products productselected = new Models.Products();
        private string ConnectionString;

        private MangoneadasRepository MangoneadasRepository;
        private PalettesRepository PalettesRepository;
        private SnowIceRepository SnowIceRepository;
        private CandyRepository CandyRepository;
        private OtherRepository OtherRepository;
        public EditProduct(string connectionString, Models.Products producto)
        {
            this.ConnectionString = connectionString;
            this.productselected = producto;
            this.MangoneadasRepository = new MangoneadasRepository(connectionString);
            this.PalettesRepository = new PalettesRepository(connectionString);
            this.SnowIceRepository = new SnowIceRepository(connectionString);
            this.CandyRepository = new CandyRepository(connectionString);
            this.OtherRepository = new OtherRepository(connectionString);
            InitializeComponent();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            NameUser_textBox.Texts = productselected.Nombre;
            Price_textbox.Texts = productselected.Valor.ToString();
            CodeBar_textBox.Texts = productselected.Codebar.ToString();
            Cuantity_texbox.Texts = productselected.Cantidad.ToString();
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {

            switch (productselected.Tipo.ToString())
            {
                case "Paletas":
                    if(PalettesRepository.FindByCodebar(productselected.Codebar) == null)
                    {
                        MessageBox.Show("Codigo ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    PalettesRepository.UpdatePalette(NameUser_textBox.Texts, float.Parse(Price_textbox.Texts)
                        , CodeBar_textBox.Texts, int.Parse(Cuantity_texbox.Texts),productselected.Subsidiary_id,productselected.Nombre);

                    break;

                case "Mangoneadas":
                    if (MangoneadasRepository.FindByCodebar(productselected.Codebar) == null)
                    {
                        MessageBox.Show("Codigo ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MangoneadasRepository.UpdateMangoneadas(NameUser_textBox.Texts, float.Parse(Price_textbox.Texts)
                        , CodeBar_textBox.Texts, int.Parse(Cuantity_texbox.Texts), productselected.Subsidiary_id, productselected.Nombre);

                    break;

                case "Helados":
                    if (SnowIceRepository.FindByCodebar(productselected.Codebar) == null)
                    {
                        MessageBox.Show("Codigo ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    SnowIceRepository.Updateplus(NameUser_textBox.Texts, float.Parse(Price_textbox.Texts)
                        , CodeBar_textBox.Texts, int.Parse(Cuantity_texbox.Texts), productselected.Subsidiary_id, productselected.Nombre);

                    break;

                case "Dulces":
                    if (CandyRepository.FindByCodebar(productselected.Codebar) == null)
                    {
                        MessageBox.Show("Codigo ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    CandyRepository.UpdateCandy(NameUser_textBox.Texts, float.Parse(Price_textbox.Texts)
                        , CodeBar_textBox.Texts, int.Parse(Cuantity_texbox.Texts), productselected.Subsidiary_id, productselected.Nombre);


                    break;

                case "Otros(snacks)":
                    if (OtherRepository.FindByCodebar(productselected.Codebar) == null)
                    {
                        MessageBox.Show("Codigo ya utilizado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    OtherRepository.UpdateOtherplus(NameUser_textBox.Texts, float.Parse(Price_textbox.Texts)
                        , CodeBar_textBox.Texts, int.Parse(Cuantity_texbox.Texts), productselected.Subsidiary_id, productselected.Nombre);

                    break;

                default:

                    break;
            }
            MessageBox.Show("Editado Exitosamente.", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
