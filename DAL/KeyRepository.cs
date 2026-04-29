using System;
using System.Data;
using System.Data.SqlClient;
using SecureVaultApp.Models;

namespace SecureVaultApp.DAL
{
    public class KeyRepository : DatabaseHelper
    {
        public void SaveKey(int userId, string keyType, string encryptedKey, string iv)
        {
            string query = "INSERT INTO UserKeys (UserID, KeyType, EncryptedKey, IV) VALUES (@uid, @type, @key, @iv)";
            SqlParameter[] parameters = {
                new SqlParameter("@uid", userId),
                new SqlParameter("@type", keyType),
                new SqlParameter("@key", encryptedKey),
                new SqlParameter("@iv", iv)
            };
            ExecuteNonQuery(query, parameters);
        }

        public DataTable GetUserKeys(int userId)
        {
            string query = "SELECT * FROM UserKeys WHERE UserID = @uid ORDER BY CreatedAt DESC";
            SqlParameter[] parameters = { new SqlParameter("@uid", userId) };
            return GetDataTable(query, parameters);
        }
    }
}
