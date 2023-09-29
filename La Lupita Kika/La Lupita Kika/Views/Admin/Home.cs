using Google.Protobuf.WellKnownTypes;
using La_Lupita_Kika.UserRepository;
using La_Lupita_Kika.Views.Admin.AddProduct;
using La_Lupita_Kika.Views.Admin.User;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Windows.Forms;


namespace La_Lupita_Kika.Views
{
    public partial class Home : Form
    {
        private IngredientsRepository ingredientsrepo;
        private List<Models.Ingredients> ingredientlist = new List<Models.Ingredients>();
        private List<Models.Ingredients> ingredientsFaltantes = new List<Models.Ingredients>();
        private List<Models.Products> products = new List<Models.Products>();

        private string connectionString;


        private int pendulumCount = 0;
        private int totalPendulumCount = 8; // Realizar 8 oscilaciones en total (4 veces a cada lado)
        private System.Windows.Forms.Timer animationTimer = new System.Windows.Forms.Timer();
        private int animationDuration = 3000; // 3 segundos
        private int animationStep = 10; // Píxeles para cada paso de la animación


        public Home(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeComponent();
            this.ingredientsrepo = new IngredientsRepository(connectionString);

            //animation
            animationTimer.Interval = animationStep;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        //animation
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (pendulumCount < totalPendulumCount)
            {
                int offset = animationStep * (pendulumCount % 2 == 0 ? 1 : -1);
                ringBell_btn.Left += offset;

                pendulumCount++;

                if (pendulumCount == totalPendulumCount)
                {
                    animationTimer.Stop();
                    pendulumCount = 0;
                }
            }
        }

        private void ringBell_btn_Click(object sender, EventArgs e)
        {
            if (!animationTimer.Enabled)
            {
                animationTimer.Start();
            }
        }
        //animation

        private void Home_Load(object sender, EventArgs e)
        {
            ingredientlist = ingredientsrepo.GetAll();


            foreach (var producto in ingredientlist)
            {
                switch (producto.Category)
                {

                    case "Emboltorio":
                        switch (producto.Code.ToUpper())
                        {
                            case "E001":
                                if (producto.Unit <= 480)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "E002":
                                if (producto.Unit <= 480)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "E003":
                                if (producto.Unit <= 400)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "E004":
                                if (producto.Unit <= 50)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "E005":
                                if (producto.Unit <= 400)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "E006":
                                if (producto.Unit <= 500)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;

                            default: break;
                        }
                        break;
                    case "Fruta":
                        switch (producto.Code.ToUpper())
                        {
                            case "FR001":
                                if (producto.Unit <= 20)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR002":
                                if (producto.Unit <= 50)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR003":
                                if (producto.Unit <= 50)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR004":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR005":
                                if (producto.Unit <= 30)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR006":
                                if (producto.Unit <= 5)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR007":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR008":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR009":
                                if (producto.Unit <= 5)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR010":
                                if (producto.Unit <= 300)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR011":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR012":
                                if (producto.Unit <= 25)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR013":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR014":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR015":
                                if (producto.Unit <= 10)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR016":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR017":
                                if (producto.Unit <= 3)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "FR018":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case "Ingredientes":
                        switch (producto.Code.ToUpper())
                        {
                            case "I001":
                                if (producto.Unit <= 20)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I002":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I003":
                                if (producto.Unit <= 10)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I004":
                                if (producto.Unit <= 40)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I005":
                                if (producto.Unit <= 5)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I006":
                                if (producto.Unit <= 15)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I007":
                                if (producto.Unit <= 10)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I008":
                                if (producto.Unit <= 5)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I009":
                                if (producto.Unit <= 6)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I010":
                                if (producto.Unit <= 4)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I011":
                                if (producto.Unit <= 1)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I012":
                                if (producto.Unit <= 20)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I013":
                                if (producto.Unit <= 8)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I014":
                                if (producto.Unit <= 10)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I015":
                                if (producto.Unit <= 90)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I016":

                                if (producto.Unit <= 2)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I017":
                                if (producto.Unit <= 20)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I018":
                                if (producto.Unit <= 12)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I019":
                                if (producto.Unit <= 20)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I020":
                                if (producto.Unit <= 6)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I021":
                                if (producto.Unit <= 2)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I022":
                                if (producto.Unit <= 4)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I023":
                                if (producto.Unit <= 40)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I024":
                                if (producto.Unit <= 200)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            case "I025":
                                if (producto.Unit <= 200)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            default:
                                break;

                        }


                        break;
                    case "Stickers":
                        switch (producto.Code.ToUpper())
                        {
                            case "SC01":
                            case "SC02":
                            case "SC03":
                            case "SC04":
                            case "SC05":
                            case "SC06":
                            case "SC07":
                            case "SC08":
                            case "SP01":
                            case "SP02":
                            case "SP03":
                            case "SP04":
                            case "SP05":
                            case "SP06":
                            case "SP07":
                            case "SP08":
                            case "SP09":
                            case "SP10":
                            case "SF01":
                            case "SF02":
                            case "SF03":
                            case "SL01":
                            case "SL02":
                            case "SL03":
                            case "SL04":
                            case "SC09":
                            case "SM03":
                            case "SM04":
                            case "SM05":
                            case "SM06":
                            case "SM07":
                            case "SM08":
                            case "SM09":
                            case "SM10":
                            case "SM11":
                            case "SM01":
                            case "SM02":
                                if (producto.Unit <= 40)
                                {
                                    ingredientsFaltantes.Add(producto);
                                }
                                break;
                            default:
                                break;
                        }

                        break;

                    default: break;
                }


            }
            ringBell_btn.Visible = false;
            Alert_Button.Visible = false;
            Alert_Button.Enabled = false;
            if (!ingredientsFaltantes.IsNullOrEmpty())
            {
                Alert_Button.Visible = true;
                Alert_Button.Enabled = true;
                ringBell_btn.Visible = true;
            }

        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            this.Close();

            Application.Exit();

        }


        private void Palletes_button_Click(object sender, EventArgs e)
        {
            this.Hide();



            // Abrir el nuevo formulario de facturación
            Products.Palettes.Inventario formFacturation = new Products.Palettes.Inventario(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Add_button_MouseHover(object sender, EventArgs e)
        {
        }

        private void Users_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            UserList formFacturation = new UserList(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Add_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            AddProducts formFacturation = new AddProducts(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Alert_Button_Click(object sender, EventArgs e)
        {
            this.Hide();

            foreach (var item in ingredientsFaltantes)
            {
                Models.Products productsfaltantes = new Models.Products(item.Name,
                                    item.Subsidiary_ID, item.Unit, item.Type, $"none");
                products.Add(productsfaltantes);
            }

            // Abrir el nuevo formulario de facturación
            Warning formFacturation = new Warning(connectionString, products, "Pocos Ingredientes en stock");
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Gains_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Gains formFacturation = new Gains(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void Ingredients_button_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Abrir el nuevo formulario de facturación
            Ingredients.Ingredients formFacturation = new Ingredients.Ingredients(connectionString);
            formFacturation.ShowDialog();

            // Mostrar nuevamente el formulario actual cuando se cierre el formulario de facturación
            this.Show();
        }

        private void ringBell_btn_Click_1(object sender, EventArgs e)
        {

            if (!animationTimer.Enabled)
            {
                animationTimer.Start();
            }
        }
    }
}
