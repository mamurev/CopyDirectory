using CopyDirectory.Copier;
using System;

namespace CopyDirectory.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Specify the source path: ");
            var sourceDirectory = Console.ReadLine();
            Console.WriteLine("Specify the target path: ");
            var targetDirectory = Console.ReadLine();

            IDirectoryCopier _copier = new DirectoryCopier();

            //Subscribing to the event to receive file path and name that started being copied.
            _copier.FileCopyingStartedEvent += _copier_FileCopyingStartedEvent;

            try
            {
                _copier.Copy(sourceDirectory, targetDirectory);
                Console.WriteLine("Directory copying finished.");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void _copier_FileCopyingStartedEvent(object sender, FileCopyingStartedEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
