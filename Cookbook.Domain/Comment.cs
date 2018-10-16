using System;

namespace Cookbook.Domain {
    public class Comment : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Message { get; set; }

        public long? ReplyId { get; set; }

        public virtual Comment Reply { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        public string CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        /// <inheritdoc />
        public string UpdatedById { get; set; }

        /// <inheritdoc />
        public virtual User UpdatedBy { get; set; }
    }
}