using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiMVCApplication.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;
        public DbSet<UserState> UserStates { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().HasData(
                new UserGroup { Id = 1, Code = "Admin", Description = "Administrator actions" },
                new UserGroup { Id = 2, Code = "User", Description = "Users actions" }
                );

            modelBuilder.Entity<UserState>().HasData(
                new UserState { Id = 1, Code = "Active", Description = "Active user" },
                new UserState { Id = 2, Code = "Blocked", Description = "Blocked user" }
                );

            modelBuilder.Entity<User>().Property(u => u.UserStateId).HasDefaultValue(1);

            modelBuilder.Entity<User>().Property(u => u.CreatedDate).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
        }
    }
}