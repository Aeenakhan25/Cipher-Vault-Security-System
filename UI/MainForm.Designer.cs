namespace SecureVaultApp.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnVault;
        private System.Windows.Forms.Button btnAnalyzer;
        private System.Windows.Forms.Button btnSimulator;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnVault = new System.Windows.Forms.Button();
            this.btnAnalyzer = new System.Windows.Forms.Button();
            this.btnSimulator = new System.Windows.Forms.Button();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(200, 32);
            this.lblWelcome.Text = "Welcome, User";
            // 
            // btnVault
            // 
            this.btnVault.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnVault.Location = new System.Drawing.Point(30, 100);
            this.btnVault.Size = new System.Drawing.Size(200, 50);
            this.btnVault.Text = "🛡️ Secure File Vault";
            this.btnVault.Click += new System.EventHandler(this.btnVault_Click);
            // 
            // btnAnalyzer
            // 
            this.btnAnalyzer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAnalyzer.Location = new System.Drawing.Point(250, 100);
            this.btnAnalyzer.Size = new System.Drawing.Size(200, 50);
            this.btnAnalyzer.Text = "📊 Password Analyzer";
            this.btnAnalyzer.Click += new System.EventHandler(this.btnAnalyzer_Click);
            // 
            // btnSimulator
            // 
            this.btnSimulator.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSimulator.Location = new System.Drawing.Point(30, 170);
            this.btnSimulator.Size = new System.Drawing.Size(200, 50);
            this.btnSimulator.Text = "⚔️ Attack Simulator";
            this.btnSimulator.Click += new System.EventHandler(this.btnSimulator_Click);
            // 
            // btnLogs
            // 
            this.btnLogs.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogs.Location = new System.Drawing.Point(250, 170);
            this.btnLogs.Size = new System.Drawing.Size(200, 50);
            this.btnLogs.Text = "📜 Security Audit Logs";
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLogout.Location = new System.Drawing.Point(30, 260);
            this.btnLogout.Size = new System.Drawing.Size(100, 35);
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnLogs);
            this.Controls.Add(this.btnSimulator);
            this.Controls.Add(this.btnAnalyzer);
            this.Controls.Add(this.btnVault);
            this.Controls.Add(this.lblWelcome);
            this.Name = "MainForm";
            this.Text = "SecureVault Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
