using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Business.RecipeServices {
    public interface IRecipeService {
        Task<RecipeDto> GetAsync(long id);
        Task<long> CreateEmptyAsync();
        Task UpdateAsync(long id, RecipeUpdate recipe);
        Task DeleteAsync(long id);
    }
}
