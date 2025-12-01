using DataGridView.Entities.Models;

namespace DataGrisView.Services.Contracts
{
    /// <summary>
    /// Методы для операций с хранилищем
    /// </summary>
    public interface ICarService
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<CarModel>> GetAllCars();

        /// <summary>
        /// Добавить новый автомобиль
        /// </summary>
        public Task AddCar(CarModel car, CancellationToken cancellationToken);

        /// <summary>
        /// Обновить автомобиль
        /// </summary>
        public Task UpdateCar(CarModel car, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить автомобиль
        /// </summary>
        public Task DeleteCar(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public Task<int> GetCarCount(CancellationToken cancellationToken);

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public Task<int> GetCarWithFuelVolume(CancellationToken cancellationToken);

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public Task<double> GetFuelReserveHours(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public Task<double> GetSumRent(Guid id, CancellationToken cancellationToken);

    }
}
