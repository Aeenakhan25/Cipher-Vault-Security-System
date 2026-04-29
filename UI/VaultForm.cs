using System;
using System.IO;
using System.Windows.Forms;
using SecureVaultApp.BLL;
using SecureVaultApp.Models;

namespace SecureVaultApp.UI
{
    public partial class VaultForm : Form
    {
        private readonly FileVaultService _vaultService;

        public VaultForm()
        {
            InitializeComponent();
            string vaultPath = Path.Combine(Application.StartupPath, "Vault");
            _vaultService = new FileVaultService(vaultPath);
            LoadFiles();
        }

        private void LoadFiles()
        {
            dgvFiles.DataSource = _vaultService.GetUserFiles(SessionManager.CurrentUser.UserId);
            dgvFiles.Columns["EncryptedFileName"].Visible = false; // Hide internal GUIDs
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Using user's password hash as the secret for file encryption
                        _vaultService.SecurelyUploadFile(
                            SessionManager.CurrentUser.UserId, 
                            ofd.FileName, 
                            SessionManager.CurrentUser.PasswordHash);

                        LoadFiles();
                        MessageBox.Show("File encrypted and stored successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
            {
                var file = (VaultFile)dgvFiles.SelectedRows[0].DataBoundItem;
                using (SaveFileDialog sfd = new SaveFileDialog { FileName = file.OriginalFileName })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            _vaultService.SecurelyDownloadFile(file, sfd.FileName, SessionManager.CurrentUser.PasswordHash);
                            MessageBox.Show("File decrypted and downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error downloading file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a file to download.", "Selection Required");
            }
        }
    }
}
