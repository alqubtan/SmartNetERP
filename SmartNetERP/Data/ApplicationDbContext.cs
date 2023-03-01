using Microsoft.EntityFrameworkCore;
using SmartNetERP.Models.Master;

namespace SmartNetERP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<MarriageStatus> MarriageStatuses { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
   
    }
}
