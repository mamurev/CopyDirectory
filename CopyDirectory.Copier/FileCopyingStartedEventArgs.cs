using System;

namespace CopyDirectory.Copier
{
    public class FileCopyingStartedEventArgs : EventArgs
    {
        public string Message { get; set; }

        public FileCopyingStartedEventArgs(string fileDetails)
        {
            Message = fileDetails;
        }

    }
}
