namespace SecureVaultApp.UI
{
    partial class SimulatorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.RadioButton rbBruteForce;
        private System.Windows.Forms.RadioButton rbDictionary;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCurrentAttempt;
        private System.Windows.Forms.Label lblTotalAttempts;
        private System.Windows.Forms.Label lblTimeElapsed;

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
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.rbBruteForce = new System.Windows.Forms.RadioButton();
            this.rbDictionary = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCurrentAttempt = new System.Windows.Forms.Label();
            this.lblTotalAttempts = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(30, 40);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(200, 20);
            this.txtTarget.Text = "password";
            // 
            // rbBruteForce
            // 
            this.rbBruteForce.Checked = true;
            this.rbBruteForce.Location = new System.Drawing.Point(30, 80);
            this.rbBruteForce.Text = "Brute Force Simulation";
            // 
            // rbDictionary
            // 
            this.rbDictionary.Location = new System.Drawing.Point(30, 110);
            this.rbDictionary.Text = "Dictionary Attack Simulation";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(30, 150);
            this.btnStart.Size = new System.Drawing.Size(100, 30);
            this.btnStart.Text = "Start Attack";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(140, 150);
            this.btnStop.Size = new System.Drawing.Size(100, 30);
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCurrentAttempt
            // 
            this.lblCurrentAttempt.Location = new System.Drawing.Point(30, 200);
            this.lblCurrentAttempt.Size = new System.Drawing.Size(300, 20);
            this.lblCurrentAttempt.Text = "Current Attempt: -";
            // 
            // lblTotalAttempts
            // 
            this.lblTotalAttempts.Location = new System.Drawing.Point(30, 230);
            this.lblTotalAttempts.Text = "Total Attempts: 0";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.Location = new System.Drawing.Point(30, 260);
            this.lblTimeElapsed.Text = "Time Elapsed: 00:00";
            // 
            // SimulatorForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 320);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblTotalAttempts);
            this.Controls.Add(this.lblCurrentAttempt);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.rbDictionary);
            this.Controls.Add(this.rbBruteForce);
            this.Controls.Add(this.txtTarget);
            this.Text = "Attack Simulator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
