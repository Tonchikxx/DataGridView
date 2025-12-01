using DataGridView.Entities.Models;
using DataGridView.Repository;
using DataGridView.Repository.Contracts;
using DataGrisView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис управления автомобилями
    /// </summary>
    public class CarService(ICarRepository storage) : ICarService
    {
        /// <summary>
        /// Получить все автомобили
        /// </summary>
        public Task<IEnumerable<CarModel>> GetAllCars()
        {
            return storage.GetAllCars();
        }

        

        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        public Task AddCar(CarModel car, CancellationToken cancellationToken)
        {
            return storage.AddCar(car, cancellationToken);
        }

        /// <summary>
        /// Обновление автомобиля
        /// </summary>
        public Task UpdateCar(CarModel car, CancellationToken cancellationToken)
        {
            return storage.UpdateCar(car, cancellationToken);
        }

        /// <summary>
        /// Удаление автомобиля по id
        /// </summary>
        public Task DeleteCar(Guid id, CancellationToken cancellationToken)
        {
            return storage.DeleteCar(id, cancellationToken);
        }

        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public Task<int> GetCarCount(CancellationToken cancellationToken)
        {
            return storage.GetCarCount(cancellationToken);
        }

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public Task<int> GetCarWithFuelVolume(CancellationToken cancellationToken)
        {
            return storage.GetCarWithFuelVolume(cancellationToken);
        }

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public Task<double> GetFuelReserveHours(Guid id, CancellationToken cancellationToken)
        {
            return storage.GetFuelReserveHours(id, cancellationToken);
        }

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public Task<double> GetSumRent(Guid id, CancellationToken cancellationToken)
        {
            return storage.GetSumRent(id, cancellationToken);
        }
    }
}
