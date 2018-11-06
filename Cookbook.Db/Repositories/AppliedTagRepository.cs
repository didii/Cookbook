using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    class AppliedTagRepository : IAppliedTagRepository {
        private readonly ApplicationDbContext _context;

        public AppliedTagRepository(ApplicationDbContext context) {
            _context = context;
        }

        /// <inheritdoc />
        public async Task CreateAsync(AppliedTag tag) {
            await _context.AddAsync(tag);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(long recipeId, long tagId) {
            var entity = await GetAsync(recipeId, tagId);
            _context.Remove(entity);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<AppliedTag>> GetByRecipeAsync(long recipeId) {
            return await BaseQuery().Where(x => x.RecipeId == recipeId).ToListAsync();
        }

        /// <inheritdoc />
        public void Dispose() {
            _context?.Dispose();
        }

        /// <inheritdoc />
        public IEnumerable<AppliedTag> Query() {
            return BaseQuery();
        }

        /// <inheritdoc />
        public async Task<AppliedTag> QuerySingle(Func<IEnumerable<AppliedTag>, IEnumerable<AppliedTag>> predicate) {
            return await ((IQueryable<AppliedTag>)predicate(BaseQuery())).FirstOrDefaultAsync();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<AppliedTag>> Query(Func<IEnumerable<AppliedTag>, IEnumerable<AppliedTag>> predicate) {
            return await ((IQueryable<AppliedTag>)predicate(BaseQuery())).ToListAsync();
        }

        /// <inheritdoc />
        public async Task SaveAsync() {
            await _context.SaveChangesAsync();
        }

        private IQueryable<AppliedTag> BaseQuery() {
            return _context.Set<AppliedTag>().Include(x => x.Recipe).Include(x => x.Tag);
        }

        private async Task<AppliedTag> GetAsync(long recipeId, long tagId) {
            var entity = await BaseQuery().Where(x => x.RecipeId == recipeId && x.TagId == tagId).SingleOrDefaultAsync();
            if (entity == null)
                throw new NotFoundException(typeof(AppliedTag), new {recipeId, tagId});
            return entity;
        }
    }
}