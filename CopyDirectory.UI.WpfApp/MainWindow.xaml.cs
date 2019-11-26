using CopyDirectory.Copier;
using System;
using System.Windows;
using System.Windows.Threading;

namespace CopyDirectory.UI.WpfApp
{
    public partial class MainWindow : Window
    {
        IDirectoryCopier _copier;
        public MainWindow(IDirectoryCopier copier)
        {
            InitializeComponent();
            _copier = copier;
            //Subscribing to the event to receive file path and name that started being copied.
            _copier.FileCopyingStartedEvent += _copier_FileCopyingStartedEvent;
        }

        private void _copier_FileCopyingStartedEvent(object sender, FileCopyingStartedEventArgs e)
        {
            lblResult.Text = e.Message;
            
            //To refresh label's text on the UI
            RefreshUI();
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _copier.Copy(txtSourceDirectory.Text, txtTargetDirectory.Text);
                lblResult.Text = "Directory copying finished.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public static void RefreshUI()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
    }
}
