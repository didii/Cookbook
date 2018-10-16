using System;

namespace Cookbook.Domain {
    public class Quantity : IDbItem, ITracable, ITrackable {
        public long Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public double Multiplier { get; set; }

        public long? QuantityTypeId { get; set; }

        public virtual QuantityType QuantityType { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc />
        public string CreatedById { get; set; }

        /// <inheritdoc />
        public virtual User CreatedBy { get; set; }

        /// <inheritdoc />
        public string UpdatedById { get; set; }

        /// <inheritdoc />
        public virtual User UpdatedBy { get; set; }
    }
}