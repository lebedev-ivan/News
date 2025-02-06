using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace News.Domain
{
    public class ArticlesDbContext : IdentityDbContext<IdentityUser>
    {
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options) : base(options) { }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Article>().HasData(new Article
            {
                Id = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0"),
                Title = "В космос запущен новый спутник",
                Text = "text text text"
            });
        }
    }
}