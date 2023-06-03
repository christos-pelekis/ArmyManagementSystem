using ArmyManagementSystem.Data;
using ArmyManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArmyManagementSystem.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly ArmyManagementSystemDbContext _context;

        public StatisticsController(ArmyManagementSystemDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve the leave requests for the current year
            var leaveRequests = await _context.LeaveRequests
                .Where(lr => lr.StartDate.Year == DateTime.UtcNow.Year)
                .ToListAsync();

			ViewBag.MonthlyLeaveRequestCounts = GenerateMonthlyLeaveRequestCounts(leaveRequests);

            ViewBag.WeeklyLeaveRequestCounts = GenerateWeeklyLeaveRequestCounts(leaveRequests);

            ViewBag.DailyLeaveRequestCounts = GenerateDailyLeaveRequestCounts(leaveRequests);

            ViewBag.LeaveTypeCounts = GenerateLeaveTypeCounts(leaveRequests);
            
            ViewBag.MaxLeaveDays = leaveRequests.Max(lr => lr.LeaveDays);
            
            ViewBag.MinLeaveDays = leaveRequests.Min(lr => lr.LeaveDays);

            ViewBag.AvgLeaveDays = leaveRequests.Average(lr => lr.LeaveDays).ToString("0.##");

            return View();
        }

        /// <summary>
        /// Generates an array of monthly leave request counts for the current year.
        /// </summary>
        /// <param name="leaveRequests">The list of leave requests to count.</param>
        /// <returns>An array of dynamic objects representing the monthly leave request counts.</returns>
        private dynamic[] GenerateMonthlyLeaveRequestCounts(List<LeaveRequest> leaveRequests)
        {
            var currentYear = DateTime.UtcNow.Year;
            var monthlyLeaveRequestCounts = new dynamic[12]; // Array to store monthly counts

            for (int i = 0; i < 12; i++)
            {
                // Get the month name in the format "MMM yyyy" (e.g., "Jan 2023")
                var monthName = new DateTime(currentYear, i + 1, 1).ToString("MMM yyyy");

                // Count the leave requests whose starting date belongs to the current month
                var count = leaveRequests.Count(lr => lr.StartDate.Month == i + 1);

                // Create an anonymous object representing the month and its corresponding count
                monthlyLeaveRequestCounts[i] = new { label = monthName, y = count };
            }

            return monthlyLeaveRequestCounts;
        }


        /// <summary>
        /// Generates an array of weekly leave request counts within a specified range of weeks.
        /// </summary>
        /// <param name="leaveRequests">The list of leave requests to count.</param>
        /// <returns>An array of dynamic objects representing the weekly leave request counts.</returns>
        private dynamic[] GenerateWeeklyLeaveRequestCounts(List<LeaveRequest> leaveRequests)
        {
            var currentYear = DateTime.UtcNow.Year;
            var startDate = new DateTime(currentYear, 1, 1); // Start from the first day of the current year
            var endDate = new DateTime(currentYear, 12, 31); // Go up to the last day of the current year
            var weeklyLeaveRequestCounts = new List<dynamic>();

            var currentDate = startDate;
            while (currentDate <= endDate)
            {
                var weekEnd = currentDate.AddDays(6); // Each week lasts for 7 days

                var weekRange = currentDate.ToString("MMM d") + " - " + weekEnd.ToString("MMM d, yyyy");
                var count = leaveRequests.Count(lr => lr.StartDate >= currentDate && lr.StartDate <= weekEnd);
                weeklyLeaveRequestCounts.Add(new { label = weekRange, y = count });

                currentDate = weekEnd.AddDays(1); // Move to the next week
            }

            return weeklyLeaveRequestCounts.ToArray();
        }


        /// <summary>
        /// Generates daily leave request counts for each day of the current month based on the given list of leave requests.
        /// </summary>
        /// <param name="leaveRequests">The list of leave requests to analyze.</param>
        /// <returns>An array of dynamic objects representing the daily leave request counts.</returns>
        private dynamic[] GenerateDailyLeaveRequestCounts(List<LeaveRequest> leaveRequests)
        {
            // Get the current date in UTC
            var currentDate = DateTime.UtcNow.Date;

            // Determine the start date as the first day of the current month
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Determine the end date as the last day of the current month
            var endDate = startDate.AddMonths(1).AddDays(-1);

            // Create an array to store the daily leave request counts
            var dailyLeaveRequestCounts = new dynamic[endDate.Day];

            for (int i = 0; i < endDate.Day; i++)
            {
                // Calculate the date for the current iteration
                var date = startDate.AddDays(i);

                // Count the number of leave requests that start on the current date
                var count = leaveRequests.Count(lr => lr.StartDate.Date == date);

                // Create an anonymous object representing the date and its corresponding count
                var dailyCountObject = new { label = date.ToString("MMM d"), y = count };

                dailyLeaveRequestCounts[i] = dailyCountObject;
            }

            return dailyLeaveRequestCounts;
        }


        /// <summary>
        /// Generates counts for each distinct leave type in the given list of leave requests.
        /// </summary>
        /// <param name="leaveRequests">The list of leave requests to analyze.</param>
        /// <returns>An array of dynamic objects representing the leave type counts.</returns>
        private dynamic[] GenerateLeaveTypeCounts(List<LeaveRequest> leaveRequests)
        {
            // Get distinct leave types from the leave requests
            var distinctLeaveTypes = leaveRequests.Select(lr => lr.LeaveType).Distinct().ToList();

            // Create an array to store leave type counts
            var leaveTypeCounts = new dynamic[distinctLeaveTypes.Count];

            for (int i = 0; i < distinctLeaveTypes.Count; i++)
            {
                var currentLeaveType = distinctLeaveTypes[i];

                // Count the number of leave requests with the current leave type
                var leaveTypeCount = leaveRequests.Count(lr => lr.LeaveType == currentLeaveType);

                // Create an anonymous object representing the leave type and its corresponding count
                var leaveTypeCountObject = new { label = currentLeaveType, y = leaveTypeCount };

                leaveTypeCounts[i] = leaveTypeCountObject;
            }

            return leaveTypeCounts;
        }

    }
}
