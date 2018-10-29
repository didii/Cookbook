using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Business;
using Cookbook.Business.RecipeServices;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [Route("api/food")]
    [ApiController]
    public class FoodController : Controller {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService) {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IEnumerable<FoodDto>> GetAll() {
            return await _foodService.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodCreate food) {
            await _foodService.CreateAsync(food);
            return new NoContentResult();
        }

        [HttpGet("{id}")]
        public async Task<FoodDto> Get(long id) {
            return await _foodService.GetAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] FoodUpdate food) {
            await _foodService.UpdateAsync(id, food);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            await _foodService.DeleteAsync(id);
            return new NoContentResult();
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing) {
            _foodService?.Dispose();
            base.Dispose(disposing);
        }
    }
}
