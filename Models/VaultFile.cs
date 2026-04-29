using System;

namespace SecureVaultApp.Models
{
    public class VaultFile
    {
        public int FileID { get; set; }
        public int UserID { get; set; }
        public string FileName { get; set; }
        public string EncryptedData { get; set; } // Path to encrypted file
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
