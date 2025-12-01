using DataGridView.Entities.Models;
using DataGrisView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для доступа к автомобилям, хранящимся в памяти
    /// </summary>
    public class InMemoryStorage : ICarService
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

        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public Task<int> GetCarCount(CancellationToken cancellationToken)
        {
            return Task.FromResult(cars.Count);
        }

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public Task<int> GetCarWithFuelVolume(CancellationToken cancellationToken)
        {
            return Task.FromResult(cars.Count(p => p.FuelVolume < 7));
        }

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public Task<double> GetFuelReserveHours(Guid id, CancellationToken cancellationToken)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            var fuelReserveHours = car!.FuelVolume / car.FuelConsumption;
            return Task.FromResult(fuelReserveHours);
        }

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public Task<double> GetSumRent(Guid id, CancellationToken cancellationToken)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            var fuelReserveHours = car!.FuelVolume / car.FuelConsumption;
            var sumRent = fuelReserveHours * 60 * car.CostPerMinute;
            return Task.FromResult(sumRent);
        }
    }
}
