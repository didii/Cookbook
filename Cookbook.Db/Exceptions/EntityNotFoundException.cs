using System;

namespace Cookbook.Db.Exceptions {
    public class EntityNotFoundException : Exception {
        public int Id { get; }

        public object Entity { get; }

        public object Repository { get; }

        private static string _message = "Entity not found";

        /// <inheritdoc />
        public EntityNotFoundException(int id, object repository) : base(_message) {
            Id = id;
            Repository = repository;
        }

        /// <inheritdoc />
        public EntityNotFoundException(int id, object repository, Exception innerException) : base(_message, innerException) {
            Id = id;
            Repository = repository;
        }

        /// <inheritdoc />
        public EntityNotFoundException(object entity = null, object repository = null) : base(_message) {
            Entity = entity;
            Repository = repository;
        }

        /// <inheritdoc />
        public EntityNotFoundException(Exception innerException, object entity = null, object repository = null) : base(_message, innerException) {
            Entity = entity;
            Repository = repository;
        }
    }
}