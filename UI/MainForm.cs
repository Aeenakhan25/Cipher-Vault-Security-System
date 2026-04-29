using System;
using System.Drawing;
using System.Windows.Forms;
using SecureVaultApp.BLL;

namespace SecureVaultApp.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ApplyDarkTheme();
            lblWelcome.Text = $"Welcome, {SessionManager.CurrentUser?.Username}";
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(63, 63, 70);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        private void btnVault_Click(object sender, EventArgs e)
        {
            new VaultForm().ShowDialog();
        }

        private void btnAnalyzer_Click(object sender, EventArgs e)
        {
            new AnalyzerForm().ShowDialog();
        }

        private void btnSimulator_Click(object sender, EventArgs e)
        {
            new SimulatorForm().ShowDialog();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            new SecurityLogsForm().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessionManager.Logout();
            this.Close();
        }
    }
}
