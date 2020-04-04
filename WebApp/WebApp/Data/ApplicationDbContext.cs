using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApp.EntityTypes;
using WebApp.Models;
using WebApp.Models.Shared;

namespace WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");

            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }

        public override int SaveChanges()
        {
            ApplyCustomRules();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyCustomRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void ApplyCustomRules()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity is ISoftDelete)
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsDeleted"] = true;
                            entry.CurrentValues["DeletionTime"] = DateTime.Now;
                        }
                        break;
                }
            }
        }

    }
}
