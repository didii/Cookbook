namespace Cookbook.Dtos {
    /// <summary>
    /// Requires object to have the property <see cref="Id" />
    /// </summary>
    public interface IIdProperty {
        /// <summary>
        /// The unique ID of this object
        /// </summary>
        long Id { get; set; }
    }
}