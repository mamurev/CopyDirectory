using System;

namespace CopyDirectory.Copier
{
    public interface IDirectoryCopier
    {
        event EventHandler<FileCopyingStartedEventArgs> FileCopyingStartedEvent;
        void Copy(string sourceDirectory, string targetDirectory);
    }
}
