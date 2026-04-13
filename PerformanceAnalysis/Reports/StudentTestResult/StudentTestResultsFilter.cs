namespace PerformanceAnalysis.Reports.StudentTestResult
{
    /// <summary>
    /// Фильтры для отчёта "Результаты тестов конкретного студента"
    /// </summary>
    public class StudentTestResultsFilter
    {
        /// <summary>
        /// ID студента (обязательный параметр)
        /// </summary>
        public int? StudentId { get; set; }
    }
}
