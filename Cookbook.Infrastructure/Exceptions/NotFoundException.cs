using System;

namespace Cookbook.Infrastructure.Exceptions {
    public class NotFoundException : Exception {
        private const string _message1 = "Could not find entity {0}";
        private const string _message2 = _message1 + " with ID {1}";

        private static string CreateMessage(Type type) {
            return string.Format(_message1, type.Name);
        }
        private static string CreateMessage(Type type, object id) {
            return string.Format(_message2, type.Name, id);
        }

        public NotFoundException(Type type, object id) : base(CreateMessage(type)) {
            EntityType = type;
            EntityId = id;
        }

        public NotFoundException(Type type, object id, Exception innerException) : base(CreateMessage(type), innerException) {
            EntityType = type;
            EntityId = id;
        }

        public Type EntityType { get; }

        public object EntityId { get; }
    }
}