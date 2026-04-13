namespace PerformanceAnalysis.Reports.StudentPassRate
{
    /// <summary>
    /// Строка отчёта "Процент пройденных тестов по студентам"
    /// </summary>
    public class StudentPassRateItem
    {
        /// <summary>
        /// ID студента
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// ФИО студента
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Название основной группы студента
        /// </summary>
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Количество тестов, доступных студенту (назначенных его группам)
        /// </summary>
        public int TestsAvailable { get; set; }

        /// <summary>
        /// Количество тестов, успешно пройденных студентом (Passed = true)
        /// </summary>
        public int TestsPassed { get; set; }

        /// <summary>
        /// Процент пройденных тестов: (TestsPassed / TestsAvailable) * 100
        /// </summary>
        public decimal PassRate { get; set; }
    }
}
