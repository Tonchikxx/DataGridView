using DataGridView.App.UI;
using DataGridView.Services;
using DataGrisView.Services.Contracts;
using Serilog;
using Serilog.Extensions.Logging;

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
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Seq("http://localhost:5341", apiKey: "vR8XqYtHT5QFjkPbx1VV")
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
            .CreateLogger();

            var loggerFactory = new SerilogLoggerFactory(Log.Logger, dispose: true);

            ApplicationConfiguration.Initialize();
            ICarService carService = new CarService(new Repository.InMemoryStorage(), loggerFactory);
            Application.Run(new MainForm(carService));
        }
    }
}