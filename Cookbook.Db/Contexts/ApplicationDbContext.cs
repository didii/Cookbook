using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Contexts {
    public class ApplicationDbContext : IdentityDbContext<User>, IDbContext {
        //public ApplicationDbContext() : base(new DbContextOptions<ApplicationDbContext>()) {}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims", "Identity");
            builder.Entity<IdentityRole>().ToTable("AspNetRoles", "Identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims", "Identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins", "Identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles", "Identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens", "Identity");

            builder.Entity<FoodImage>().HasIndex(fi => new { fi.FoodId, fi.ImageId }).IsUnique();
            builder.Entity<InstructionImage>().HasIndex(ii => new { ii.InstructionId, ii.ImageId }).IsUnique();
            builder.Entity<RecipeImage>().HasIndex(ri => new { ri.RecipeId, ri.ImageId }).IsUnique();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /// <inheritdoc />
        public override int SaveChanges() {
            var now = DateTime.Now;
            foreach (var entry in ChangeTracker.Entries()) {
                if (entry.State == EntityState.Added) {
                    if (entry.Entity is ITracable tracable) {
                        tracable.CreatedOn = now;
                        tracable.UpdatedOn = now;
                    }
                }
            }
            return base.SaveChanges();
        }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        internal async Task<int> SetIdentityInsert<T>(bool on) where T : class {
            return await SetIdentityInsert(typeof(T), on);
        }

        private async Task<int> SetIdentityInsert(Type entityType, bool on) {
            var attr = entityType.GetCustomAttribute<TableAttribute>();
            if (attr == null)
                return await SetIdentityInsert(entityType.Name, on);
            return await SetIdentityInsert(attr.Name, on, attr.Schema);
        }

        private async Task<int> SetIdentityInsert(string tableName, bool on, string schemaName = null) {
            return await Database.ExecuteSqlCommandAsync(
                $"SET IDENTITY_INSERT [{(schemaName != null ? schemaName + "].[" : "")}{tableName}] {(@on ? "ON" : "OFF")}");
        }

        internal async Task InsertWithId<T>(T entity) where T : class {
            var table = GetFullTableName<T>();
            var builder = new StringBuilder();
            builder.AppendLine(GenerateIdentityInsertCommand(table, true));
        }

        private string GetFullTableName<T>() where T : class {
            var type = typeof(T);
            var attr = type.GetCustomAttribute<TableAttribute>();
            return attr == null ? $"[{type.Name}]" : $"[{attr.Schema}].[{attr.Name}]";
        }

        private string GenerateIdentityInsertCommand(string tableName, bool on) {
            this.SaveChangesAsync();
            return $"SET IDENTITY_INSERT {tableName} {(on ? "ON" : "OFF")};";
        }

        //private string GenerateInsertCommand<T>(IEnumerable<T> entities) where T : class {
        //    var builder = new StringBuilder();
        //    builder.Append("INSERT INTO ");
        //    builder.Append(GetFullTableName<T>());
        //    builder.Append(" (");
        //}
    }
}