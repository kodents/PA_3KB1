namespace PerformanceAnalysis.Reports.DayOfWeekActivity
{
    /// <summary>
    /// Строка отчёта "Активность по дням недели"
    /// </summary>
    public class DayOfWeekActivityItem
    {
        /// <summary>
        /// День недели: 0=Воскресенье, 1=Понедельник, ..., 6=Суббота
        /// </summary>
        public int DayOfWeek { get; set; }

        /// <summary>
        /// Короткое название дня на русском: "Пн", "Вт", ..., "Вс"
        /// </summary>
        public string DayName { get; set; } = string.Empty;

        /// <summary>
        /// Количество завершённых попыток прохождения тестов в этот день
        /// </summary>
        public int TestsCompleted { get; set; }

        /// <summary>
        /// Количество уникальных студентов, прошедших тесты в этот день
        /// </summary>
        public int UniqueStudents { get; set; }
    }
}
