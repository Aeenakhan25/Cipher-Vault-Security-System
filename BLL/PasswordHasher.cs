using System;
using System.Security.Cryptography;
using System.Text;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// MODULE 1: USER AUTHENTICATION SYSTEM
    /// This class handles secure password hashing using SHA-256 with Salts.
    /// In cybersecurity, we never store plain-text passwords. Instead, we store a "fingerprint" (hash).
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// Generates a cryptographically strong random salt.
        /// Salts prevent Rainbow Table attacks by ensuring identical passwords have different hashes.
        /// </summary>
        public string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        /// <summary>
        /// Hashes a password combined with a salt using SHA-256.
        /// SHA-256 is a one-way cryptographic function.
        /// </summary>
        public string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Combining password and salt (Salted Hashing)
                string saltedPassword = password + salt;
                byte[] inputBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                
                return Convert.ToBase64String(hashBytes);
            }
        }

        /// <summary>
        /// Verifies a password by hashing the input and comparing it to the stored hash.
        /// </summary>
        public bool VerifyPassword(string inputPassword, string storedHash, string storedSalt)
        {
            string inputHash = HashPassword(inputPassword, storedSalt);
            return inputHash == storedHash;
        }
    }
}
