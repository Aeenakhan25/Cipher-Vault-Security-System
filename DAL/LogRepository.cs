using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SecureVaultApp.Models;

namespace SecureVaultApp.DAL
{
    public class LogRepository : DatabaseHelper
    {
        public void AddLog(SecurityEvent log)
        {
            string query = "INSERT INTO Logs (UserID, EventType, Description, IsSuspicious) VALUES (@uid, @type, @desc, @susp)";
            SqlParameter[] parameters = {
                new SqlParameter("@uid", (object)log.UserID ?? DBNull.Value),
                new SqlParameter("@type", log.EventType),
                new SqlParameter("@desc", log.Description),
                new SqlParameter("@susp", log.IsSuspicious)
            };
            ExecuteNonQuery(query, parameters);
        }

        public int GetRecentFailedLogins(string username, int minutes)
        {
            string query = "SELECT COUNT(*) FROM Logs WHERE EventType = 'Login Failure' AND Description LIKE @un AND Timestamp > DATEADD(minute, -@mins, GETDATE())";
            SqlParameter[] parameters = {
                new SqlParameter("@un", $"%{username}%"),
                new SqlParameter("@mins", minutes)
            };
            return (int)ExecuteScalar(query, parameters);
        }

        public List<SecurityEvent> GetAllLogs()
        {
            string query = "SELECT * FROM Logs ORDER BY Timestamp DESC";
            DataTable dt = GetDataTable(query);
            List<SecurityEvent> logs = new List<SecurityEvent>();

            foreach (DataRow row in dt.Rows)
            {
                logs.Add(new SecurityEvent
                {
                    LogID = (int)row["LogID"],
                    UserID = row["UserID"] == DBNull.Value ? null : (int?)row["UserID"],
                    EventType = row["EventType"].ToString(),
                    Description = row["Description"].ToString(),
                    Timestamp = (DateTime)row["Timestamp"],
                    IsSuspicious = row["IsSuspicious"] != DBNull.Value && (bool)row["IsSuspicious"]
                });
            }
            return logs;
        }
    }
}
