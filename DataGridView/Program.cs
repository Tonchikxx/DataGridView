using DataGridView.App.UI;
using DataGridView.Services;
using DataGrisView.Services.Contracts;

namespace DataGridView.App
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
            ICarService carService = new CarService(new Repository.InMemoryStorage());
            Application.Run(new MainForm(carService));
        }
    }
}