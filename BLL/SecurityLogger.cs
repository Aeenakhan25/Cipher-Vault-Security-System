using System;
using SecureVaultApp.Models;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// Static utility for easy logging across the application.
    /// Delegates to LogService.
    /// </summary>
    public static class SecurityLogger
    {
        private static readonly LogService _logService = new LogService();

        public static void Log(string action, string details, int? userId = null, bool isSuspicious = false)
        {
            _logService.RecordEvent(userId, action, details, isSuspicious);
        }

        public static bool CheckForBruteForce(string username)
        {
            return _logService.IsUserThrottled(username);
        }
    }
}
