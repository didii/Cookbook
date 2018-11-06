using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Dtos;

namespace Cookbook.Web.Client.Services {
    class RecipeClientService : IRecipeClientService {
        private readonly IApiHttpService _http;

        public RecipeClientService(IApiHttpService http) {
            _http = http;
        }

        /// <inheritdoc />
        public async Task<RecipeDto> GetAsync(long id) {
            return await _http.GetAsync<RecipeDto>($"api/recipes/{id}");
        }
    }
}