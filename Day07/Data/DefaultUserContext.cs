using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Day07.Data
{
    public class DefaultUserContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DefaultUserContext(DbContextOptions options) : base(options)
        {
        }
    }
}
