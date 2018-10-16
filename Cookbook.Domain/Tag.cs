using System;

namespace Cookbook.Domain {
    public class Tag : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }

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