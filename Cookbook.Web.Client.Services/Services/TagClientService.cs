using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    internal class TagClientService : ITagClientService {
        private readonly IApiHttpService _http;

        public TagClientService(IApiHttpService http) {
            _http = http;
        }

        /// <inheritdoc/>
        public async Task<IList<TagDto>> GetAllForRecipeAsync(long recipeId) {
            return await _http.GetAsync<IList<TagDto>>($"api/recipes/{recipeId}/tags");
        }

        /// <inheritdoc/>
        public async Task<TagDto> AddTagForRecipeAsync(long recipeId, TagEdit tag) {
            return await _http.PostAsync<TagDto>($"api/recipes/{recipeId}/tags", tag);
        }

        /// <inheritdoc/>
        public async Task RemoveTagFromRecipeAsync(long recipeId, long tagId) {
            var response = await _http.DeleteAsync($"api/recipes/{recipeId}/tags/{tagId}");
            _http.AssertResponse(response);
        }
    }
}