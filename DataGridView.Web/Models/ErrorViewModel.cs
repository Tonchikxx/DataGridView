namespace DataGridView.Web.Models
{
    /// <summary>
    /// Модель представления для страницы отображения ошибок
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Идентификатор запроса
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Указывает следует ли отображать идентификатор запроса на странице ошибки
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
