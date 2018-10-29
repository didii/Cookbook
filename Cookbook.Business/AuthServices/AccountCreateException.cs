using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Cookbook.Business.AuthServices {
    public class AccountCreateException : Exception {
        private static string CreateMessage(string accountName, IEnumerable<IdentityError> errors) {
            var builder = new StringBuilder();
            builder.Append("Could not create user ");
            builder.Append(accountName);
            builder.AppendLine(". Errors:");
            foreach (var error in errors) {
                builder.Append("- ");
                builder.Append(error.Code);
                builder.Append(": ");
                builder.AppendLine(error.Description);
            }
            return builder.ToString();
        }

        public AccountCreateException(string accountName, IEnumerable<IdentityError> errors) : base(CreateMessage(accountName, errors)) {}
    }
}
