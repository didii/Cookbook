namespace Cookbook.Domain {
    public interface IEntityImage<TEntity> : IDbItem, ITracable where TEntity : IDbItem {
        long ImageId { get; set; }
        Image Image { get; set; }

        long EntityId { get; set; }
        TEntity Entity { get; set; }

        int Order { get; set; }
    }
}