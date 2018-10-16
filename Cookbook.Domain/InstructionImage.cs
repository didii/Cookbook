using System;

namespace Cookbook.Domain {
    public class InstructionImage : IEntityImage<Instruction> {
        /// <inheritdoc />
        public long Id { get; set; }

        /// <inheritdoc />
        public DateTime CreatedOn { get; set; }

        /// <inheritdoc />
        public DateTime UpdatedOn { get; set; }

        /// <inheritdoc />
        public long ImageId { get; set; }

        /// <inheritdoc />
        public Image Image { get; set; }

        public long InstructionId { get; set; }

        public virtual Instruction Instruction { get; set; }

        /// <inheritdoc />
        long IEntityImage<Instruction>.EntityId {
            get => InstructionId;
            set => InstructionId = value;
        }

        /// <inheritdoc />
        Instruction IEntityImage<Instruction>.Entity {
            get => Instruction;
            set => Instruction = value;
        }

        /// <inheritdoc />
        public int Order { get; set; }
    }
}