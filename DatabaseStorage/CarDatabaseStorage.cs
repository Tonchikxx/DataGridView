using DataGridView.Entities.Models;
using DataGridView.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage
{
    /// <summary>
    /// Хранилище автомобилей в базе данных
    /// </summary>
    public class CarDatabaseStorage : ICarRepository
    {
        /// <summary>
        /// Получить все автомобили из базы данных
        /// </summary>
        public async Task<IEnumerable<CarModel>> GetAllCars(CancellationToken cancellationToken)
        {
            using var database = new CarDatabaseContext();
            var cars = await database.Cars.AsNoTracking().ToListAsync(cancellationToken);
            return cars;
        }

        /// <summary>
        /// Добавить новый автомобиль в базу данных
        /// </summary>
        public async Task AddCar(CarModel car, CancellationToken cancellationToken)
        {
            using var database = new CarDatabaseContext();
            database.Cars.Add(car);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Обновить автомобиль в бд
        /// </summary>
        public async Task UpdateCar(CarModel car, CancellationToken cancellationToken)
        {
            using var database = new CarDatabaseContext();
            database.Cars.Update(car);
            await database.SaveChangesAsync();
        }

        /// <summary>
        /// Удалить Автоммобиль по id 
        /// </summary>
        public async Task DeleteCar(Guid id, CancellationToken cancellationToken)
        {
            using var database = new CarDatabaseContext();
            var car = await database.Cars.FindAsync(id);
            if (car != null)
            {
                database.Cars.Remove(car);
                await database.SaveChangesAsync();
            }
        }
    }
}
