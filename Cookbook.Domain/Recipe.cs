using System;
using System.Collections.Generic;

namespace Cookbook.Domain {
    public class Recipe : IDbItem, ITracable, ITrackable {
        /// <inheritdoc />
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Servings { get; set; }

        public TimeSpan Duration { get; set; }

        public float EstimatedPrice { get; set; }

        public int Difficulty { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual ICollection<Instruction> Instructions { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<AppliedTag> AppliedTags { get; set; }

        public virtual ICollection<RecipeImage> RecipeImages { get; set; }

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