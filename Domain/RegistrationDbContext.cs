using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace News.Domain
{
    public class RegistrationDbContext : IdentityDbContext<IdentityUser>
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options)
            : base(options)
        {
        }
    }
}