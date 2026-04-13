namespace PerformanceAnalysis.Reports.GroupTrend
{
    /// <summary>
    /// Фильтры для отчёта "Динамика среднего балла по группам"
    /// </summary>
    public class GroupTrendFilter
    {
        /// <summary>
        /// Список ID групп для фильтрации (опционально, если null — все группы)
        /// </summary>
        public List<int>? GroupIds { get; set; }

        /// <summary>
        /// Начало временного диапазона (включительно)
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Конец временного диапазона (включительно)
        /// </summary>
        public DateTime? DateTo { get; set; }
    }
}
