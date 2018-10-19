using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    internal class FoodRepository : IFoodRepository {
        private readonly IDbContext _dbContext;

        public FoodRepository(IDbContext dbContext) {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Food>> GetAll() {
            return await _dbContext.Set<Food>().ToArrayAsync();
        }

        /// <inheritdoc />
        public async Task<Food> Get(int id) {
            return await _dbContext.Set<Food>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task Add(Food food) {
            await _dbContext.Set<Food>().AddAsync(food);
        }

        /// <inheritdoc />
        public async Task Update(Food food) {
            _dbContext.Set<Food>().Update(food);
        }

        /// <inheritdoc />
        public async Task Delete(int id) {
            await _dbContext.Set<Food>().FindAsync(id);
        }
    }
}