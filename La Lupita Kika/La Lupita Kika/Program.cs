using System;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using La_Lupita_Kika.Views;
using System.Globalization;
using La_Lupita_Kika.Views.Admin.AddProduct;
using La_Lupita_Kika.Views.Admin.User;
using La_Lupita_Kika.Views.Products.Palettes;
using OfficeOpenXml;

namespace La_Lupita_Kika
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // Establecer el contexto de la licencia para EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Cargar la configuraci�n desde appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional: false,reloadOnChange: true)
                .Build();


            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");

            // Obtener la cadena de conexi�n desde la configuraci�n
            string connectionString = config.GetConnectionString("default");

            // Pasar la cadena de conexi�n al formulario o usarla en cualquier otra parte de la aplicaci�n
            ApplicationConfiguration.Initialize();

            try
            {
                //Application.Run(new Inventario(connectionString));
                Application.Run(new Inventario(connectionString));
            }
            catch (System.NullReferenceException)
            {
                // Se produjo una excepci�n de tipo NullReferenceException.
                // Puedes mostrar un mensaje de error o realizar cualquier acci�n antes de cerrar la aplicaci�n.
                // Luego, cierra la aplicaci�n con Environment.Exit(0).
                Environment.Exit(0);
            }
        }
    }
}
