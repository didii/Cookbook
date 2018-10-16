namespace Cookbook.Domain {
    public interface ITrackable {
        string CreatedById { get; set; }

        User CreatedBy { get; set; }

        string UpdatedById { get; set; }

        User UpdatedBy { get; set; }
    }
}