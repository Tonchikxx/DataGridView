using DataGridView.Entities.Models;
using DataGridView.Entities.Contracts;
using DataGridView.Repository.Contracts;
using DataGrisView.Services.Contracts;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис управления автомобилями
    /// </summary>
    public class CarService(ICarRepository storage, ILoggerFactory loggerFactory) : ICarService
    {
        private readonly ILogger<CarService> logger = loggerFactory.CreateLogger<CarService>();

        /// <summary>
        /// Получить все автомобили
        /// </summary>
        public async Task<IEnumerable<CarModel>> GetAllCars(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetAllCars(cancellationToken);   
            sw.Stop();
            logger.LogDebug("CarService.GetAllCars выполнен за {ms} мс", sw.ElapsedMilliseconds);
            return res;
        }

        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        public async Task AddCar(CarModel car, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            await storage.AddCar(car, cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.AddCar выполнен за {ms} мс", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Обновление автомобиля
        /// </summary>
        public async Task UpdateCar(CarModel car, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            await storage.UpdateCar(car, cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.UpdateCar выполнен за {ms} мс", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Удаление автомобиля по id
        /// </summary>
        public async Task DeleteCar(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            await storage.DeleteCar(id, cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.DeleteCar выполнен за {ms} мс", sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// Рассчитывает статистику по всем автомобилям в системе проката
        /// </summary>
        public async Task<CarStatistics> GetStatistics(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            try
            {
                logger?.LogDebug("Расчет статистики по автомобилям");
                var cars = await storage.GetAllCars(cancellationToken);

                var statistics = new CarStatistics
                {
                    GetCarCount = cars.Count(),
                    GetCarWithFuelVolume = cars.Count(c => c.FuelVolume < EntitiesValidationConstants.CriticalFuelLevel),
                    GetFuelReserveHours = cars.Sum(c => (double)c.CostPerMinute),
                    GetSumRent = cars.Any() ? cars.Average(c => c.Mileage) : 0
                };

                return statistics;
            }
            finally
            {
                sw.Stop();
                var ms = sw.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
                logger?.LogDebug("CarService.GetStatistics выполнен за {ms:F6} мс", sw.ElapsedMilliseconds);
            }
        }
    }
}
