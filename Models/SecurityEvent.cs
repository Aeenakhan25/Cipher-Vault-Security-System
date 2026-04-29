using System;

namespace SecureVaultApp.Models
{
    public class SecurityEvent
    {
        public int LogID { get; set; }
        public int? UserID { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsSuspicious { get; set; }
    }
}
