using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Cookbook.Web.Client.Services.Extensions;

namespace Cookbook.Web.Client.Services {
    public class TagService : ITagService {
        private readonly HttpClient _http;

        public TagService(HttpClient http) {
            _http = http;
        }

        /// <inheritdoc />
        public async Task SetTagForRecipe(long recipeId, TagEdit tag) {
            await _http.PostJsonAsync($"api/recipes/{recipeId}/tags", tag);
        }

        /// <inheritdoc />
        public async Task RemoveTagFromRecipe(long recipeId, long tagId) {
            await _http.DeleteAsync($"api/recipes/{recipeId}/tags/{tagId}");
        }
    }
}
