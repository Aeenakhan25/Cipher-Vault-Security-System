using System;
using System.Data;
using System.Data.SqlClient;
using SecureVaultApp.Models;

namespace SecureVaultApp.DAL
{
    public class UserRepository : DatabaseHelper
    {
        public void AddUser(User user)
        {
            string query = "INSERT INTO Users (Username, PasswordHash, Salt) VALUES (@un, @ph, @sl)";
            SqlParameter[] parameters = {
                new SqlParameter("@un", user.Username),
                new SqlParameter("@ph", user.PasswordHash),
                new SqlParameter("@sl", user.Salt)
            };
            ExecuteNonQuery(query, parameters);
        }

        public User GetUserByUsername(string username)
        {
            string query = "SELECT * FROM Users WHERE Username = @un";
            SqlParameter[] parameters = { new SqlParameter("@un", username) };
            DataTable dt = GetDataTable(query, parameters);

            if (dt.Rows.Count == 0) return null;

            DataRow row = dt.Rows[0];
            return new User
            {
                UserID = (int)row["UserID"],
                Username = row["Username"].ToString(),
                PasswordHash = row["PasswordHash"].ToString(),
                Salt = row["Salt"].ToString(),
                CreatedAt = (DateTime)row["CreatedAt"]
            };
        }
    }
}
