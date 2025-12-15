using DataGridView.Entities.Models;
using DataGridView.Repository.Contracts;

namespace DataGridView.Repository
{
    /// <summary>
    /// Слой доступа к автомобилям, хранящимся в памяти
    /// </summary>
    public class InMemoryStorage : ICarRepository
    {
        private readonly List<CarModel> cars;

        /// <summary>
        /// Данные автомобилей
        /// </summary>
        public InMemoryStorage()
        {
            cars = [];
        }

        /// <summary>
        /// Получить все автомобили
        /// </summary>
        public Task<IEnumerable<CarModel>> GetAllCars()
        {
            return Task.FromResult<IEnumerable<CarModel>>(cars);
        }



        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        public Task AddCar(CarModel car, CancellationToken cancellationToken)
        {
            cars.Add(car);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Обновление автомобиля
        /// </summary>
        public Task UpdateCar(CarModel car, CancellationToken cancellationToken)
        {
            var existingCar = cars.FirstOrDefault(p => p.Id == car.Id);

            existingCar!.CarName = car.CarName;
            existingCar.GosNumber = car.GosNumber;
            existingCar.Mileage = car.Mileage;
            existingCar.FuelConsumption = car.FuelConsumption;
            existingCar.FuelVolume = car.FuelVolume;
            existingCar.CostPerMinute = car.CostPerMinute;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Удаление автомобиля по id
        /// </summary>
        public Task DeleteCar(Guid id, CancellationToken cancellationToken)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            if (car is not null)
            {
                cars.Remove(car);
            }

            return Task.CompletedTask;
        }
    }
}
