using DataGridView.Forms;
using DataGridView.Services;
using DataGrisView.Services.Contracts;

namespace DataGridView
{
    /// <summary>
    /// Класс входа в программу
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            ICarService carServices = new InMemoryStorage();
            Application.Run(new MainForm(carServices));
        }
    }
}