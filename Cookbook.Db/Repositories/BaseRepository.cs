using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    internal abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class, IDbItem {
        protected readonly ApplicationDbContext DbContext;

        protected BaseRepository(ApplicationDbContext dbContext) {
            DbContext = dbContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() {
            return await BaseQuery.ToArrayAsync();
        }

        public virtual async Task<T> GetAsync(long id) {
            var result = await BaseQuery.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) throw new NotFoundException(typeof(Food), id);
            return result;
        }

        public virtual async Task<long> CreateAsync(T entity) {
            await Set.AddAsync(entity);
            return entity.Id;
        }

        public virtual void Update(T food) {
            var entry = Set.Attach(food);
            entry.State = EntityState.Modified;
        }

        public virtual async Task DeleteAsync(long id) {
            var food = await GetAsync(id);
            Set.Remove(food);
        }

        public virtual async Task SaveAsync() {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose() {
            DbContext?.Dispose();
        }

        protected DbSet<T> Set => DbContext.Set<T>();

        protected virtual IQueryable<T> BaseQuery => Set;
    }
}