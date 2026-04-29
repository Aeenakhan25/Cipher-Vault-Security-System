using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecureVaultApp.BLL;

namespace SecureVaultApp.UI
{
    public partial class SimulatorForm : Form
    {
        private readonly AttackSimulator _simulator = new AttackSimulator();
        private CancellationTokenSource _cts;
        private RadioButton rbHybrid;

        public SimulatorForm()
        {
            InitializeComponent();
            AddHybridOption();
            _simulator.OnSimulationUpdate += UpdateUI;
        }

        private void AddHybridOption()
        {
            // Dynamically adding the Hybrid option if not in designer
            rbHybrid = new RadioButton
            {
                Text = "Hybrid Attack (Advanced)",
                Location = new System.Drawing.Point(30, 130),
                Size = new System.Drawing.Size(200, 20)
            };
            this.Controls.Add(rbHybrid);
            
            // Shift Start button down a bit to make room
            btnStart.Location = new System.Drawing.Point(30, 170);
            btnStop.Location = new System.Drawing.Point(140, 170);
        }

        private void UpdateUI(string attempt, long count, TimeSpan elapsed)
        {
            if (this.IsDisposed) return;

            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => UpdateUI(attempt, count, elapsed)));
                return;
            }

            lblCurrentAttempt.Text = $"Current Attempt: {attempt}";
            lblTotalAttempts.Text = $"Total Attempts: {count}";
            lblTimeElapsed.Text = $"Time Elapsed: {elapsed:mm\\:ss}";
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            string target = txtTarget.Text;
            if (string.IsNullOrEmpty(target))
            {
                MessageBox.Show("Please enter a target password to simulate an attack.");
                return;
            }

            SetControlsState(true);
            _cts = new CancellationTokenSource();

            AttackType type = AttackType.BruteForce;
            if (rbDictionary.Checked) type = AttackType.Dictionary;
            else if (rbHybrid.Checked) type = AttackType.Hybrid;

            try
            {
                await _simulator.StartAttack(type, target, _cts.Token);
                
                if (!_cts.Token.IsCancellationRequested)
                {
                    MessageBox.Show("Simulation completed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Simulation error: {ex.Message}");
            }
            finally
            {
                SetControlsState(false);
            }
        }

        private void SetControlsState(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled = isRunning;
            txtTarget.Enabled = !isRunning;
            rbBruteForce.Enabled = !isRunning;
            rbDictionary.Enabled = !isRunning;
            rbHybrid.Enabled = !isRunning;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            lblCurrentAttempt.Text += " (Stopped)";
        }
    }
}
