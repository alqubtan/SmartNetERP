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

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RolePrivilege> RolePrivileges { get; set; }
    }
}
