using CopyDirectory.Copier;
using System;
using System.Windows.Forms;

namespace CopyDirectory.UI.WinForms
{
    public partial class FrmCopyDirectory : Form
    {
        IDirectoryCopier _copier;
        public FrmCopyDirectory(IDirectoryCopier copier)
        {
            InitializeComponent();
            _copier = copier;
            //Subscribing to the event to receive file path and name that started being copied.
            _copier.FileCopyingStartedEvent += _copier_FileCopyingStartedEvent;
        }

        private void _copier_FileCopyingStartedEvent(object sender, FileCopyingStartedEventArgs e)
        {
            lblResult.Text = e.Message;
            Application.DoEvents();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                _copier.Copy(txtSourcePath.Text, txtTargetPath.Text);
                lblResult.Text = "Directory copying finished.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
