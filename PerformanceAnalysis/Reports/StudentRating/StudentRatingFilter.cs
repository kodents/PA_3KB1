namespace PerformanceAnalysis.Reports.StudentRating
{
    /// <summary>
    /// Фильтры для отчёта "Общий рейтинг студентов"
    /// </summary>
    public class StudentRatingFilter
    {
        /// <summary>
        /// ID направления для фильтрации (опционально)
        /// </summary>
        public int? DirectionId { get; set; }

        /// <summary>
        /// ID курса для фильтрации (опционально)
        /// </summary>
        public int? CourseId { get; set; }

        /// <summary>
        /// ID группы для фильтрации (опционально)
        /// </summary>
        public int? GroupId { get; set; }
    }
}
