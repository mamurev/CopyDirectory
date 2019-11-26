using CopyDirectory.Copier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CopyDirectory.UnitTests
{
    [TestClass]
    public class CopyTests
    {
        [TestMethod]
        public void IsSourceDirectoryPathEmpty_SourceDirectoryPathHasOnlyBlanks_ReturnsTrue()
        {
            DirectoryCopier copier = new DirectoryCopier();
            var result = copier.IsSourceDirectoryPathEmpty("     ");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTargetDirectoryPathEmpty_TargetDirectoryHasOnlyBlanks_ReturnsTrue()
        {
            DirectoryCopier copier = new DirectoryCopier();
            var result = copier.IsTargetDirectoryPathEmpty("     ");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DoesSourceDirectoryExist_SourceDirectoryDoesNotExist_ReturnsFalse()
        {
            DirectoryCopier copier = new DirectoryCopier();
            var result = copier.DoesSourceDirectoryExist("C:\\a\\b\\c\\d\\Idonotexist");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckDirectoriesAvailability_SourceDirectoryDoesNotExist_ThrowsException()
        {
            DirectoryCopier copier = new DirectoryCopier();
            Assert.ThrowsException<Exception>(() => copier.CheckDirectoriesAvailability("C:\\a\\b\\c\\d\\Idonotexist", ""));
        }
    }
}
