using CopyDirectory.Copier;
using System.Windows;

namespace CopyDirectory.UI.WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Application.Current.MainWindow = new MainWindow(new DirectoryCopier());
            Application.Current.MainWindow.Show();
        }
    }
}
