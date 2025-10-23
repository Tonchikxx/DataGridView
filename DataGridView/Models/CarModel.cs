using DataGridView.Classes;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Models
{
    /// <summary>
    /// Модель авто
    /// </summary>
    public class CarModel
    {
        /// <summary>
        /// Идентификатор автомобиля
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        [Required(ErrorMessage = "{0} обязательна для выбора")]
        [Range(1, 3, ErrorMessage = "{0} должна быть выбрана из списка")]
        public CarName CarName { get; set; }

        /// <summary>
        /// Государственный номер
        /// </summary>
        [Display(Name = "Государственный номер")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(AppConstants.AutoNumberMaxLength, MinimumLength = AppConstants.AutoNumberMinLength,
            ErrorMessage = "{0} должен быть от {2} до {1} символов")]
        [RegularExpression(@"^[А-ЯЁ]{2}\d{3}[А-ЯЁ]{1}$",
        ErrorMessage = "{0} должен быть в формате: АЛ123В (2 буквы-3 цифры-1 буква)")]
        public string GosNumber { get; set; } = string.Empty;


        /// <summary>
        /// Пробег (км)
        /// </summary>
        [Display(Name = "Пробег автомобиля")]
        [Range(AppConstants.MileageMin, AppConstants.MileageMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} км")]
        public double Mileage { get; set; }

        /// <summary>
        /// Средний расход топлива (л/час)
        /// </summary>
        [Display(Name = "Средний расход топлива")]
        [Range(AppConstants.FuelConsumptionMin, AppConstants.FuelConsumptionMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} л/час")]
        public double FuelConsumption { get; set; }

        /// <summary>
        /// Текущий объем топлива (л)
        /// </summary>
        [Display(Name = "Текущий объем топлива")]
        [Range(AppConstants.CurrentFuelVolumeMin, AppConstants.CurrentFuelVolumeMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} литров")]
        public double FuelVolume { get; set; }

        /// <summary>
        /// Стоимость аренды (руб/мин)
        /// </summary>
        [Display(Name = "Стоимость аренды за минуту")]
        [Range(AppConstants.RentCostPerMinuteMin, AppConstants.RentCostPerMinuteMax,
            ErrorMessage = "{0} должна быть в диапазоне от {1} до {2} руб/мин")]
        public double CostPerMinute { get; set; }

        /// <summary>
        /// Запас хода по топливу (часы)
        /// </summary>
        [Display(Name = "Запас хода по топливу")]
        public double FuelReserveHours
        {
            get
            {
                if (FuelConsumption <= 0)
                    return 0;
                return Math.Round(FuelVolume / FuelConsumption, 2);
            }
        }

        /// <summary>
        /// Сумма аренды до полного расхода топлива
        /// </summary>
        [Display(Name = "Сумма аренды")]
        public double RentAmount
        {
            get
            {
                if (FuelConsumption <= 0)
                    return 0;
                return Math.Round(FuelReserveHours * 60 * CostPerMinute, 2);
            }
        }

        /// <summary>
        /// Создает копию объекта CarModel
        /// </summary>
        public CarModel Clone()
        {
            return new CarModel
            {
                CarName = CarName,
                GosNumber = GosNumber,
                Mileage = Mileage,
                FuelConsumption = FuelConsumption,
                FuelVolume = FuelVolume,
                CostPerMinute = CostPerMinute
            };
        }
    }
}
