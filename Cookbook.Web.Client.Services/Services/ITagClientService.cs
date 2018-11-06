using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    public interface ITagClientService {
        Task<IEnumerable<TagDto>> GetAllForRecipeAsync(long recipeId);
        Task<TagDto> AddTagForRecipeAsync(long recipeId, TagEdit tag);
        Task RemoveTagFromRecipeAsync(long recipeId, long tagId);
    }
}
