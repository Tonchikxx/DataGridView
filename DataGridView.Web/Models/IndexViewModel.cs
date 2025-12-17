using DataGridView.Entities.Models;
using DataGrisView.Services.Contracts;

namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для главной страницы
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// Коллекция автомобилей для отображения на странице
        /// </summary>
        public IEnumerable<CarModel> Cars { get; set; } = Enumerable.Empty<CarModel>();

        /// <summary>
        /// Объект статистики, содержащий агрегированные данные по автомобилям
        /// </summary>
        public CarStatistics Statistics { get; set; } = new();
    }
}

