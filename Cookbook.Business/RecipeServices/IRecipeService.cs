using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Cookbook.Business.RecipeServices {
    public interface IRecipeService {
        Task<RecipeDto> GetAsync(long id);
        Task<long> CreateEmptyAsync();
        Task UpdateAsync(long id, RecipeUpdate recipe);
        Task<RecipeDto> PatchAsync(int id, JsonPatchDocument<RecipeUpdate> patch);
        Task DeleteAsync(long id);
        Task<IEnumerable<TagDto>> GetTagsAsync(long id);
        Task<TagDto> AddTagAsync(long id, TagEdit tag);
        Task RemoveTagAsync(long id, long tagId);
    }
}
