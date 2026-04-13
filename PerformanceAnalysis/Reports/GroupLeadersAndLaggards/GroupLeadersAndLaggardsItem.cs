namespace PerformanceAnalysis.Reports.GroupLeadersAndLaggards
{
    /// <summary>
    /// Строка отчёта "Лидер и отстающий в группе"
    /// </summary>
    public class GroupLeadersAndLaggardsItem
    {
        /// <summary>
        /// ID группы
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// Название группы
        /// </summary>
        public string GroupName { get; set; } = string.Empty;

        /// <summary>
        /// Название направления группы
        /// </summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary>
        /// Название курса группы
        /// </summary>
        public string Course { get; set; } = string.Empty;

        /// <summary>
        /// ФИО студента с наибольшим количеством баллов в группе
        /// </summary>
        public string LeaderName { get; set; } = string.Empty;

        /// <summary>
        /// Сумма баллов лидера группы
        /// </summary>
        public int LeaderScore { get; set; }

        /// <summary>
        /// ФИО студента с наименьшим количеством баллов в группе
        /// </summary>
        public string LaggardName { get; set; } = string.Empty;

        /// <summary>
        /// Сумма баллов отстающего в группе
        /// </summary>
        public int LaggardScore { get; set; }
    }
}
