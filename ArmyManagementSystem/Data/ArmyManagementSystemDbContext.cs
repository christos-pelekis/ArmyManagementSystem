using ArmyManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ArmyManagementSystem.Data
{
    public class ArmyManagementSystemDbContext : DbContext
    {
        public ArmyManagementSystemDbContext(DbContextOptions<ArmyManagementSystemDbContext> options) : base(options)
        {

        }

        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
