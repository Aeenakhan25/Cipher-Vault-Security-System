using System;
using System.Drawing;
using System.Windows.Forms;
using SecureVaultApp.BLL;

namespace SecureVaultApp.UI
{
    public partial class AnalyzerForm : Form
    {
        private readonly PasswordAnalyzer _analyzer = new PasswordAnalyzer();

        public AnalyzerForm()
        {
            InitializeComponent();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = txtPassword.Text;
            if (string.IsNullOrEmpty(pass))
            {
                lblScore.Text = "Strength: None";
                lblEntropy.Text = "Crack Time: N/A";
                lblFeedback.Text = "Enter a password to analyze.";
                progressBar.Value = 0;
                return;
            }

            var category = _analyzer.AnalyzePassword(pass);
            string difficulty = _analyzer.GetCrackDifficulty(pass);
            string feedback = _analyzer.GetDetailedFeedback(pass);

            lblScore.Text = $"Strength: {category}";
            lblEntropy.Text = $"Estimated Crack Time: {difficulty}";
            lblFeedback.Text = feedback;

            // Visual Progress Bar Feedback
            switch (category)
            {
                case PasswordCategory.Weak:
                    progressBar.Value = 33;
                    progressBar.ForeColor = Color.Red;
                    break;
                case PasswordCategory.Medium:
                    progressBar.Value = 66;
                    progressBar.ForeColor = Color.Orange;
                    break;
                case PasswordCategory.Strong:
                    progressBar.Value = 100;
                    progressBar.ForeColor = Color.Green;
                    break;
            }
        }
    }
}
