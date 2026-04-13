namespace PerformanceAnalysis.Reports.GroupTrend
{
    /// <summary>
    /// Строка отчёта "Динамика среднего балла по группам"
    /// </summary>
    public class GroupTrendItem
    {
        /// <summary>
        /// ID группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// Дата начала периода (для сортировки и отрисовки графика)
        /// </summary>
        public DateTime Month { get; set; }

        /// <summary>
        /// Человекочитаемая подпись периода: "Мар 2024"
        /// </summary>
        public string MonthLabel { get; set; } = string.Empty;

        /// <summary>
        /// Средний балл по всем попыткам группы в этот период
        /// </summary>
        public decimal AverageScore { get; set; }

        /// <summary>
        /// Количество попыток, учтённых в расчёте среднего балла
        /// </summary>
        public int AttemptsCount { get; set; }
    }
}
