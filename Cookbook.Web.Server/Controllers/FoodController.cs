using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [Route("api/food")]
    public class FoodController {

        [HttpGet]
        public async Task<IEnumerable<FoodDto>> GetAllFood() {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<FoodDto> Get(int id) {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task Create(int id, [FromBody] FoodCreate food) {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, [FromBody] FoodUpdate food) {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task Delete(int id) {
            throw new NotImplementedException();
        }
    }
}
