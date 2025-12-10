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
        /// Получить статистику по автомобилям в прокате
        /// </summary>
        public Task<CarStatistics> GetStatistics();

    }
}
