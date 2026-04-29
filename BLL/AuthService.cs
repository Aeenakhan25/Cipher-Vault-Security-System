using SecureVaultApp.DAL;
using SecureVaultApp.Models;
using System;

namespace SecureVaultApp.BLL
{
    public class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private readonly PasswordHasher _hasher = new PasswordHasher();

        public bool Register(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                throw new ArgumentException("Username must be at least 3 characters long.");
            
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                throw new ArgumentException("Password must be at least 6 characters long.");

            if (_userRepo.GetUserByUsername(username) != null)
                return false;

            string salt = _hasher.GenerateSalt();
            string hash = _hasher.HashPassword(password, salt);

            User newUser = new User
            {
                Username = username,
                PasswordHash = hash,
                Salt = salt
            };

            _userRepo.AddUser(newUser);
            SecurityLogger.Log("User Registration", $"New account created for: {username}");
            
            return true;
        }

        public User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            // Module 6: Detect repeated failed login attempts
            if (SecurityLogger.CheckForBruteForce(username))
            {
                SecurityLogger.Log("Security Alert", $"Brute-force detected for user: {username}", null, true);
                throw new UnauthorizedAccessException("Account temporarily locked due to too many failed attempts. Try again in 5 minutes.");
            }

            User user = _userRepo.GetUserByUsername(username);
            if (user == null) 
            {
                SecurityLogger.Log("Login Failure", $"Attempt for non-existent user: {username}");
                return null;
            }

            if (_hasher.VerifyPassword(password, user.PasswordHash, user.Salt))
            {
                SecurityLogger.Log("Login Success", $"User logged in: {username}", user.UserId);
                return user;
            }

            SecurityLogger.Log("Login Failure", $"Invalid password for user: {username}", user.UserId);
            return null;
        }
    }
}
