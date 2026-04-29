using System.IO;
using System.Security.Cryptography;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// MODULE 2: FILE VAULT SYSTEM (CORE MODULE)
    /// This class implements AES-256 Symmetric Encryption for file protection.
    /// AES is a worldwide standard for high-security data encryption.
    /// </summary>
    public class FileEncryptor
    {
        private const int KeySize = 256;   // Maximum strength AES
        private const int BlockSize = 128; // Standard AES block size

        /// <summary>
        /// Encrypts a file using the Advanced Encryption Standard (AES) in CBC mode.
        /// CBC (Cipher Block Chaining) ensures that identical blocks of data result in different cipher text.
        /// </summary>
        /// <param name="inputFile">The raw file path.</param>
        /// <param name="outputFile">The path where encrypted data will be saved.</param>
        /// <param name="key">256-bit encryption key.</param>
        /// <param name="iv">128-bit Initialization Vector (prevents pattern recognition).</param>
        public void Encrypt(string inputFile, string outputFile, byte[] key, byte[] iv)
        {
            // We use FileStreams to handle potentially large files without loading them fully into memory.
            using (FileStream fsCrypt = new FileStream(outputFile, FileMode.Create))
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = KeySize;
                    aes.BlockSize = BlockSize;
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC; // Most common secure mode for general file encryption

                    // CryptoStream acts as a wrapper around the output file stream, 
                    // performing encryption on-the-fly as data is copied.
                    using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        using (FileStream fsIn = new FileStream(inputFile, FileMode.Open))
                        {
                            fsIn.CopyTo(cs);
                        }
                    }
                }
            }
        }
    }
}
