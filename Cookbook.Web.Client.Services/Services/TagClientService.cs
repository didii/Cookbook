using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    public class TagClientService : ITagClientService {
        private readonly IApiHttpService _http;

        public TagClientService(IApiHttpService http) {
            _http = http;
        }

        /// <inheritdoc />
        public async Task AddTagForRecipe(long recipeId, TagEdit tag) {
            await _http.PostAsync($"api/recipes/{recipeId}/tags", tag);
        }

        /// <inheritdoc />
        public async Task RemoveTagFromRecipe(long recipeId, long tagId) {
            await _http.DeleteAsync($"api/recipes/{recipeId}/tags/{tagId}");
        }
    }
}
