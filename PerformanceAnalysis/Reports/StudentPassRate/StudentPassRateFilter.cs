namespace PerformanceAnalysis.Reports.StudentPassRate
{
    /// <summary>
    /// Фильтры для отчёта "Процент пройденных тестов по студентам"
    /// </summary>
    public class StudentPassRateFilter
    {
        /// <summary>
        /// ID группы для фильтрации (опционально)
        /// </summary>
        public int? GroupId { get; set; }
    }
}
