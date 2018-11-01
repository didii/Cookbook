using System.Threading.Tasks;
using Cookbook.Business.RecipeServices;
using Cookbook.Dtos;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            await _recipeService.DeleteAsync(id);
            return NoContent();
        }
    }
}