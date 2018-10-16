namespace Cookbook.Dtos {
    public class PageInfo {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => TotalItems / PageSize;
    }
}