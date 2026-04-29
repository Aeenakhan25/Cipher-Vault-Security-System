using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using SecureVaultApp.DAL;
using SecureVaultApp.Models;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// MODULE 3: KEY MANAGEMENT SYSTEM
    /// This is a critical security component. It manages the lifecycle of encryption keys.
    /// To ensure "Zero Knowledge" principles, we never store the raw master key.
    /// Instead, we use a "Key Wrapping" technique.
    /// </summary>
    public class KeyManager
    {
        private readonly KeyGenerator _generator = new KeyGenerator();
        private readonly KeyRepository _keyRepo = new KeyRepository();

        /// <summary>
        /// Retrieves the user's master key from the database.
        /// If it doesn't exist, a new one is generated and securely "wrapped".
        /// </summary>
        public EncryptionKey GetOrCreateUserKey(int userId, string userPasswordHash)
        {
            DataTable dt = _keyRepo.GetUserKeys(userId);
            
            if (dt.Rows.Count > 0)
            {
                // KEY UNWRAPPING:
                // We take the encrypted key from the database and decrypt it using 
                // a key derived from the user's login password.
                DataRow row = dt.Rows[0];
                byte[] rawKey = UnprotectKey(row["EncryptedKey"].ToString(), userPasswordHash);
                byte[] iv = Convert.FromBase64String(row["IV"].ToString());

                return new EncryptionKey
                {
                    KeyId = (int)row["KeyId"],
                    UserId = userId,
                    KeyValue = rawKey,
                    IV = iv,
                    KeyPurpose = "FileVault"
                };
            }
            else
            {
                return CreateUserKey(userId, userPasswordHash);
            }
        }

        private EncryptionKey CreateUserKey(int userId, string userPasswordHash)
        {
            // 1. Generate a high-entropy random key and IV
            byte[] rawKey = _generator.GenerateRandomKey();
            byte[] iv = _generator.GenerateRandomIV();

            // 2. KEY WRAPPING: 
            // Protect the raw key before storage so that even if the database is stolen,
            // the attacker cannot decrypt files without the user's login password.
            string encryptedKey = ProtectKey(rawKey, userPasswordHash);
            
            _keyRepo.SaveKey(userId, "AES-256", encryptedKey, Convert.ToBase64String(iv));

            return new EncryptionKey
            {
                UserId = userId,
                KeyValue = rawKey,
                IV = iv,
                CreatedAt = DateTime.Now,
                KeyPurpose = "FileVault"
            };
        }

        /// <summary>
        /// Uses PBKDF2 (Rfc2898) to derive a temporary key from the user's password hash.
        /// This derived key is then used to encrypt the real master key.
        /// </summary>
        private string ProtectKey(byte[] rawKey, string passwordHash)
        {
            using (Aes aes = Aes.Create())
            {
                // Hardcoded salt for the wrapping layer (different from authentication salt)
                byte[] salt = Encoding.UTF8.GetBytes("key_wrap_salt_permanent_v1");
                
                // Key Derivation Function (KDF): Slowing down attackers
                using (var derive = new Rfc2898DeriveBytes(passwordHash, salt, 5000))
                {
                    aes.Key = derive.GetBytes(32);
                    aes.IV = derive.GetBytes(16);
                }

                using (var encryptor = aes.CreateEncryptor())
                {
                    byte[] protectedKey = encryptor.TransformFinalBlock(rawKey, 0, rawKey.Length);
                    return Convert.ToBase64String(protectedKey);
                }
            }
        }

        private byte[] UnprotectKey(string protectedKeyBase64, string passwordHash)
        {
            byte[] protectedKey = Convert.FromBase64String(protectedKeyBase64);
            using (Aes aes = Aes.Create())
            {
                byte[] salt = Encoding.UTF8.GetBytes("key_wrap_salt_permanent_v1");
                using (var derive = new Rfc2898DeriveBytes(passwordHash, salt, 5000))
                {
                    aes.Key = derive.GetBytes(32);
                    aes.IV = derive.GetBytes(16);
                }

                using (var decryptor = aes.CreateDecryptor())
                {
                    return decryptor.TransformFinalBlock(protectedKey, 0, protectedKey.Length);
                }
            }
        }
    }
}
