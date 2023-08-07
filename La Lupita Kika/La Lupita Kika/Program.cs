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
using La_Lupita_Kika.Models;
using La_Lupita_Kika.Views.Ingredients;

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

            // Cargar la configuración desde appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional: false,reloadOnChange: true)
                .Build();


            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");

            // Obtener la cadena de conexión desde la configuración
            string connectionString = config.GetConnectionString("default");

            // Pasar la cadena de conexión al formulario o usarla en cualquier otra parte de la aplicación
            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(new Login(connectionString));
                //Application.Run(new Views.Ingredients.Ingredients(connectionString));
                //Application.Run(new Gains(connectionString));
            }
            catch (System.NullReferenceException)
            {
                // Luego, cierra la aplicación con Environment.Exit(0).
                Environment.Exit(0);
            }
        }
    }
}
