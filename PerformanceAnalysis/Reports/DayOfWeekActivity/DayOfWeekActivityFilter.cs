namespace PerformanceAnalysis.Reports.DayOfWeekActivity
{
    /// <summary>
    /// Фильтры для отчёта "Активность по дням недели"
    /// </summary>
    public class DayOfWeekActivityFilter
    {
        /// <summary>
        /// Начало временного диапазона (включительно)
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Конец временного диапазона (включительно)
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// ID группы для фильтрации (опционально)
        /// </summary>
        public int? GroupId { get; set; }
    }

}
