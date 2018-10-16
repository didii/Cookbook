namespace Cookbook.Dtos {
    public interface ITrackableDto {
        UserDto CreatedBy { get; set; }
        UserDto UpdatedBy { get; set; }
    }
}
