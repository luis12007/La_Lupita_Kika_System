using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Staff
{
    public partial class Mount : Form
    {
        private string connectionString;
        private float moneyChange;
        private float mounts;
        private float mountstext;
        private string CashierName;


        // repos and lists
        private List<Models.Products> productosList = new List<Models.Products>(); // Lista de productos
        private int thisregis;
        private RegisterRepository registerrepo;
        private TicketRepository ticketrepo;
        private Ticket ticket = new Ticket();
        private UserRepository.UserRepository userrepo;
        private int subsidiary;

        private CandyRepository candysrepo;
        private OtherRepository otherrepo;
        private PalettesRepository palettesrepo;
        private SnowIceRepository snowicerepo;
        private MangoneadasRepository mangoneadasrepo;
        private SalesRepository salesrepo;
        private RegisterXSalesRepository registerXSalesrepo;
        public Mount(String connectionString, float mount, List<Models.Products> productosList, int thisregis, int subsidiary)
        {
            this.thisregis = thisregis;
            this.connectionString = connectionString;
            this.mounts = mount;
            InitializeComponent();
            this.productosList = productosList;
            this.ticketrepo = new TicketRepository(connectionString);
            this.registerrepo = new RegisterRepository(connectionString);
            this.userrepo = new UserRepository.UserRepository(connectionString);
            this.candysrepo = new CandyRepository(connectionString);
            this.otherrepo = new OtherRepository(connectionString);
            this.palettesrepo = new PalettesRepository(connectionString);
            this.snowicerepo = new SnowIceRepository(connectionString);
            this.mangoneadasrepo = new MangoneadasRepository(connectionString);
            this.salesrepo = new SalesRepository(connectionString);
            this.registerXSalesrepo = new RegisterXSalesRepository(connectionString);
            this.subsidiary = subsidiary;
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void Mount_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {

            if (textBox.Texts != "")
            {
                mountstext = float.Parse(textBox.Texts);
                moneyChange = mountstext - mounts;

                if (moneyChange < 0)
                {
                    MessageBox.Show("Ingrese un numero mayor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                float money = (float)Math.Round(moneyChange, 3);
                // Abrir el nuevo formulario de facturación
                //Staff.change formFacturation = new Staff.change(connectionString, money, productosList, thisregis, mountstext, mounts);
                //formFacturation.ShowDialog();

                //
                //Change_texbox.Texts = money.ToString();
                Register regis = registerrepo.GetById(thisregis);
                User myuser = userrepo.GetUserById(regis.User_id);
                CashierName = myuser.Name;
                // this.Hide();
                int ticketNumber = ticketrepo.GetAll().Count;
                DateTime currentDate = DateTime.Now;

                //generando ticket//

                ticket.Image = PictureBoxLogo.Image;
                ticket.Title = "La LupitaKika Sonsonate";
                ticket.Address = "";
                ticket.DateTicket = currentDate.Date;
                ticket.TimeTicket = currentDate.TimeOfDay;
                ticket.CashierName = myuser.User_id.ToString();
                foreach (Models.Products producto in productosList)
                {
                    ticket.ProductsLists.Add(producto);
                }
                ticket.Subtotal = mounts;
                ticket.Cancelled = mountstext;
                ticket.Change = money;
                ticket.FarewellMessage = "VIVA LA VIDA";
                ticket.Number = ticketNumber + 1;
                ticket.Items = productosList.Count;

                ticketrepo.Add(ticket);
                //

                ticket.imprimir(ticket);


                // Supongamos que tienes una instancia del repositorio SalesRepository llamada salesrepo
                foreach (var producto in productosList)
                {
                    switch (producto.Tipo)
                    {
                        case "candy":
                            candysrepo.UpdateCuantityByCodebarMinus(producto.Codebar, (int)producto.Cantidad, subsidiary);
                            break;

                        case "other":
                            otherrepo.UpdateCuantityByCodebarMinus(producto.Codebar, (int)producto.Cantidad, subsidiary);
                            break;

                        case "Mangoneada":
                            mangoneadasrepo.UpdateCuantityByCodebarMinus(producto.Codebar, (int)producto.Cantidad, subsidiary);
                            break;

                        case "palette":
                            palettesrepo.UpdateCuantityByCodebarmin(producto.Codebar, (int)producto.Cantidad, subsidiary);
                            break;

                        case "snowice":
                            snowicerepo.IncrementCuantityByCodebarMinus(producto.Codebar, (int)producto.Cantidad, subsidiary);
                            break;

                        default:
                            break;
                    }


                    int registers = thisregis;
                    // Obtener los datos de cada producto en la lista
                    string nombre = producto.Nombre;
                    float cantidad = producto.Cantidad;
                    float precio = producto.Valor;


                    // Llamar al método Add del repositorio SalesRepository para guardar los datos en la base de datos
                    Sales sales = new Sales(nombre, cantidad, precio);
                    salesrepo.Add(sales);


                    List<Sales> salesList = salesrepo.GetAll();
                    Sales foundSales = salesList.Find(sales => sales.Name.Equals(nombre) && sales.Lot.Equals(cantidad));

                    // Obtener el ID del objeto Sales encontrado
                    int foundId = foundSales != null ? foundSales.Id : -1;

                    if (foundId != -1)
                    {
                        Registerxsales register = new Registerxsales(registers, foundId);
                        registerXSalesrepo.Add(register);
                    }


                }






                this.Close();

            }
            else
            {
                MessageBox.Show("Campos vacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox__TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Space)
            {
                // Llamar al evento Login_button_Click
                button_Click(sender, e);
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                // Llamar al evento Login_button_Click
                button_Click(sender, e);
            }
        }
    }
}
