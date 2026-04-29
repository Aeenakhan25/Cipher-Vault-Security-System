using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SecureVaultApp.Models;

namespace SecureVaultApp.DAL
{
    public class FileRepository : DatabaseHelper
    {
        public void AddFile(VaultFile file)
        {
            string query = "INSERT INTO Files (UserID, FileName, EncryptedData, FileSize) VALUES (@uid, @fn, @ed, @fs)";
            SqlParameter[] parameters = {
                new SqlParameter("@uid", file.UserID),
                new SqlParameter("@fn", file.FileName),
                new SqlParameter("@ed", file.EncryptedData),
                new SqlParameter("@fs", file.FileSize)
            };
            ExecuteNonQuery(query, parameters);
        }

        public List<VaultFile> GetUserFiles(int userId)
        {
            string query = "SELECT * FROM Files WHERE UserID = @uid";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            DataTable dt = GetDataTable(query, parameters);
            List<VaultFile> files = new List<VaultFile>();

            foreach (DataRow row in dt.Rows)
            {
                files.Add(new VaultFile
                {
                    FileID = (int)row["FileID"],
                    UserID = (int)row["UserID"],
                    FileName = row["FileName"].ToString(),
                    EncryptedData = row["EncryptedData"].ToString(),
                    FileSize = (long)row["FileSize"],
                    UploadDate = (DateTime)row["UploadDate"]
                });
            }
            return files;
        }

        public void DeleteFile(int fileId)
        {
            string query = "DELETE FROM Files WHERE FileID = @fid";
            SqlParameter[] parameters = { new SqlParameter("@fid", fileId) };
            ExecuteNonQuery(query, parameters);
        }
    }
}
