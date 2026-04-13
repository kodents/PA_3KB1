using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceAnalysis.Application.Reports;
using PerformanceAnalysis.Infrastructure.Auth.Extensions;
using PerformanceAnalysis.Reports.DayOfWeekActivity;
using PerformanceAnalysis.Reports.GroupLeadersAndLaggards;
using PerformanceAnalysis.Reports.GroupTrend;
using PerformanceAnalysis.Reports.StudentMonthlyProgress;
using PerformanceAnalysis.Reports.StudentPassRate;
using PerformanceAnalysis.Reports.StudentPassRateSummary;
using PerformanceAnalysis.Reports.StudentRating;
using PerformanceAnalysis.Reports.StudentTestResult;

namespace PerformanceAnalysis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("group-leaders")]
        public async Task<IActionResult> GetGroupLeaders([FromQuery] GroupLeadersAndLaggardsFilter filter)
        {
            if (HttpContext.IsStudent())
            {
                return Forbid();
            }

            var result = await _reportService.GetGroupLeadersAndLaggardsAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-test-results")]
        public async Task<IActionResult> GetStudentTestResults([FromQuery] StudentTestResultsFilter filter)
        {
            if (!ValidateStudentAccess(filter.StudentId))
            {
                return Forbid();
            }

            if (HttpContext.IsStudent() && filter.StudentId == null)
            {
                filter.StudentId = HttpContext.GetStudentId();
            }

            var result = await _reportService.GetStudentTestResultsAsync(filter);
            return Ok(result);
        }

        [HttpGet("group-trend")]
        public async Task<IActionResult> GetGroupTrend([FromQuery] GroupTrendFilter filter)
        {
            if (HttpContext.IsStudent())
            {
                return Forbid();
            }

            var result = await _reportService.GetGroupTrendAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-monthly-progress")]
        public async Task<IActionResult> GetStudentMonthlyProgress([FromQuery] StudentMonthlyProgressFilter filter)
        {
            if (!ValidateStudentAccess(filter.StudentId))
            {
                return Forbid();
            }

            if (HttpContext.IsStudent() && filter.StudentId == null)
            {
                filter.StudentId = HttpContext.GetStudentId();
            }

            var result = await _reportService.GetStudentMonthlyProgressAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-rating")]
        public async Task<IActionResult> GetStudentRating([FromQuery] StudentRatingFilter filter)
        {
            if (HttpContext.IsStudent())
            {
                return Forbid();
            }

            var result = await _reportService.GetStudentRatingAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-pass-rate")]
        public async Task<IActionResult> GetStudentPassRate([FromQuery] StudentPassRateFilter filter)
        {
            if (HttpContext.IsStudent())
            {
                return Forbid();
            }

            var result = await _reportService.GetStudentPassRateAsync(filter);
            return Ok(result);
        }

        [HttpGet("student-pass-rate-summary")]
        public async Task<IActionResult> GetStudentPassRateSummary([FromQuery] StudentPassRateSummaryFilter filter)
        {
            if (!ValidateStudentAccess(filter.StudentId))
            {
                return Forbid();
            }

            if (HttpContext.IsStudent() && filter.StudentId == null)
            {
                filter.StudentId = HttpContext.GetStudentId();
            }

            var result = await _reportService.GetStudentPassRateSummaryAsync(filter);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet("day-of-week-activity")]
        public async Task<IActionResult> GetDayOfWeekActivity([FromQuery] DayOfWeekActivityFilter filter)
        {
            if (HttpContext.IsStudent())
            {
                return Forbid();
            }

            var result = await _reportService.GetDayOfWeekActivityAsync(filter);
            return Ok(result);
        }

        private bool ValidateStudentAccess(int? studentId)
        {
            if (HttpContext.IsManager())
            {
                return true;
            }

            if (HttpContext.IsStudent())
            {
                var currentStudentId = HttpContext.GetStudentId();

                if (studentId == null)
                {
                    return currentStudentId != null;
                }

                return currentStudentId == studentId;
            }

            return false;
        }
    }
}
