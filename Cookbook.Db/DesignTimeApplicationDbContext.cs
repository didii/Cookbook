using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Db {
    public class DesignTimeApplicationDbContext : IDesignTimeDbContextFactory<ApplicationDbContext> {
        /// <inheritdoc />
        public ApplicationDbContext CreateDbContext(string[] args) {
            var opts = new DbContextOptionsBuilder<ApplicationDbContext>();
            opts.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cookbook;Integrated Security=True;Connect Timeout=30");
            return new ApplicationDbContext(opts.Options);
        }
    }
}
