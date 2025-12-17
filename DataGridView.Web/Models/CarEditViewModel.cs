using DataGridView.Entities.Contracts;
using DataGridView.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для добавления и редактирования
    /// </summary>
    public class CarEditViewModel
    {
        /// <summary>
        /// Идентификатор автомобиля
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Марка автомобиля
        /// </summary>
        [Display(Name = "Марка автомобиля")]
        [Required(ErrorMessage = "{0} обязательна для выбора")]
        [Range(1, 3, ErrorMessage = "{0} должна быть выбрана из списка")]
        public CarType CarName { get; set; }

        /// <summary>
        /// Государственный номер
        /// </summary>
        [Display(Name = "Государственный номер")]
        [Required(ErrorMessage = "{0} обязателен для заполнения")]
        [StringLength(EntitiesValidationConstants.AutoNumberMaxLength, MinimumLength = EntitiesValidationConstants.AutoNumberMinLength,
            ErrorMessage = "{0} должен быть от {2} до {1} символов")]
        [RegularExpression(@"^[А-ЯЁ]{2}\d{3}[А-ЯЁ]{1}$",
        ErrorMessage = "{0} должен быть в формате: АЛ123В (2 буквы-3 цифры-1 буква)")]
        public string GosNumber { get; set; } = string.Empty;


        /// <summary>
        /// Пробег (км)
        /// </summary>
        [Display(Name = "Пробег автомобиля")]
        [Range(EntitiesValidationConstants.MileageMin, EntitiesValidationConstants.MileageMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} км")]
        public double Mileage { get; set; }

        /// <summary>
        /// Средний расход топлива (л/час)
        /// </summary>
        [Display(Name = "Средний расход топлива")]
        [Range(EntitiesValidationConstants.FuelConsumptionMin, EntitiesValidationConstants.FuelConsumptionMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} л/час")]
        public double FuelConsumption { get; set; }

        /// <summary>
        /// Текущий объем топлива (л)
        /// </summary>
        [Display(Name = "Текущий объем топлива")]
        [Range(EntitiesValidationConstants.CurrentFuelVolumeMin, EntitiesValidationConstants.CurrentFuelVolumeMax,
            ErrorMessage = "{0} должен быть в диапазоне от {1} до {2} литров")]
        public double FuelVolume { get; set; }

        /// <summary>
        /// Стоимость аренды (руб/мин)
        /// </summary>
        [Display(Name = "Стоимость аренды за минуту")]
        [Range(EntitiesValidationConstants.RentCostPerMinuteMin, EntitiesValidationConstants.RentCostPerMinuteMax,
            ErrorMessage = "{0} должна быть в диапазоне от {1} до {2} руб/мин")]
        public double CostPerMinute { get; set; }

    }
}
