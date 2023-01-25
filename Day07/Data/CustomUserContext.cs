using Day07.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day07.Data
{
    public class CustomUserContext : IdentityDbContext<CustomUser, CustomRole, string>
    {
        public CustomUserContext(DbContextOptions options) : base(options)
        {
        }

        //public virtual DbSet<CustomUserRoles> AspNetUserRoles { get; set; }
    }
}
