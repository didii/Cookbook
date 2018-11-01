using System;

namespace Cookbook.Domain {
    public class AppliedTag : ITracable, ITrackable {
        public long RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }

        public long TagId { get; set; }

        public virtual Tag Tag { get; set; }

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