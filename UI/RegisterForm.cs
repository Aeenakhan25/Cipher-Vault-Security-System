using System;
using System.Drawing;
using System.Windows.Forms;
using SecureVaultApp.BLL;

namespace SecureVaultApp.UI
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService = new AuthService();

        public RegisterForm()
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (_authService.Register(txtUsername.Text, txtPassword.Text))
                {
                    MessageBox.Show("Registration successful! You can now login.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
