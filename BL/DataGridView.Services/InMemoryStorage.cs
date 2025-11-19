using DataGridView.Entities.Models;
using DataGridView.Models;
using DataGrisView.Services.Contracts;

namespace DataGridView.Services
{
    /// <summary>
    /// Сервис для доступа к автомобилям, хранящимся в памяти
    /// </summary>
    public class InMemoryStorage : ICarService
    {
        private List<CarModel> cars;

        /// <summary>
        /// Данные автомобилей
        /// </summary>
        public InMemoryStorage() 
        {
            cars =
            [
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Lada,
                    GosNumber = "ПР678Н",
                    Mileage = 300,
                    FuelConsumption = 50,
                    FuelVolume = 5,
                    CostPerMinute = 120
                },   

                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Mitsubishi,
                    GosNumber = "АО666О",
                    Mileage = 150,
                    FuelConsumption = 40,
                    FuelVolume = 100,
                    CostPerMinute = 90
                },

                new CarModel
                {
                    Id = Guid.NewGuid(),
                    CarName = CarType.Hyundai,
                    GosNumber = "УУ777С",
                    Mileage = 100,
                    FuelConsumption = 50,
                    CostPerMinute = 100
                }
            ];
        }



        /// <summary>
        /// Получить все автомобили
        /// </summary>
        public async Task<IEnumerable<CarModel>> GetAllCars() => await Task.FromResult<IEnumerable<CarModel>>(cars.ToList());

        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        public async Task AddCar(CarModel car)
        {
            cars.Add(car);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Обновление автомобиля
        /// </summary>
        public async Task UpdateCar(CarModel car)
        {
            var existingCar = cars.FirstOrDefault(p => p.Id == car.Id);

            existingCar.CarName = car.CarName;
            existingCar.GosNumber = car.GosNumber;
            existingCar.Mileage = car.Mileage;
            existingCar.FuelConsumption = car.FuelConsumption;
            existingCar.FuelVolume = car.FuelVolume;
            existingCar.CostPerMinute = car.CostPerMinute;

            await Task.CompletedTask;
        }

        /// <summary>
        /// Удаление автомобиля по id
        /// </summary>
        public async Task DeleteCar(Guid id)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            if (car is not null)
            {
                cars.Remove(car);
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// Найти автомобиль по id
        /// </summary>
        public async Task<CarModel?> GetCarById(Guid id) => await Task.FromResult(cars.FirstOrDefault(p => p.Id == id));

        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public async Task<int> GetCarCount() => await Task.FromResult(cars.Count);

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public async Task<int> GetCarWithFuelVolume() => await Task.FromResult(cars.Count(p => p.FuelVolume < 7));

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public async Task<double> GetFuelReserveHours(Guid id)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            var fuelReserveHours = car.FuelVolume / car.FuelConsumption;
            return await Task.FromResult(fuelReserveHours);
        }

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public async Task<double> GetSumRent(Guid id)
        {
            var car = cars.FirstOrDefault(p => p.Id == id);

            var fuelReserveHours = car.FuelVolume / car.FuelConsumption;
            var sumRent = fuelReserveHours * 60 * car.CostPerMinute;
            return await Task.FromResult(sumRent);
        }
    }
}
