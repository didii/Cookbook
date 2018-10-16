using System;
using System.Collections.Generic;

namespace Cookbook.Domain {
    public class Image : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public byte[] ByteArray { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<FoodImage> FoodImages { get; set; }

        public virtual ICollection<RecipeImage> RecipeImages { get; set; }

        public virtual ICollection<InstructionImage> InstructionImage { get; set; }

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