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
                .Setup(x => x.GetAllCars(CancellationToken.None))
            .ReturnsAsync(list);

            // Act
            var res = await service.GetAllCars(CancellationToken.None);

            // Assert
            res.Should().BeSameAs(list);
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
        /// Проверка расчета статистики 
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldReturnCorrectStatistics()
        {
            // Arrange
            var cars = new List<CarModel>
            {
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    FuelVolume = 15, 
                    CostPerMinute = 5.5,
                    Mileage = 10000
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    FuelVolume = 5, 
                    CostPerMinute = 7.2,
                    Mileage = 25000
                },
                new CarModel
                {
                    Id = Guid.NewGuid(),
                    FuelVolume = 8, 
                    CostPerMinute = 6.0,
                    Mileage = 15000
                }
            };

            mock.Setup(x => x.GetAllCars(CancellationToken.None))
                .ReturnsAsync(cars);

            // Act
            var result = await service.GetStatistics(CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.GetCarCount.Should().Be(3);
            result.GetCarWithFuelVolume.Should().Be(1); 
            result.GetFuelReserveHours.Should().BeApproximately(18.7, 0.01); 
            result.GetSumRent.Should().BeApproximately(16666.67, 0.01); 
        }
    }
}
