namespace Cookbook.Domain {
    public interface IDbItem {
        /// <summary>
        /// The internal ID of this item
        /// </summary>
        long Id { get; set; }
    }
}