using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_smarties.Models;


namespace Project_smarties.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserApplicationData> UserApplicationData { get; set; }
        public DbSet<LeaderboardsApplicationData> LeaderboardsApplicationData { get; set; }
        public DbSet<QuizApplicationData> QuizApplicationData { get; set; }
        public DbSet<QuizResultApplicationData> QuizResultApplicationData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //makes the admin role
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";
            //creates an normal user role
            var user = new IdentityRole("user");
            user.NormalizedName = "user";

            //should make the user require the name to be unique
            builder.Entity<UserApplicationData>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<IdentityRole>().HasData(admin, user);
        }
    }
}
