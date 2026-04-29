using System;
using System.Drawing;
using System.Windows.Forms;
using SecureVaultApp.BLL;
using SecureVaultApp.Models;

namespace SecureVaultApp.UI
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            ApplyDarkTheme();
        }

        private void ApplyDarkTheme()
        {
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.White;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox) { ctrl.BackColor = Color.FromArgb(30, 30, 30); ctrl.ForeColor = Color.White; }
                if (ctrl is Button btn) { btn.BackColor = Color.FromArgb(63, 63, 70); btn.ForeColor = Color.White; btn.FlatStyle = FlatStyle.Flat; }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User user = _authService.Login(txtUsername.Text, txtPassword.Text);
                if (user != null)
                {
                    SessionManager.CurrentUser = user;
                    this.Hide();
                    new MainForm().ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new RegisterForm().ShowDialog();
        }
    }
}
