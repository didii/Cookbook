using System;
using System.Collections.Generic;

namespace Cookbook.Domain {
    public class Instruction : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<Image> Images { get; set; }

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