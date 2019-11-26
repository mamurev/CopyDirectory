using CopyDirectory.Copier;
using System;
using System.Windows.Forms;

namespace CopyDirectory.UI.WinForms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCopyDirectory(new DirectoryCopier()));
        }
    }
}
