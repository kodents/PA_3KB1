namespace PerformanceAnalysis.Reports.StudentMonthlyProgress
{
    /// <summary>
    /// Фильтры для отчёта "Накопленные баллы студента по месяцам"
    /// </summary>
    public class StudentMonthlyProgressFilter
    {
        /// <summary>
        /// ID студента (обязательный параметр)
        /// </summary>
        public int? StudentId { get; set; }
    }
}
