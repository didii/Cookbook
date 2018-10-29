using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Db.Contexts {
    internal class CookbookSeeder : ISeeder {
        /// <inheritdoc />
        public void Seed(IServiceScope scope, IConfiguration configuration) {
            //foreach (var qt in qts)
            //    context.Set<QuantityTypeEntity>().AddOrUpdate(qt);
            //context.SaveChanges();

            //foreach (var q in qs)
            //    context.Set<QuantityEntity>().AddOrUpdate(q);
            //context.SaveChanges();

            using (var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>()) {
                AddOrUpdateRole(roleManager, "admin").Wait();
            }

            using (var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>()) {
                var admin = new User() { UserName = "admin", Email = "dieter.vbroeck@gmail.com", EmailConfirmed = true, };
                admin = AddOrUpdateUser(userManager, admin, "admin").Result;
                if (!userManager.IsInRoleAsync(admin, "admin").Result) {
                    userManager.AddToRoleAsync(admin, "admin").Wait();
                }
                var user = new User() { UserName = "user", Email = "dieter.vbroeck@gmail.com", EmailConfirmed = true };
                AddOrUpdateUser(userManager, user, "user").Wait();
            }

            //using (var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()) {
            //    using (var transScope = new TransactionScope()) {
            //        context.SetIdentityInsert<QuantityTypeEntity>(true).Wait();
            //        foreach (var qt in QuantityTypes)
            //            AddOrUpdateEntity(context, qt);
            //        context.SaveChanges();
            //        context.SetIdentityInsert<QuantityTypeEntity>(false).Wait();
            //        transScope.Complete();
            //    }
            //    using (var transScope = new TransactionScope()) {
            //        context.SetIdentityInsert<QuantityEntity>(true).Wait();
            //        foreach (var q in Quantities)
            //            AddOrUpdateEntity(context, q);
            //        context.SaveChanges();
            //        context.SetIdentityInsert<QuantityEntity>(false).Wait();
            //        transScope.Complete();
            //    }
            //}
        }

        private static async Task AddOrUpdateRole(RoleManager<IdentityRole> roleManager, string roleName) {
            if (!roleManager.RoleExistsAsync(roleName).Result) {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                    Console.WriteLine($"Creation of role {roleName} failed:\n" + GetErrorString(result.Errors));
            }
        }

        private static async Task<User> AddOrUpdateUser(UserManager<User> userManager, User user, string password) {
            var existing = await userManager.FindByNameAsync(user.UserName);
            if (existing == null) {
                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                    Console.WriteLine($"Creation of user {user.UserName} failed:\n" + GetErrorString(result.Errors));
                else
                    existing = await userManager.FindByNameAsync(user.UserName);
            }
            return existing;
        }

        private static string GetErrorString(IEnumerable<IdentityError> errors) {
            var builder = new StringBuilder();
            foreach (var error in errors)
                builder.AppendLine($"- {error.Code} - {error.Description}");
            return builder.ToString();
        }

        private static void AddOrUpdateEntity<T>(DbContext context, T entity) where T : class, IDbItem {
            var set = context.Set<T>();
            var existing = set.FirstOrDefault(e => e.Id == entity.Id);
            if (existing == null)
                set.Add(entity);
        }

        private static User Admin { get; } = new User() { UserName = "admin", Email = "dieter.vbroeck@gmail.com", EmailConfirmed = true };
        private static User User { get; } = new User() { UserName = "user", Email = "dieter.vbroeck@gmail.com", EmailConfirmed = true };

        private static IList<QuantityType> QuantityTypes { get; } = new[] {
            new QuantityType { Id = 1, Name = "mass", CreatedBy = Admin, UpdatedBy = Admin },
            new QuantityType { Id = 2, Name = "volume", CreatedBy = Admin, UpdatedBy = Admin },
            new QuantityType { Id = 3, Name = "none", CreatedBy = Admin, UpdatedBy = Admin }
        };

        private static IList<Quantity> Quantities { get; } = new[] {
            new Quantity {
                Id = 1, Name = "kilogram", ShortName = "kg", Multiplier = 0.001, QuantityType = QuantityTypes[0], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 2, Name = "gram", ShortName = "g", Multiplier = 1, QuantityType = QuantityTypes[0], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 3, Name = "milligram", ShortName = "mg", Multiplier = 1000, QuantityType = QuantityTypes[0], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 4, Name = "ounces", ShortName = "oz", Multiplier = 0.035274, QuantityType = QuantityTypes[0], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 5, Name = "pounds", ShortName = "lbs", Multiplier = 0.002205, QuantityType = QuantityTypes[0], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 6, Name = "kubieke centimeter", ShortName = "cm³", Multiplier = 1000, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 7, Name = "kubieke decimeter", ShortName = "dm³", Multiplier = 1, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 8, Name = "liter", ShortName = "l", Multiplier = 1, QuantityType = QuantityTypes[1], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 9, Name = "deciliter", ShortName = "dl", Multiplier = 10, QuantityType = QuantityTypes[1], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 10, Name = "centiliter", ShortName = "cl", Multiplier = 100, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 11, Name = "milliliter", ShortName = "ml", Multiplier = 1000, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 12, Name = "pints", ShortName = "pt", Multiplier = 2.113376, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 13, Name = "eetlepel", ShortName = "el", Multiplier = 67.628045, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 14, Name = "theelepel", ShortName = "tl", Multiplier = 202.884136, QuantityType = QuantityTypes[1], CreatedBy = Admin,
                UpdatedBy = Admin
            },
            new Quantity {
                Id = 15, Name = "", ShortName = "", Multiplier = 1, QuantityType = QuantityTypes[2], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 16, Name = "snufje", ShortName = "snufje", Multiplier = 1, QuantityType = QuantityTypes[2], CreatedBy = Admin, UpdatedBy = Admin
            },
            new Quantity {
                Id = 17, Name = "beetje", ShortName = "beetje", Multiplier = 1, QuantityType = QuantityTypes[2], CreatedBy = Admin, UpdatedBy = Admin
            },
        };
    }
}