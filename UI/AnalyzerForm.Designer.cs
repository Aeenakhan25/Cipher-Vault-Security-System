namespace SecureVaultApp.UI
{
    partial class AnalyzerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblEntropy;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.ProgressBar progressBar;

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
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblEntropy = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Consolas", 12F);
            this.txtPassword.Location = new System.Drawing.Point(40, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(300, 26);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // lblScore
            // 
            this.lblScore.Location = new System.Drawing.Point(40, 110);
            this.lblScore.Text = "Strength Score: 0/6";
            // 
            // lblEntropy
            // 
            this.lblEntropy.Location = new System.Drawing.Point(40, 140);
            this.lblEntropy.Text = "Entropy: 0 bits";
            // 
            // lblFeedback
            // 
            this.lblFeedback.Location = new System.Drawing.Point(40, 170);
            this.lblFeedback.Text = "Assessment: None";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(40, 210);
            this.progressBar.Size = new System.Drawing.Size(300, 23);
            // 
            // AnalyzerForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.lblEntropy);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtPassword);
            this.Text = "Password Analyzer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
