using System;
using System.Text.RegularExpressions;

namespace SecureVaultApp.BLL
{
    public enum PasswordCategory
    {
        Weak,
        Medium,
        Strong
    }

    /// <summary>
    /// Core logic for evaluating specific metrics of a password.
    /// </summary>
    public class StrengthEvaluator
    {
        public bool HasUppercase(string password) => Regex.IsMatch(password, @"[A-Z]");
        public bool HasLowercase(string password) => Regex.IsMatch(password, @"[a-z]");
        public bool HasDigit(string password) => Regex.IsMatch(password, @"[0-9]");
        public bool HasSpecialChar(string password) => Regex.IsMatch(password, @"[^a-zA-Z0-9]");
        
        public int GetLengthScore(string password)
        {
            if (password.Length < 6) return 0;
            if (password.Length < 10) return 1;
            if (password.Length < 14) return 2;
            return 3;
        }

        public double EstimateCrackTimeSeconds(string password)
        {
            // Simplified theoretical entropy-based calculation
            // Assuming a bot can try 1 billion (10^9) guesses per second
            double combinations = CalculateCombinations(password);
            return combinations / 1_000_000_000.0;
        }

        private double CalculateCombinations(string password)
        {
            int pool = 0;
            if (HasLowercase(password)) pool += 26;
            if (HasUppercase(password)) pool += 26;
            if (HasDigit(password)) pool += 10;
            if (HasSpecialChar(password)) pool += 33;

            if (pool == 0) return 0;
            return Math.Pow(pool, password.Length);
        }
    }
}
