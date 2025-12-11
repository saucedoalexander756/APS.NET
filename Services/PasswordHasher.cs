using System.Security.Cryptography;
using System.Text;

namespace ApiVete.Services
{
    // Helper simple para hashing/verification (SHA256 + salt).
    // Mejora futura: usar una librería de hashing especializada (Argon2/BCrypt).
    public static class PasswordHasher
    {
        public static string CreateHash(string password)
        {
            var saltBytes = RandomNumberGenerator.GetBytes(16);
            var salt = Convert.ToBase64String(saltBytes);
            var hash = ComputeHash(salt, password);
            return $"{salt}:{hash}";
        }

        public static bool Verify(string password, string stored)
        {
            if (string.IsNullOrWhiteSpace(stored)) return false;
            var parts = stored.Split(':');
            if (parts.Length != 2) return false;

            var salt = parts[0];
            var storedHash = parts[1];
            var computedHash = ComputeHash(salt, password);

            var storedBytes = Convert.FromBase64String(storedHash);
            var computedBytes = Convert.FromBase64String(computedHash);

            return CryptographicOperations.FixedTimeEquals(storedBytes, computedBytes);
        }

        private static string ComputeHash(string salt, string password)
        {
            using var sha = SHA256.Create();
            var input = salt + password;
            var bytes = Encoding.UTF8.GetBytes(input);
            var hashed = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }
    }
}