using Dapper;
using PerformanceAnalysis.Infrastructure.Reports;
using PerformanceAnalysis.Reports.DayOfWeekActivity;
using PerformanceAnalysis.Reports.GroupLeadersAndLaggards;
using PerformanceAnalysis.Reports.GroupTrend;
using PerformanceAnalysis.Reports.StudentMonthlyProgress;
using PerformanceAnalysis.Reports.StudentPassRate;
using PerformanceAnalysis.Reports.StudentPassRateSummary;
using PerformanceAnalysis.Reports.StudentRating;
using PerformanceAnalysis.Reports.StudentTestResult;
using System.Data;
using System.Data.Common;

namespace PerformanceAnalysis.Application.Reports
{
    public class ReportService : IReportService
    {
        private readonly IDapperExecutor _dapper;
        public ReportService(IDapperExecutor dapper)
        {
            _dapper = dapper;
        }

        public async Task<IEnumerable<GroupLeadersAndLaggardsItem>> GetGroupLeadersAndLaggardsAsync(GroupLeadersAndLaggardsFilter filter)
        {
            return await _dapper.QueryAsync<GroupLeadersAndLaggardsItem>(
                ReportQueries.GroupLeadersAndLaggards, filter);  
        }

        public async Task<IEnumerable<StudentTestResultsItem>> GetStudentTestResultsAsync(StudentTestResultsFilter filter)
        {
            return await _dapper.QueryAsync<StudentTestResultsItem>(
              ReportQueries.StudentTestResults, filter);
        }

        public async Task<IEnumerable<GroupTrendItem>> GetGroupTrendAsync(GroupTrendFilter filter)
        {
            return await _dapper.QueryAsync<GroupTrendItem>(
                ReportQueries.GroupTrend,
                new { GroupIds = filter.GroupIds?.ToArray(), filter.DateFrom, filter.DateTo });
        }

        public async Task<IEnumerable<StudentRatingItem>> GetStudentRatingAsync(StudentRatingFilter filter)
        {
            return await _dapper.QueryAsync<StudentRatingItem>(ReportQueries.StudentRating, filter);
        }

        public async Task<IEnumerable<StudentMonthlyProgressItem>> GetStudentMonthlyProgressAsync(StudentMonthlyProgressFilter filter)
        {
            return await _dapper.QueryAsync<StudentMonthlyProgressItem>(ReportQueries.StudentMonthlyProgress, filter);
        }

        public async Task<IEnumerable<StudentPassRateItem>> GetStudentPassRateAsync(StudentPassRateFilter filter)
        {
            return await _dapper.QueryAsync<StudentPassRateItem>(ReportQueries.StudentPassRate, filter);
        }

        public async Task<StudentPassRateSummaryItem?> GetStudentPassRateSummaryAsync(StudentPassRateSummaryFilter filter)
        {
            return await _dapper.QueryFirstOrDefaultAsync<StudentPassRateSummaryItem>(ReportQueries.StudentPassRateSummary, filter);
        }

        public async Task<IEnumerable<DayOfWeekActivityItem>> GetDayOfWeekActivityAsync(DayOfWeekActivityFilter filter)
        {
            return await _dapper.QueryAsync<DayOfWeekActivityItem>(ReportQueries.DayOfWeekActivity, filter);
        }
    }
}
