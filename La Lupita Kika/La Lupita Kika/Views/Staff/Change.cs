using La_Lupita_Kika.Models;
using La_Lupita_Kika.UserRepository;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace La_Lupita_Kika.Views.Staff
{
    public partial class change : Form
    {
        private string connectionString;
        private float money;
        private List<Models.Products> productosList = new List<Models.Products>();
        private string CashierName;
        private float Subtotal;
        private float Cancelled;
        private float Change;
        private string FarewellMessage;

        //for algorith
        private float Onecent = 0.01f;
        private float Fivecent = 0.05f;
        private float Tencent = 0.1f;
        private float Twentyfivetencent = 0.25f;
        private int Onedolar = 1;
        private int Fivedolar = 5;
        private int Tendolar = 10;
        private int Twentydolar = 20;
        private int Fiftydolar = 50;
        private int Hundreddolar = 100;


        private int thisregis;
        private float cancelled;
        private float mounts;

        private UserRepository.UserRepository userrepo;
        private RegisterRepository registerrepo;
        private TicketRepository ticketrepo;
        private Ticket ticket = new Ticket();

        public change(String connectionString, float mount, List<Models.Products> productosList, int thisregis, float Cancelled, float mounts)
        {
            this.cancelled = Cancelled;
            this.thisregis = thisregis;
            this.connectionString = connectionString;
            this.money = mount;
            this.mounts = mounts;
            this.registerrepo = new RegisterRepository(connectionString);
            this.userrepo = new UserRepository.UserRepository(connectionString);
            this.ticketrepo = new TicketRepository(connectionString);
            InitializeComponent();
            this.productosList = productosList;
        }

        private void change_Load(object sender, EventArgs e)
        {
            //entender el cambio
            // Convertir las denominaciones a su valor en centavos
            int totalAmountInCents = (int)(money * 100);

            // Crear un arreglo para almacenar el resultado óptimo
            int[] dp = new int[totalAmountInCents + 1];
            int[] lastCoinUsed = new int[totalAmountInCents + 1];

            // Inicializar el arreglo dp con un valor alto para representar infinito
            for (int i = 1; i <= totalAmountInCents; i++)
            {
                dp[i] = int.MaxValue;
            }

            // Recorrer todas las denominaciones y actualizar el arreglo dp
            // con el número mínimo de monedas/billetes requeridos para dar el vuelto
            if (Onecent > 0)
            {
                for (int i = 1; i <= totalAmountInCents; i++)
                {
                    if (i >= (Onecent * 100) && dp[i] > dp[i - (int)(Onecent * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Onecent * 100)] + 1;
                        lastCoinUsed[i] = 1; // 1 representa el valor de 1 centavo
                    }
                }
            }
            if (Fivecent > 0)
            {
                for (int i = 5; i <= totalAmountInCents; i++)
                {
                    if (i >= (Fivecent * 100) && dp[i] > dp[i - (int)(Fivecent * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Fivecent * 100)] + 1;
                        lastCoinUsed[i] = 5; // 5 representa el valor de 5 centavos
                    }
                }
            }
            if (Tencent > 0)
            {
                for (int i = 10; i <= totalAmountInCents; i++)
                {
                    if (i >= (Tencent * 100) && dp[i] > dp[i - (int)(Tencent * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Tencent * 100)] + 1;
                        lastCoinUsed[i] = 10; // 10 representa el valor de 10 centavos
                    }
                }
            }
            if (Twentyfivetencent > 0)
            {
                for (int i = 25; i <= totalAmountInCents; i++)
                {
                    if (i >= (Twentyfivetencent * 100) && dp[i] > dp[i - (int)(Twentyfivetencent * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Twentyfivetencent * 100)] + 1;
                        lastCoinUsed[i] = 25; // 25 representa el valor de 25 centavos
                    }
                }
            }
            if (Onedolar > 0)
            {
                for (int i = 100; i <= totalAmountInCents; i++)
                {
                    if (i >= (Onedolar * 100) && dp[i] > dp[i - (int)(Onedolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Onedolar * 100)] + 1;
                        lastCoinUsed[i] = 100; // 100 representa el valor de 1 dólar
                    }
                }
            }
            if (Fivedolar > 0)
            {
                for (int i = 500; i <= totalAmountInCents; i++)
                {
                    if (i >= (Fivedolar * 100) && dp[i] > dp[i - (int)(Fivedolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Fivedolar * 100)] + 1;
                        lastCoinUsed[i] = 500; // 500 representa el valor de 5 dólares
                    }
                }
            }
            if (Tendolar > 0)
            {
                for (int i = 1000; i <= totalAmountInCents; i++)
                {
                    if (i >= (Tendolar * 100) && dp[i] > dp[i - (int)(Tendolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Tendolar * 100)] + 1;
                        lastCoinUsed[i] = 1000; // 1000 representa el valor de 10 dólares
                    }
                }
            }
            if (Twentydolar > 0)
            {
                for (int i = 2000; i <= totalAmountInCents; i++)
                {
                    if (i >= (Twentydolar * 100) && dp[i] > dp[i - (int)(Twentydolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Twentydolar * 100)] + 1;
                        lastCoinUsed[i] = 2000; // 2000 representa el valor de 20 dólares
                    }
                }
            }
            if (Fiftydolar > 0)
            {
                for (int i = 5000; i <= totalAmountInCents; i++)
                {
                    if (i >= (Fiftydolar * 100) && dp[i] > dp[i - (int)(Fiftydolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Fiftydolar * 100)] + 1;
                        lastCoinUsed[i] = 5000; // 5000 representa el valor de 50 dólares
                    }
                }
            }
            if (Hundreddolar > 0)
            {
                for (int i = 10000; i <= totalAmountInCents; i++)
                {
                    if (i >= (Hundreddolar * 100) && dp[i] > dp[i - (int)(Hundreddolar * 100)] + 1)
                    {
                        dp[i] = dp[i - (int)(Hundreddolar * 100)] + 1;
                        lastCoinUsed[i] = 10000; // 10000 representa el valor de 100 dólares
                    }
                }
            }

            // Reconstruir la solución óptima y mostrar el resultado
            List<int> changeList = new List<int>();
            int remainingAmount = totalAmountInCents;
            while (remainingAmount > 0)
            {
                int coinUsed = lastCoinUsed[remainingAmount];
                changeList.Add(coinUsed);
                remainingAmount -= coinUsed;
            }

            // imprimiendo en pantalla 

            // Variables para posicionar las etiquetas e imágenes
            int x = 10; // Iniciar desde la posición 10 en el eje X
            int y = (this.Height / 2) - 30; // En la mitad de la altura del formulario
            int maxXInLine = 0; // Iniciar la posición máxima en la línea actual

            foreach (int coin in changeList)
            {
                // Agregar el Label
                Label label = new Label();
                label.AutoSize = true;
                label.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

                // Determinar si la etiqueta se desbordará en la línea actual
                if (x + label.Width > this.Width - 10)
                {
                    // Saltar de línea, reiniciar posición x e incrementar posición y
                    x = 10;
                    y += 60;
                }

                // Determinar qué imagen usar según el valor del vuelto
                string imageName = coin >= 100 ? "dolar" : "Coin";

                // Agregar el PictureBox con la imagen
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(imageName); // Asignar la imagen desde los recursos
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

                // Colocar debajo del label
                pictureBox.Location = new System.Drawing.Point(x, y + label.Height + 10);
                this.Controls.Add(pictureBox);

                // Modificar el contenido del label según el valor del vuelto
                if (coin >= 100)
                {
                    // Si el valor es mayor o igual a 1, mantener el valor original
                    label.Text = (coin / 100).ToString();
                }
                else
                {
                    // Si el valor es menor a 1, multiplicar por 100 y mostrar como entero
                    label.Text = (coin * 1).ToString();
                }

                label.Location = new System.Drawing.Point(x, y);
                this.Controls.Add(label);

                // Actualizar la posición máxima en la línea actual
                if (pictureBox.Location.X + pictureBox.Width > maxXInLine)
                {
                    maxXInLine = pictureBox.Location.X + pictureBox.Width;
                }

                // Mover la posición x de la etiqueta y el pictureBox para la siguiente iteración
                x = maxXInLine + 12;
            }


            //-----------------------------------------------------
            Change_texbox.Texts = money.ToString();
            Register regis = registerrepo.GetById(thisregis);
            User myuser = userrepo.GetUserById(regis.User_id);
            CashierName = myuser.Name;
            // this.Hide();
            int ticketNumber = ticketrepo.GetAll().Count;
            DateTime currentDate = DateTime.Now;
            //generando ticket

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
            ticket.Cancelled = cancelled;
            ticket.Change = money;
            ticket.FarewellMessage = "VIVA LA VIDA";
            ticket.Number = ticketNumber + 1;
            ticket.Items = productosList.Count;

            ticketrepo.Add(ticket);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {

            ticket.imprimir(ticket);


            this.Close();

        }
    }
}
