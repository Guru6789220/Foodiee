using Authentication_API.Models;
using Authentication_API.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication_API.DB
{
    public class DBConnect:IdentityDbContext<ApplicationUser,RolesMaster,string>
    {
        public DBConnect(DbContextOptions<DBConnect> options):base(options) 
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<RolesMaster> RolesMasters { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
