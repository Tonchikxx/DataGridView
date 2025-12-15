using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGrisView.Services.Contracts
{
    public class CarStatistics
    {
        /// <summary>
        /// Получить общее количество автомобилей
        /// </summary>
        public int GetCarCount { get; set; }

        /// <summary>
        /// Получить количество автомобилей с критически низким уровнем запаса топлива   
        /// </summary>
        public int GetCarWithFuelVolume { get; set; }

        /// <summary>
        /// Получить запас хода топлива автомобиля
        /// </summary>
        public double GetFuelReserveHours { get; set; }

        /// <summary>
        /// Сумма аренды автомобиля
        /// </summary>
        public double GetSumRent { get; set; }
    }
}
