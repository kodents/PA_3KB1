namespace PerformanceAnalysis.Reports.StudentRating
{
    /// <summary>
    /// Строка отчёта "Общий рейтинг студентов"
    /// </summary>
    public class StudentRatingItem
    {
        /// <summary>
        /// Позиция в рейтинге (1 — лучший результат)
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// ФИО студента
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Название курса студента
        /// </summary>
        public string Course { get; set; } = string.Empty;

        /// <summary>
        /// Название основной группы студента
        /// </summary>
        public string Group { get; set; } = string.Empty;

        /// <summary>
        /// Название направления студента
        /// </summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary>
        /// Сумма лучших баллов студента по всем пройденным тестам
        /// </summary>
        public int TotalScore { get; set; }
    }
}
