namespace PerformanceAnalysis.Reports.GroupLeadersAndLaggards
{
    /// <summary>
    /// Фильтры для отчёта "Лидеры и отстающие в группах"
    /// </summary>
    public class GroupLeadersAndLaggardsFilter
    {
        /// <summary>
        /// ID направления для фильтрации (опционально)
        /// </summary>
        public int? DirectionId { get; set; }

        /// <summary>
        /// ID курса для фильтрации (опционально)
        /// </summary>
        public int? CourseId { get; set; }
    }
}
