using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Business;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [Route("api/food")]
    public class FoodController {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService) {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IEnumerable<FoodDto>> GetAllFood() {
            return await _foodService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<FoodDto> Get(int id) {
            return await _foodService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] FoodCreate food) {
            await _foodService.CreateAsync(food);
            return new NoContentResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FoodUpdate food) {
            await _foodService.UpdateAsync(id, food);
            return new NoContentResult();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            await _foodService.DeleteAsync(id);
            return new NoContentResult();
        }
    }
}
