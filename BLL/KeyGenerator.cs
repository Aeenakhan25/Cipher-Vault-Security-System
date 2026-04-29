using System.Security.Cryptography;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// Handles the generation of cryptographically strong random keys and IVs.
    /// </summary>
    public class KeyGenerator
    {
        private const int DefaultKeySize = 32; // 256 bits
        private const int DefaultIVSize = 16;  // 128 bits

        public byte[] GenerateRandomKey(int size = DefaultKeySize)
        {
            byte[] key = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        public byte[] GenerateRandomIV(int size = DefaultIVSize)
        {
            byte[] iv = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(iv);
            }
            return iv;
        }
    }
}
