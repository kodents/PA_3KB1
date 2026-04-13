namespace PerformanceAnalysis.Reports.StudentMonthlyProgress
{
    /// <summary>
    /// Строка отчёта "Накопленные баллы студента по месяцам"
    /// </summary>
    public class StudentMonthlyProgressItem
    {
        /// <summary>
        /// Дата начала месяца (для сортировки и отрисовки графика)
        /// </summary>
        public DateTime Month { get; set; }

        /// <summary>
        /// Человекочитаемая подпись месяца: "Мар 2024"
        /// </summary>
        public string MonthLabel { get; set; } = string.Empty;

        /// <summary>
        /// Баллы, набранные студентом в этом месяце
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// Накопленная сумма баллов с начала обучения (нарастающий итог)
        /// </summary>
        public int CumulativeScore { get; set; }
    }
}
