using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

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

        /// <inheritdoc />
        public async Task<RecipeDto> PatchAsync(long id, IEnumerable<Operation<RecipeUpdate>> ops) {
            return await _http.PatchAsync<RecipeDto>($"api/recipes/{id}", ops);
        }
    }
}