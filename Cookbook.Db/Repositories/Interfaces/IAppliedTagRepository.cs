using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Domain;

namespace Cookbook.Db.Repositories {
    public interface IAppliedTagRepository : IBaseRepository<AppliedTag> {
        Task CreateAsync(AppliedTag tag);
        Task DeleteAsync(long recipeId, long tagId);
        Task<IEnumerable<AppliedTag>> GetByRecipeAsync(long recipeId);
    }
}
