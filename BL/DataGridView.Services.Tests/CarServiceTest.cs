using DataGridView.Entities.Models;
using DataGridView.Repository.Contracts;
using DataGrisView.Services.Contracts;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataGridView.Services.Tests
{
    /// <summary>
    /// Набор тестов для проверки <see cref="CarService"/>
    /// </summary>
    public class CarServiceTest
    {
        private readonly Mock<ICarRepository> mock;
        private readonly ICarService service;

        /// <summary>
        /// Конструктор класса для <see cref="CarServiceTest"/>
        /// </summary>
        public CarServiceTest()
        {
            mock = new Mock<ICarRepository>();
            service = new CarService(mock.Object);
        }

        /// <summary>
        /// Проверка вызова метода добавления при добавлении в хранилище
        /// </summary>
        [Fact]
        public async Task AddCarShouldCallStorageAdd()
        {
            var car = new CarModel();

            await service.AddCar(car, CancellationToken.None);

            mock.Verify(x => x.AddCar(car, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка вызова метода удаления при удалении из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteCarShouldCallStorageDeletre()
        {
            var id = Guid.NewGuid();
            var car = new CarModel { Id = id };

            await service.AddCar(car, CancellationToken.None);

            await service.DeleteCar(id, CancellationToken.None);

            mock.Verify(x => x.DeleteCar(id, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка корректности возвращаемых данных при вызове получения всех автомобилей
        /// </summary>
        [Fact]
        public async Task GetAllCarsShouldReturnDataFromStorage()
        {
            var list = new List<CarModel>
            {
                new (),
                new (),
            };
            mock
                .Setup(x => x.GetAllCars())
            .ReturnsAsync(list);

            var res = await service.GetAllCars();

            res.Should().BeSameAs(list);
        }

        /// <summary>
        /// Проверка корректности подсчёта общего количества автомобилей
        /// </summary>
        [Fact]
        public async Task GetCarCountShouldReturnCorrectData()
        {
            mock
                .Setup(s => s.GetCarCount(CancellationToken.None))
                .ReturnsAsync(3);

            var result = await service.GetCarCount(CancellationToken.None);

            result.Should().Be(3);

            mock.Verify(x => x.GetCarCount(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет количество автомобилей с критически низким запасом топлива
        /// </summary>
        [Fact]
        public async Task GetCarWithFuelVolumeShouldReturnCorrectCount()
        {
            int expectedCount = 1;
            mock
                .Setup(x => x.GetCarWithFuelVolume(CancellationToken.None))
                .ReturnsAsync(expectedCount);


            var result = await service.GetCarWithFuelVolume(CancellationToken.None);


            result.Should().Be(expectedCount);

            mock.Verify(x => x.GetCarWithFuelVolume(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка обновления автомобиля при вызове метода обновления
        /// </summary>
        [Fact]
        public async Task UpdateCarShouldUpdateEntityDataInStorage()
        {
            var id = Guid.NewGuid();
            var incomingCar = new CarModel
            {
                Id = id,
                CarName = CarType.Lada,
                GosNumber = "ПР678Н",
                Mileage = 50,
                FuelConsumption = 50,
                FuelVolume = 5,
                CostPerMinute = 60
            };

            mock.Setup(x => x.UpdateCar(
                It.Is<CarModel>(p =>
                    p.CarName == CarType.Lada &&
                    p.GosNumber == "ПР678Н" &&
                    p.Mileage == 50 &&
                    p.FuelConsumption == 50 &&
                    p.FuelVolume == 5 &&
                    p.CostPerMinute == 60
                ), CancellationToken.None)
            ).Returns(Task.CompletedTask);

            await service.UpdateCar(incomingCar, CancellationToken.None);

            mock.Verify(s => s.UpdateCar(
                It.Is<CarModel>(p =>
                    p.CarName == incomingCar.CarName &&
                    p.GosNumber == incomingCar.GosNumber &&
                    p.Mileage == incomingCar.Mileage &&
                    p.FuelConsumption == incomingCar.FuelConsumption &&
                    p.FuelVolume == incomingCar.FuelVolume &&
                    p.CostPerMinute == incomingCar.CostPerMinute
                ), CancellationToken.None), Times.Once
            );
        }

        /// <summary>
        /// Проверяет, что сервис корректно возвращает запас хода для существующего автомобиля
        /// </summary>
        [Fact]
        public async Task GetFuelReserveHoursShouldReturnCorrectValue()
        {
            var carId = Guid.NewGuid();
            double expectedFuelReserve = 5.0; 

            mock
                .Setup(x => x.GetFuelReserveHours(carId, CancellationToken.None))
                .ReturnsAsync(expectedFuelReserve);

            var result = await service.GetFuelReserveHours(carId, CancellationToken.None);

            result.Should().Be(expectedFuelReserve);
            mock.Verify(x => x.GetFuelReserveHours(carId, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно возвращает сумму аренды для существующего автомобиля
        /// </summary>
        [Fact]
        public async Task GetSumRentShouldReturnCorrectValue()
        {
            var carId = Guid.NewGuid();
            double expectedSumRent = 3000.0; 

            mock
                .Setup(x => x.GetSumRent(carId, CancellationToken.None))
                .ReturnsAsync(expectedSumRent);

            var result = await service.GetSumRent(carId, CancellationToken.None);

            result.Should().Be(expectedSumRent);
            mock.Verify(x => x.GetSumRent(carId, CancellationToken.None), Times.Once);
        }
    }
}
