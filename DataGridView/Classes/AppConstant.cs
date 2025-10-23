namespace DataGridView.Classes
{
    internal class AppConstants
    {
        /// <summary>
        /// Минимальная длина государственного номера автомобиля
        /// </summary>
        public const int AutoNumberMinLength = 3;

        /// <summary>
        /// Максимальная длина государственного номера автомобиля
        /// </summary>
        public const int AutoNumberMaxLength = 6;

        /// <summary>
        /// Минимальное значение пробега автомобиля (км)
        /// </summary>
        public const double MileageMin = 0;

        /// <summary>
        /// Максимальное значение пробега автомобиля (км)
        /// </summary>
        public const double MileageMax = 1000000;

        /// <summary>
        /// Минимальное значение расхода топлива (л/час)
        /// </summary>
        public const double FuelConsumptionMin = 0.1;

        /// <summary>
        /// Максимальное значение расхода топлива (л/час)
        /// </summary>
        public const double FuelConsumptionMax = 100;

        /// <summary>
        /// Минимальное значение текущего объема топлива (л)
        /// </summary>
        public const double CurrentFuelVolumeMin = 0;

        /// <summary>
        /// Максимальное значение текущего объема топлива (л)
        /// </summary>
        public const double CurrentFuelVolumeMax = 1000;

        /// <summary>
        /// Минимальная стоимость аренды за минуту (руб/мин)
        /// </summary>
        public const double RentCostPerMinuteMin = 0.1;

        /// <summary>
        /// Максимальная стоимость аренды за минуту (руб/мин)
        /// </summary>
        public const double RentCostPerMinuteMax = 1000;

        // Критический уровень топлива (для статистики)

        /// <summary>
        /// Критический уровень топлива для предупреждений (л)
        /// </summary>
        public const double CriticalFuelLevel = 7;
    }
}
