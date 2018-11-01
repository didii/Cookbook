using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    internal class FoodRepository : BaseRepository<Food>, IFoodRepository {
        public FoodRepository(ApplicationDbContext dbContext) : base(dbContext) {}
    }
}