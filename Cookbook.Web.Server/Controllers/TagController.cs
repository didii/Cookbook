using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Business.RecipeServices;
using Cookbook.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cookbook.Web.Server.Controllers {
    [ApiController]
    [Route("api/tags")]
    public class TagController : Controller {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<long> Create([FromBody] TagEdit tag) {
            return await _tagService.CreateAsync(tag);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] TagEdit tag) {
            await _tagService.UpdateAsync(id, tag);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id) {
            await _tagService.DeleteAsync(id);
            return NoContent();
        }
    }
}
