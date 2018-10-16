using System.Collections.Generic;

namespace Cookbook.Dtos {
    public class PagedResult<TModel> {
        public Links Links { get; set; }
        public IEnumerable<TModel> Data { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
