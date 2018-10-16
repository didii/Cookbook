using System;

namespace Cookbook.Domain {
    public class QuantityType : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        //public virtual Quantity BaseQuantity { get; set; }

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