using SecureVaultApp.Models;

namespace SecureVaultApp.BLL
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }
        
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
