using System;

namespace SecureVaultApp.BLL
{
    /// <summary>
    /// High-level service for analyzing password security and providing feedback.
    /// Implements requirements for Module 4.
    /// </summary>
    public class PasswordAnalyzer
    {
        private readonly StrengthEvaluator _evaluator = new StrengthEvaluator();

        public PasswordCategory AnalyzePassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return PasswordCategory.Weak;

            int score = 0;
            score += _evaluator.GetLengthScore(password);
            if (_evaluator.HasUppercase(password)) score++;
            if (_evaluator.HasLowercase(password)) score++;
            if (_evaluator.HasDigit(password)) score++;
            if (_evaluator.HasSpecialChar(password)) score++;

            // Classification Logic
            if (score < 4 || password.Length < 8)
                return PasswordCategory.Weak;
            if (score < 6)
                return PasswordCategory.Medium;
            
            return PasswordCategory.Strong;
        }

        public string GetCrackDifficulty(string password)
        {
            double seconds = _evaluator.EstimateCrackTimeSeconds(password);

            if (seconds < 1) return "Instant (under 1 second)";
            if (seconds < 60) return $"{Math.Round(seconds, 2)} seconds";
            if (seconds < 3600) return $"{Math.Round(seconds / 60, 2)} minutes";
            if (seconds < 86400) return $"{Math.Round(seconds / 3600, 2)} hours";
            if (seconds < 31536000) return $"{Math.Round(seconds / 86400, 2)} days";
            if (seconds < 3153600000) return $"{Math.Round(seconds / 31536000, 2)} years";
            
            return "Centuries (Extremely Secure)";
        }

        public string GetDetailedFeedback(string password)
        {
            var category = AnalyzePassword(password);
            string feedback = $"Strength: {category}\n";
            feedback += $"Estimated Crack Time: {GetCrackDifficulty(password)}\n\n";

            feedback += "Recommendations:\n";
            if (password.Length < 12) feedback += "- Increase length to 12+ characters.\n";
            if (!_evaluator.HasUppercase(password)) feedback += "- Add uppercase letters.\n";
            if (!_evaluator.HasDigit(password)) feedback += "- Add numbers.\n";
            if (!_evaluator.HasSpecialChar(password)) feedback += "- Add special characters.\n";

            if (category == PasswordCategory.Strong)
                feedback += "Great! This is a secure password.";

            return feedback;
        }
    }
}
