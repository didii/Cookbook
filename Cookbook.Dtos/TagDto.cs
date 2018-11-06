using System;

namespace Cookbook.Dtos {
    public class TagDto : IDtoBase, IIdProperty, ITracableDto, ITrackableDto {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public UserDto CreatedBy { get; set; }
        public UserDto UpdatedBy { get; set; }
    }

    public class TagEdit : IDtoCreateBase, IDtoUpdateBase {
        public string Name { get; set; }
    }

}