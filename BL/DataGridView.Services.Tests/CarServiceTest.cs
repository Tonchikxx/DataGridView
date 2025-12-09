using DataGridView.Entities.Models;
using DataGridView.Repository.Contracts;
using DataGrisView.Services.Contracts;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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
        private readonly ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

        /// <summary>
        /// Конструктор класса для <see cref="CarServiceTest"/>
        /// </summary>
        public CarServiceTest()
        {
            mock = new Mock<ICarRepository>();
            loggerFactory = NullLoggerFactory.Instance;
            service = new CarService(mock.Object, loggerFactory);
        }

        /// <summary>
        /// Проверка вызова метода добавления при добавлении в хранилище
        /// </summary>
        [Fact]
        public async Task AddCarShouldCallStorageAdd()
        {
            // Arrange
            var car = new CarModel();

            // Act
            await service.AddCar(car, CancellationToken.None);

            // Assert
            mock.Verify(x => x.AddCar(car, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка вызова метода удаления при удалении из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteCarShouldCallStorageDeletre()
        {   
            // Arrange
            var id = Guid.NewGuid();
            var car = new CarModel { Id = id };

            // Act
            await service.DeleteCar(id, CancellationToken.None);

            // Assert
            mock.Verify(x => x.DeleteCar(id, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка корректности возвращаемых данных при вызове получения всех автомобилей
        /// </summary>
        [Fact]
        public async Task GetAllCarsShouldReturnDataFromStorage()
        {
            // Arrange
            var list = new List<CarModel>
            {
                new (),
                new (),
            };
            mock
                .Setup(x => x.GetAllCars())
            .ReturnsAsync(list);

            // Act
            var res = await service.GetAllCars();

            // Assert
            res.Should().BeSameAs(list);
        }

        /// <summary>
        /// Проверка корректности подсчёта общего количества автомобилей
        /// </summary>
        [Fact]
        public async Task GetCarCountShouldReturnCorrectData()
        {
            // Arrange
            mock
                .Setup(s => s.GetCarCount(CancellationToken.None))
                .ReturnsAsync(3);

            // Act
            var result = await service.GetCarCount(CancellationToken.None);

            // Assert
            result.Should().Be(3);

            mock.Verify(x => x.GetCarCount(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно вычисляет количество автомобилей с критически низким запасом топлива
        /// </summary>
        [Fact]
        public async Task GetCarWithFuelVolumeShouldReturnCorrectCount()
        {
            // Arrange
            int expectedCount = 1;
            mock
                .Setup(x => x.GetCarWithFuelVolume(CancellationToken.None))
                .ReturnsAsync(expectedCount);

            // Act
            var result = await service.GetCarWithFuelVolume(CancellationToken.None);

            // Assert
            result.Should().Be(expectedCount);

            mock.Verify(x => x.GetCarWithFuelVolume(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверка обновления автомобиля при вызове метода обновления
        /// </summary>
        [Fact]
        public async Task UpdateCarShouldUpdateEntityDataInStorage()
        {
            // Arrange
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
                It.Is<CarModel>(p => p == incomingCar), CancellationToken.None)
            ).Returns(Task.CompletedTask);

            // Act
            await service.UpdateCar(incomingCar, CancellationToken.None);

            // Assert
            mock.Verify(s => s.UpdateCar(
                It.Is<CarModel>(p => p == incomingCar), CancellationToken.None), 
                Times.Once
            );
        }

        /// <summary>
        /// Проверяет, что сервис корректно возвращает запас хода для существующего автомобиля
        /// </summary>
        [Fact]
        public async Task GetFuelReserveHoursShouldReturnCorrectValue()
        {
            // Arrange
            var carId = Guid.NewGuid();
            double expectedFuelReserve = 5.0; 

            mock
                .Setup(x => x.GetFuelReserveHours(carId, CancellationToken.None))
                .ReturnsAsync(expectedFuelReserve);

            // Act
            var result = await service.GetFuelReserveHours(carId, CancellationToken.None);

            // Assert
            result.Should().Be(expectedFuelReserve);
            mock.Verify(x => x.GetFuelReserveHours(carId, CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Проверяет, что сервис корректно возвращает сумму аренды для существующего автомобиля
        /// </summary>
        [Fact]
        public async Task GetSumRentShouldReturnCorrectValue()
        {
            // Arrange
            var carId = Guid.NewGuid();
            double expectedSumRent = 3000.0; 

            mock
                .Setup(x => x.GetSumRent(carId, CancellationToken.None))
                .ReturnsAsync(expectedSumRent);

            // Act
            var result = await service.GetSumRent(carId, CancellationToken.None);

            // Assert
            result.Should().Be(expectedSumRent);
            mock.Verify(x => x.GetSumRent(carId, CancellationToken.None), Times.Once);
        }
    }
}
