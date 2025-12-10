using DataGridView.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseStorage
{
    /// <summary>
    /// Контекст базы данных для управления автомобилями
    /// </summary>
    public class CarDatabaseContext : DbContext
    {
        /// <summary>
        /// Сущность <see cref="CarModel"/>.
        /// </summary>
        public DbSet<CarModel> Cars { get; set; }

        /// <summary>
        /// Создаёт экземпляр <see cref="CarDatabaseContext"/>.
        /// </summary>
        public CarDatabaseContext() => Database.EnsureCreated();

        /// <summary>
        /// Конфигурация подключения к базе данных
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=CarDatabase;Trusted_Connection=True;");

        /// <summary>
        /// Конфигурация модели данных
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasConversion<int>();
                entity.Property(e => e.GosNumber)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(e => e.Mileage)
                    .HasPrecision(18, 2);
                entity.Property(e => e.FuelConsumption)
                    .HasPrecision(18, 2);
                entity.Property(e => e.FuelVolume)
                    .HasPrecision(18, 2);
                entity.Property(e => e.CostPerMinute)
                    .HasPrecision(18, 2);
            });
        }
    }
}
