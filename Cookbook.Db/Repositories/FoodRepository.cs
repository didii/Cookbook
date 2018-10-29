using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    internal class FoodRepository : IFoodRepository {
        private readonly ApplicationDbContext _dbContext;

        public FoodRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Food>> GetAllAsync() {
            return await _dbContext.Set<Food>().ToArrayAsync();
        }

        /// <inheritdoc />
        public async Task<Food> GetAsync(long id) {
            var result = await _dbContext.Set<Food>().FindAsync(id);
            if (result == null) throw new NotFoundException(typeof(Food), id);
            return result;
        }

        /// <inheritdoc />
        public async Task AddAsync(Food food) {
            await _dbContext.Set<Food>().AddAsync(food);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(Food food) {
            var found = await _dbContext.Set<Food>().FindAsync(food.Id);
            if (found == null) throw new NotFoundException(typeof(Food), food.Id);
            _dbContext.Set<Food>().Update(food);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long id) {
            var food = await _dbContext.Set<Food>().FindAsync(id);
            if (food == null) throw new NotFoundException(typeof(Food), id);
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