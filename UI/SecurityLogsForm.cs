using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SecureVaultApp.BLL;
using SecureVaultApp.Models;

namespace SecureVaultApp.UI
{
    public partial class SecurityLogsForm : Form
    {
        private readonly LogService _logService = new LogService();

        public SecurityLogsForm()
        {
            InitializeComponent();
            ApplyDarkTheme();
            LoadLogs();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            dgvLogs.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvLogs.ForeColor = Color.Black; // DataGridView text is usually better in black or high contrast
            dgvLogs.GridColor = Color.FromArgb(60, 60, 60);
        }

        private void LoadLogs()
        {
            try
            {
                List<SecurityEvent> logs = _logService.GetAuditTrail();
                dgvLogs.DataSource = logs;
                
                // Formatting columns
                if (dgvLogs.Columns.Count > 0)
                {
                    dgvLogs.Columns["LogID"].Width = 50;
                    dgvLogs.Columns["EventType"].Width = 120;
                    dgvLogs.Columns["Timestamp"].Width = 150;
                    dgvLogs.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading logs: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLogs();
        }
    }
}
