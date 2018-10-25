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
        public async Task<IEnumerable<Food>> GetAllAsync() {
            return await _dbContext.Set<Food>().ToArrayAsync();
        }

        /// <inheritdoc />
        public async Task<Food> GetAsync(long id) {
            return await _dbContext.Set<Food>().FindAsync(id);
        }

        /// <inheritdoc />
        public async Task AddAsync(Food food) {
            await _dbContext.Set<Food>().AddAsync(food);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Food food) {
            await _dbContext.Set<Food>().FindAsync(food.Id);
            _dbContext.Set<Food>().Update(food);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long id) {
            var food = await _dbContext.Set<Food>().FindAsync(id);
            _dbContext.Set<Food>().Remove(food);
        }

        /// <inheritdoc />
        public async Task SaveAsync() {
            await _dbContext.SaveChangesAsync();
        }

        /// <inheritdoc />
        public void Dispose() {
            _dbContext?.Dispose();
        }
    }
}