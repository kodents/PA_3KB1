namespace PerformanceAnalysis.Reports.StudentTestResult
{
    /// <summary>
    /// Строка отчёта "Результаты тестов конкретного студента"
    /// </summary>
    public class StudentTestResultsItem
    {
        /// <summary>
        /// ID теста
        /// </summary>
        public int TestId { get; set; }

        /// <summary>
        /// Название теста
        /// </summary>
        public string TestTitle { get; set; } = string.Empty;

        /// <summary>
        /// Лучший балл студента за этот тест (максимум из всех попыток)
        /// </summary>
        public int BestScore { get; set; }

        /// <summary>
        /// Максимально возможный балл за тест (сумма MaxScore всех вопросов)
        /// </summary>
        public int MaxPossibleScore { get; set; }

        /// <summary>
        /// Пройден ли тест успешно (Passed = true в лучшей попытке)
        /// </summary>
        public bool Passed { get; set; }

        /// <summary>
        /// Дата завершения лучшей попытки (null, если тест ещё не начат)
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Общее количество попыток прохождения этого теста студентом
        /// </summary>
        public int AttemptsCount { get; set; }
    }
}
