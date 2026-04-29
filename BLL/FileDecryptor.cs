using System.IO;
using System.Security.Cryptography;

namespace SecureVaultApp.BLL
{
    public class FileDecryptor
    {
        private const int KeySize = 256;
        private const int BlockSize = 128;

        public void Decrypt(string inputFile, string outputFile, byte[] key, byte[] iv)
        {
            using (FileStream fsCrypt = new FileStream(inputFile, FileMode.Open))
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = KeySize;
                    aes.BlockSize = BlockSize;
                    aes.Key = key;
                    aes.IV = iv;
                    aes.Mode = CipherMode.CBC;

                    using (CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (FileStream fsOut = new FileStream(outputFile, FileMode.Create))
                        {
                            cs.CopyTo(fsOut);
                        }
                    }
                }
            }
        }
    }
}
