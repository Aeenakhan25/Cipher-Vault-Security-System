using System;
using System.Collections.Generic;
using SecureVaultApp.DAL;
using SecureVaultApp.Models;

namespace SecureVaultApp.BLL
{
    public class LogService
    {
        private readonly LogRepository _logRepo = new LogRepository();

        public void RecordEvent(int? userId, string action, string details, bool isSuspicious = false)
        {
            SecurityEvent ev = new SecurityEvent
            {
                UserId = userId,
                Action = action,
                Details = details,
                IsSuspicious = isSuspicious,
                LogDate = DateTime.Now
            };
            _logRepo.AddLog(ev);
        }

        public bool IsUserThrottled(string username)
        {
            // Detect repeated failed login attempts (e.g., more than 3 in the last 5 minutes)
            int failedCount = _logRepo.GetRecentFailedLogins(username, 5);
            return failedCount >= 3;
        }

        public List<SecurityEvent> GetAuditTrail()
        {
            return _logRepo.GetAllLogs();
        }
    }
}
