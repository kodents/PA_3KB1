namespace PerformanceAnalysis.Reports.StudentPassRateSummary
{
    /// <summary>
    /// Фильтры для отчёта "Процент пройденных тестов конкретного студента"
    /// </summary>
    public class StudentPassRateSummaryFilter
    {
        /// <summary>
        /// ID студента (обязательный параметр)
        /// </summary>
        public int? StudentId { get; set; }
    }
}
