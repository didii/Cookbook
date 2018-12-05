using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Tests {
    public class Tests {

        [Test]
        public async Task Test1() {
            var optionBuilder =
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cookbook;Integrated Security=True;Connect Timeout=30");

            var context = new ApplicationDbContext(optionBuilder.Options);

            var recipes = await context.Recipes.ToListAsync();

            Assert.That(recipes, Is.Not.Null);
        }
    }
}