using DataGridView.Entities.Models;

namespace DataGrisView.Services.Contracts
{
    public interface ICarService
    {
        /// <summary>
        /// Получить все товары
        /// </summary>
        public Task<IEnumerable<CarModel>> GetAllCars();

        /// <summary>
        /// Добавить новый автомобиль
        /// </summary>
        public Task AddCar(CarModel car);

        /// <summary>
        /// Обновить автомобиль
        /// </summary>
        public Task UpdateCar(CarModel car);

        /// <summary>
        /// Удалить автомобиль
        /// </summary>
        public Task DeleteCar(Guid id);

        /// <summary>
        /// Найти автомобиль по Id
        /// </summary>
        public Task<CarModel?> GetCarById(Guid id);

        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public Task<int> GetCarCount();

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public Task<int> GetCarWithFuelVolume();

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public Task<double> GetFuelReserveHours(Guid id);

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public Task<double> GetSumRent(Guid id);

    }
}
