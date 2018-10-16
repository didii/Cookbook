using System;
using System.Linq;
using System.Security.Cryptography;

namespace Cookbook.Infrastructure {
    public sealed class HashGenerator : IHashGenerator {
        private RandomNumberGenerator _rng;
        private SHA256 _sha;
        private const int MinLength = 5;
        private const int SaltSize = 16;

        public HashGenerator() {
            _rng = RandomNumberGenerator.Create();
            _sha = SHA256.Create();
        }

        /// <inheritdoc />
        public byte[] GetSalt() {
            byte[] salt = new byte[SaltSize];
            _rng.GetNonZeroBytes(salt);
            return salt;
        }

        /// <inheritdoc />
        public byte[] Generate(string password, out byte[] salt) {
            if (password == null)
                throw new ArgumentNullException(nameof(password));
            if (password.Length < MinLength)
                throw new ArgumentException("Password must have a length of 5 or more characters", nameof(password));

            salt = GetSalt();
            return Generate(password, salt);
        }

        /// <inheritdoc />
        public byte[] Generate(string password, byte[] salt) {
            var passWithSalt = AppendByteArrays(salt, StringToByteArray(password));
            return _sha.ComputeHash(passWithSalt);
        }

        private byte[] StringToByteArray(string str) {
            return str.Select(c => (byte)c).ToArray();
        }

        private byte[] AppendByteArrays(byte[] lhs, byte[] rhs) {
            var result = new byte[lhs.Length + rhs.Length];
            for (int i = 0; i < lhs.Length; i++)
                result[i] = lhs[i];
            for (int i = 0; i < rhs.Length; i++)
                result[i + lhs.Length] = rhs[i];
            return result;
        }
    }
}