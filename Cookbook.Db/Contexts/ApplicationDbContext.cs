using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cookbook.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Contexts {
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IDbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }

        /// <inheritdoc />
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            var now = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()) {
                if (entry.State == EntityState.Added) {
                    if (entry.Entity is ITracable tracable) {
                        tracable.CreatedOn = now;
                        tracable.UpdatedOn = now;
                    }
                }
                if (entry.State == EntityState.Modified) {
                    if (entry.Entity is ITracable tracable) {
                        tracable.UpdatedOn = now;
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            CreateModel(builder);
        }

        private void CreateModel(ModelBuilder builder) {
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "Identity");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "Identity");

            builder.Entity<FoodImage>().HasIndex(fi => new { fi.FoodId, fi.ImageId }).IsUnique();
            builder.Entity<InstructionImage>().HasIndex(ii => new { ii.InstructionId, ii.ImageId }).IsUnique();
            builder.Entity<RecipeImage>().HasIndex(ri => new { ri.RecipeId, ri.ImageId }).IsUnique();
        }

        private void Seed(ModelBuilder builder) {
            //builder.Entity<User>();
        }
    }
}