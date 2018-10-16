using System;
using System.Collections.Generic;

namespace Cookbook.Domain {
    public class Food : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public string NamePlural { get; set; }

        public string Description { get; set; }

        public virtual ICollection<FoodImage> FoodImages { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Food> Synonyms { get; set; }

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