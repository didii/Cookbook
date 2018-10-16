using System;
using System.Collections.Generic;

namespace Cookbook.Domain {
    public class Ingredient : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public long FoodId { get; set; }

        public virtual Food Food { get; set; }

        public long QuantityId { get; set; }

        public virtual Quantity Quantity { get; set; }

        public double? QuantityValue { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

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