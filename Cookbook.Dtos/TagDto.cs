using System;

namespace Cookbook.Dtos {
    public abstract class TagCommon {
        public string Name { get; set; }
    }

    public class TagDto : TagCommon, IDtoBase, IIdProperty, ITracableDto, ITrackableDto {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto UpdatedBy { get; set; }
    }

    public class TagCreate : TagCommon, IDtoCreateBase { }

    public class TagUpdate : TagCommon, IDtoUpdateBase { }
}