using System;
using System.Collections.Generic;
using System.IO;
using SecureVaultApp.DAL;
using SecureVaultApp.Models;

namespace SecureVaultApp.BLL
{
    public class FileVaultService
    {
        private readonly FileRepository _fileRepo = new FileRepository();
        private readonly FileEncryptor _encryptor = new FileEncryptor();
        private readonly FileDecryptor _decryptor = new FileDecryptor();
        private readonly KeyManager _keyManager = new KeyManager();
        private readonly string _vaultPath;

        public FileVaultService(string vaultPath)
        {
            _vaultPath = vaultPath;
            if (!Directory.Exists(_vaultPath))
                Directory.CreateDirectory(_vaultPath);
        }

        public void SecurelyUploadFile(int userId, string sourceFilePath, string userPasswordHash)
        {
            if (!File.Exists(sourceFilePath))
                throw new FileNotFoundException("Source file not found.");

            // Module 3 Integration: Get or create the user's master encryption key
            EncryptionKey userKey = _keyManager.GetOrCreateUserKey(userId, userPasswordHash);

            string originalFileName = Path.GetFileName(sourceFilePath);
            string encryptedFileName = Guid.NewGuid().ToString() + ".vault";
            string targetPath = Path.Combine(_vaultPath, encryptedFileName);

            // Encryption using the managed key
            _encryptor.Encrypt(sourceFilePath, targetPath, userKey.KeyValue, userKey.IV);

            VaultFile file = new VaultFile
            {
                UserId = userId,
                OriginalFileName = originalFileName,
                EncryptedFileName = encryptedFileName,
                FileSize = new FileInfo(sourceFilePath).Length,
                UploadDate = DateTime.Now
            };

            _fileRepo.AddFile(file);
            SecurityLogger.Log("File Upload", $"Securely uploaded {originalFileName}", userId);
        }

        public void SecurelyDownloadFile(VaultFile file, string destinationPath, string userPasswordHash)
        {
            string sourcePath = Path.Combine(_vaultPath, file.EncryptedFileName);
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("Encrypted file missing from vault.");

            // Module 3 Integration: Retrieve the user's master key
            EncryptionKey userKey = _keyManager.GetOrCreateUserKey(file.UserId, userPasswordHash);

            _decryptor.Decrypt(sourcePath, destinationPath, userKey.KeyValue, userKey.IV);
            SecurityLogger.Log("File Download", $"Securely downloaded {file.OriginalFileName}", file.UserId);
        }

        public List<VaultFile> GetUserFiles(int userId)
        {
            return _fileRepo.GetUserFiles(userId);
        }

        public void DeleteFile(int userId, VaultFile file)
        {
            string filePath = Path.Combine(_vaultPath, file.EncryptedFileName);
            if (File.Exists(filePath))
                File.Delete(filePath);

            _fileRepo.DeleteFile(file.FileId);
            SecurityLogger.Log("File Deletion", $"Deleted {file.OriginalFileName}", userId);
        }
    }
}
