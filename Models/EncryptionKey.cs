using System;

namespace SecureVaultApp.Models
{
    /// <summary>
    /// Represents an encryption key associated with a user or session.
    /// </summary>
    public class EncryptionKey
    {
        public int KeyId { get; set; }
        public int UserId { get; set; }
        public byte[] KeyValue { get; set; }
        public byte[] IV { get; set; }
        public DateTime CreatedAt { get; set; }
        public string KeyPurpose { get; set; } // e.g., "FileVault", "LogEncryption"
    }
}
