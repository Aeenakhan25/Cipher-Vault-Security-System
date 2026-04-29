using System;

namespace SecureVaultApp.Models
{
    public class SecurityLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime LogDate { get; set; }
        public string IPAddress { get; set; }
    }
}
