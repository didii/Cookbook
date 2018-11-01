using Cookbook.Db.Contexts;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    internal class TagRepository : BaseRepository<Tag>, ITagRepository {
        /// <inheritdoc />
        public TagRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}