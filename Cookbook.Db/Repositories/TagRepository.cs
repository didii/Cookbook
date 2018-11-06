using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    internal class TagRepository : BaseRepository<Tag>, ITagRepository {
        /// <inheritdoc />
        public TagRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        /// <inheritdoc />
        public async Task<Tag> GetByName(string name) {
            return await BaseQuery.SingleOrDefaultAsync(x => x.Name == name);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(long id) {
            var entity = await GetAsync(id);
            var entry = DbContext.Attach(entity);
            entry.State = EntityState.Modified;
        }
    }
}