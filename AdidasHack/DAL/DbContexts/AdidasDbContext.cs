using AdidasHack.Core.Entities;
using AdidasHack.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContexts
{
    public class AdidasDbContext : IdentityDbContext<User, Role, int>
    {
        public AdidasDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<UserSport> UserSports { get; set; }

        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<ChallengeResult> ChallengeResults { get; set; }

        public DbSet<ChallengeResultCoordinate> ChallengeResultCoordinates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");

            modelBuilder.Entity<UserSport>()
                .HasKey(x => new { x.UserId, x.SportId });

            modelBuilder.Entity<UserSport>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserSports)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
