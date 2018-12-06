using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Business.RecipeServices;
using Cookbook.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [Route("api/recipes")]
    [ApiController]
    public class RecipesController : Controller {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService) {
            _recipeService = recipeService;
        }

        [HttpPost]
        public async Task<long> Create() {
            return await _recipeService.CreateEmptyAsync();
        }

        [HttpGet("{id}")]
        public async Task<RecipeDto> Get(int id) {
            return await _recipeService.GetAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecipeUpdate recipe) {
            await _recipeService.UpdateAsync(id, recipe);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<RecipeDto> Patch(int id, [FromBody] JsonPatchDocument<RecipeUpdate> patch) {
            return await _recipeService.PatchAsync(id, patch);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _recipeService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/tags")]
        public async Task<IEnumerable<TagDto>> GetTags(long id) {
            return await _recipeService.GetTagsAsync(id);
        }

        [HttpPost("{id}/tags")]
        public async Task<TagDto> AddTag(long id, [FromBody] TagEdit tag) {
            return await _recipeService.AddTagAsync(id, tag);
        }

        [HttpDelete("{id}/tags/{tagId}")]
        public async Task<IActionResult> RemoveTag(long id, long tagId) {
            await _recipeService.RemoveTagAsync(id, tagId);
            return NoContent();
        }
    }
}