using System;

namespace Cookbook.Dtos {
    public abstract class QuantityCommon {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double Multiplier { get; set; }
    }

    public class QuantityDto : QuantityCommon, IDtoBase, IIdProperty, ITracableDto, ITrackableDto {
        public long Id { get; set; }

        public long QuantityTypeId { get; set; }

        public QuantityTypeDto QuantityType { get; set; }

        /// <inheritdoc/>
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc/>
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc/>
        public UserDto CreatedBy { get; set; }

        /// <inheritdoc/>
        public UserDto UpdatedBy { get; set; }
    }

    public class QuantityCreate : QuantityCommon, IDtoCreateBase {
        public long QuantityTypeId { get; set; }
        public QuantityTypeCreate QuantityType { get; set; }
    }

    public class QuantityUpdate : QuantityCommon, IDtoUpdateBase {
        public long? QuantityTypeId { get; set; }
        public QuantityTypeCreate QuantityType{ get; set; }
    }
}
