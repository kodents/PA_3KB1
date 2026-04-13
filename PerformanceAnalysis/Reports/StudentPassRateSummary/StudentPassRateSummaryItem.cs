namespace PerformanceAnalysis.Reports.StudentPassRateSummary
{
    /// <summary>
    /// Сводный отчёт "Процент пройденных тестов конкретного студента"
    /// </summary>
    public class StudentPassRateSummaryItem
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
        /// Количество тестов, которые студент пытался пройти (есть хотя бы одна попытка)
        /// </summary>
        public int TestsAttempted { get; set; }

        /// <summary>
        /// Количество тестов, успешно пройденных студентом (Passed = true)
        /// </summary>
        public int TestsPassed { get; set; }

        /// <summary>
        /// Процент успешного прохождения: (TestsPassed / TestsAttempted) * 100
        /// </summary>
        public decimal PassRate { get; set; }

        /// <summary>
        /// Сумма баллов по всем попыткам студента
        /// </summary>
        public int TotalScore { get; set; }

        /// <summary>
        /// Средний балл за одну попытку прохождения теста
        /// </summary>
        public decimal AverageScore { get; set; }
    }
}
