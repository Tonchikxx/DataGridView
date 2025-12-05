using DataGridView.Entities.Models;
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
        public async Task<IEnumerable<CarModel>> GetAllCars()
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetAllCars();   
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
        /// Получить общее количество автомобилей
        /// </summary>
        public async Task<int> GetCarCount(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetCarCount(cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.GetCarCount выполнен за {ms} мс", sw.ElapsedMilliseconds);
            return res;
        }

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public async Task<int> GetCarWithFuelVolume(CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetCarWithFuelVolume(cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.GetCarWithFuelVolume выполнен за {ms} мс", sw.ElapsedMilliseconds);
            return res;
        }

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public async Task<double> GetFuelReserveHours(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetFuelReserveHours(id, cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.GetFuelReserveHours выполнен за {ms} мс", sw.ElapsedMilliseconds);
            return res;
        }

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public async Task<double> GetSumRent(Guid id, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var res = await storage.GetSumRent(id, cancellationToken);
            sw.Stop();
            logger.LogDebug("CarService.GetSumRent выполнен за {ms} мс", sw.ElapsedMilliseconds);
            return res;
        }
    }
}
