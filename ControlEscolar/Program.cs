using System.Security.Cryptography;
using ControlEscolar.View;
using NLog;
using ControlEscolarCore.Utilities;
using OfficeOpenXml;

namespace ControlEscolar
{
    internal static class Program
    {
        private static Logger? _logger;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization");

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Application.Run(new View.Login());

            //Inicia el sistema de loggin
            _logger = LoggingManager.GetLogger("ControlEscolar.Program");
            _logger.Info("Aplicación iniciada");


            //INCIA LA APLIACION CON LA VENTANA DE INICIO 
            Login login_form = new Login();
            if (login_form.ShowDialog()== DialogResult.OK)
            {
                Application.Run(new MDI_Cotrol_escolar());
            }
        }
    }
}