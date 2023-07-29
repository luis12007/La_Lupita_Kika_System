using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Lupita_Kika.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Image Image { get; set; } // Imagen del ticket (puedes usar byte[] para almacenar la imagen como arreglo de bytes)
        public string Title { get; set; } // Título del ticket
        public string Address { get; set; } // Dirección del establecimiento
        public DateTime DateTicket { get; set; } // Fecha del ticket
        public TimeSpan TimeTicket { get; set; } // Hora del ticket
        public string CashierName { get; set; } // Nombre del cajero

        public int Number { get; set; }

        public int Items { get; set; }

        public List<Models.Products> ProductsLists = new List<Models.Products>();  // Lista de productos (usando la clase Product que ya tienes)
        public float Subtotal { get; set; } // Subtotal del ticket
        public float Cancelled { get; set; } // Indicador de si el ticket está cancelado
        public float Change { get; set; } // Monto del cambio
        public string FarewellMessage { get; set; } // Mensaje de despedida en el ticket


        private PrintDocument doc = new PrintDocument();
        private PrintPreviewDialog vista = new PrintPreviewDialog();

        public Ticket() { }

        // Constructor completo que toma todos los campos como parámetros, incluida la lista de productos
        public Ticket(int id, Image image, string title, string address, DateTime dateTicket, TimeSpan timeTicket,
            string cashierName, List<Models.Products> productsLists, float subtotal, float cancelled, float change, string farewellMessage)
        {
            Id = id;
            Image = image;
            Title = title;
            Address = address;
            DateTicket = dateTicket;
            TimeTicket = timeTicket;
            CashierName = cashierName;
            ProductsLists = productsLists;
            Subtotal = subtotal;
            Cancelled = cancelled;
            Change = change;
            FarewellMessage = farewellMessage;
        }


        // Otros campos relacionados con el ticket
        // Constructor que toma todos los campos como parámetros
        public Ticket(Image image, string title, string address, DateTime dateTicket, TimeSpan timeTicket, string cashierName
            , List<Products> productsLists, float subtotal, float cancelled, float change, string farewellMessage, int number, int items)
        {
            Image = image;
            Title = title;
            Address = address;
            DateTicket = dateTicket;
            TimeTicket = timeTicket;
            CashierName = cashierName;
            ProductsLists = productsLists;
            Subtotal = subtotal;
            Cancelled = cancelled;
            Change = change;
            FarewellMessage = farewellMessage;
            Number = number;
            Items = items;
        }
        public void imprimir(Ticket p)
        {
            int numerio = 3;
            doc.PrinterSettings.PrinterName = doc.DefaultPageSettings.PrinterSettings.PrinterName;
            doc.PrintPage += new PrintPageEventHandler(imprimeticket);
            vista.Document = doc;
            //vista.Show();
            doc.Print();
        }

        public void imprimeticket(object sender, PrintPageEventArgs e) {

            int posX, posY;
            Font fuente = new Font("consola" ,8 ,FontStyle.Bold );
            string date = DateTicket.ToString();
            string datecut = date.Substring(0, 10);
            string time = TimeTicket.ToString();
            string timecut = time.Substring(0, 5);
            try
            {
                posX = 10;
                posY = 10;
                e.Graphics.DrawImage(Image, 140, 15, 100, 100);
                posY = posY + 110;
                posX = 150;
                e.Graphics.DrawString(Title, fuente, Brushes.Black, posX, posY);
                posX = 10;
                posY = posY + 20;
                e.Graphics.DrawString("-------------------------------------------------------------" +
                    "---------------------", fuente, Brushes.Black, posX, posY);
                posY =posY+ 20;
                posX = 110;
                e.Graphics.DrawString(Address, fuente, Brushes.Black, posX, posY);
                posY = posY + 20;
                posX = 10;
                e.Graphics.DrawString("-------------------------------------------------------------" +
                    "---------------------", fuente, Brushes.Black, posX, posY);
                posY = posY + 20;

                e.Graphics.DrawString("Fecha: "+ datecut, fuente, Brushes.Black, posX, posY);
                posX = posX + 130;
                e.Graphics.DrawString("Hora: " + timecut, fuente, Brushes.Black, posX, posY);
                posX = posX + 110;
                e.Graphics.DrawString("Cajero: "+CashierName, fuente, Brushes.Black, posX, posY);
                posX = 10;
                posY = posY + 30;
                e.Graphics.DrawString("Numero de ticket: " + Number, fuente, Brushes.Black, posX, posY);
                posY = posY + 20;
                //productos
                e.Graphics.DrawString("-------------------------------------------------------------" +
                    "---------------------", fuente, Brushes.Black, posX, posY);
                posY = posY + 10;
                e.Graphics.DrawString("DESCRIPCION", fuente, Brushes.Black, posX, posY);
                posX += 140;
                e.Graphics.DrawString("CANTIDAD", fuente, Brushes.Black, posX, posY);
                posX += 80;
                e.Graphics.DrawString("VALOR", fuente, Brushes.Black, posX, posY);
                posX += 70;
                e.Graphics.DrawString("TOTAL", fuente, Brushes.Black, posX, posY);
                posY = posY + 10;
                posX = 10;
                e.Graphics.DrawString("-------------------------------------------------------------" +
                    "---------------------", fuente, Brushes.Black, posX, posY);
                posY = posY + 20;

                for (int i = 0; i < ProductsLists.Count; i++)
                {
                    posX = 10;

                    // Verificar la longitud del nombre del producto
                    string productName = ProductsLists[i].Nombre;
                    if (productName.Length > 16)
                    {
                        // Si es mayor a 16 caracteres, truncar a 16 caracteres y agregar puntos suspensivos solo si es necesario
                        if (productName.Length > 19) // Si el nombre es mayor a 19 caracteres, truncar y agregar puntos
                        {
                            productName = productName.Substring(0, 16) + "...";
                        }
                        else // Si el nombre está entre 16 y 19 caracteres, dejarlo así sin agregar puntos
                        {
                            productName = productName.Substring(0, productName.Length);
                        }
                    }

                    e.Graphics.DrawString(productName, fuente, Brushes.Black, posX, posY);
                    posX += 150;
                    e.Graphics.DrawString($"{ProductsLists[i].Cantidad}", fuente, Brushes.Black, posX, posY);
                    posX += 80;
                    e.Graphics.DrawString($"{ProductsLists[i].Valor}$", fuente, Brushes.Black, posX, posY);
                    posX += 80;
                    e.Graphics.DrawString($"{ProductsLists[i].Cantidad * ProductsLists[i].Valor}$", fuente, Brushes.Black, posX, posY);
                    posY += 25;
                }
                posY = posY + 20;
                posX = 150;
                e.Graphics.DrawString("Subtotal: " + $"{Subtotal}$", fuente, Brushes.Black, posX, posY);
                posY = posY + 20;
                posX = 10;
                e.Graphics.DrawString("-------------------------------------------------------------" +
                    "---------------------", fuente, Brushes.Black, posX, posY);
                posY = posY + 20;
                posX = 10;
                e.Graphics.DrawString("items: " + Items.ToString(), fuente, Brushes.Black, posX, posY);
                posX = posX + 120;
                e.Graphics.DrawString("cancelado: " + $"{Cancelled}$", fuente, Brushes.Black, posX, posY);
                posX = posX + 120;
                e.Graphics.DrawString("cambio: " + $"{Change}$", fuente, Brushes.Black, posX, posY);
                posY = posY + 50;
                posX = 120;
                e.Graphics.DrawString(FarewellMessage, fuente, Brushes.Black, posX, posY);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
