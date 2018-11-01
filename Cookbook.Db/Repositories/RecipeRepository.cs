using System.Linq;
using System.Threading.Tasks;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Db.Repositories {
    class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository {
        /// <inheritdoc />
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        /// <inheritdoc />
        protected override IQueryable<Recipe> BaseQuery => Set.Include(x => x.AppliedTags)
                                                              .ThenInclude(x => x.Tag);
    }
}