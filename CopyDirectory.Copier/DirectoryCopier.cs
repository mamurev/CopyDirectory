using System;
using System.IO;

namespace CopyDirectory.Copier
{
    public class DirectoryCopier : IDirectoryCopier
    {
        public event EventHandler<FileCopyingStartedEventArgs> FileCopyingStartedEvent;

        public void Copy(string sourceDirectory, string targetDirectory)
        {
            CheckDirectoriesAvailability(sourceDirectory, targetDirectory);

            var directoryInfoSource = new DirectoryInfo(sourceDirectory);
            var directoryInfoTarget = new DirectoryInfo(targetDirectory);

            CopyAllFilesAndDirectories(directoryInfoSource, directoryInfoTarget);
        }

        /// <summary>
        /// Copies files and directories recursively to the target directory
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        void CopyAllFilesAndDirectories(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fileInfo in source.GetFiles())
            {
                OnFileCopyingStartedEvent(new FileCopyingStartedEventArgs($"{source.FullName}\\{fileInfo.Name}"));
                fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
            }

            foreach (DirectoryInfo directoryInfoSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(directoryInfoSourceSubDir.Name);
                CopyAllFilesAndDirectories(directoryInfoSourceSubDir, nextTargetSubDir);
            }
        }

        /// <summary>
        /// Checks the source and target directory path if they are empty
        /// and if the source directory exists
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        public void CheckDirectoriesAvailability(string sourceDirectory, string targetDirectory)
        {
            if (IsSourceDirectoryPathEmpty(targetDirectory))
            {
                throw new Exception("Source directory path can not be empty");
            }

            if (IsTargetDirectoryPathEmpty(targetDirectory))
            {
                throw new Exception("Target directory path can not be empty");
            }

            if (!DoesSourceDirectoryExist(sourceDirectory))
            {
                throw new Exception("Source directory does not exist");
            }
        }

        public bool IsSourceDirectoryPathEmpty(string sourceDirectory)
        {
            return string.IsNullOrWhiteSpace(sourceDirectory);
        }
        public bool IsTargetDirectoryPathEmpty(string targetDirectory)
        {
            return string.IsNullOrWhiteSpace(targetDirectory);
        }
        public bool DoesSourceDirectoryExist(string sourceDirectory)
        {
            return Directory.Exists(sourceDirectory);
        }

        /// <summary>
        /// By this event, the full path of the file is able to be sent to the UI side.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnFileCopyingStartedEvent(FileCopyingStartedEventArgs e)
        {
            FileCopyingStartedEvent?.Invoke(this, e);
        }
    }
}
