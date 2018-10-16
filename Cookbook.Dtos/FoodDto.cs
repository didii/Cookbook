using System;
using System.Collections.Generic;

namespace Cookbook.Dtos {
    public class FoodDto : IDtoBase, IIdProperty, ITracable, ITrackableDto {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }
        public string NamePlural { get; set; }

        public string Description { get; set; }

        //public Image Image { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc />
        public UserDto CreatedBy { get; set; }

        /// <inheritdoc />
        public UserDto UpdatedBy { get; set; }
    }

    public class FoodCreate : IDtoCreateBase {
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public string Description { get; set; }
        //public Image byte[] { get; set; }
    }

    public class FoodUpdate : IDtoUpdateBase {
        public string Name { get; set; }
        public string NamePlural { get; set; }

        public string Description { get; set; }
        //public Image byte[] { get; set; }
    }
}