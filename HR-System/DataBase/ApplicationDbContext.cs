using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HR_System.Models;
using Microsoft.EntityFrameworkCore;
using HR_System.ViewModels;

namespace HR_System.DataBase
{
    public class ApplicationDbContext:IdentityDbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<GeneralSetting> GeneralSetting { get; set; }
        public DbSet<OfficialVacation> OfficialVacation { get; set; }
        public DbSet<Absent> Absent { get; set; }
    }
}
