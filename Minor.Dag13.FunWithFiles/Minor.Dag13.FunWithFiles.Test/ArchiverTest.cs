using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag13.FunWithFiles.Test
{
    [TestClass]
    public class ArchiverTest
    {

        private static string DocumentsPath = @"C:\Users\larsc\Documents\";
        private static string TestFile = @"TestFile.txt";

        [TestMethod]
        public void DetectNewFileCreation()
        {
            // Arrange
            var target = new Archiver(DocumentsPath);

            if (File.Exists(DocumentsPath + TestFile))
            {
                File.Delete(DocumentsPath + TestFile);
            }

            // Act
            File.WriteAllText(DocumentsPath + TestFile, "TestDrivenDesignDevelopment");

            Thread.Sleep(100);

            // Assert
            Assert.AreEqual(1, target.FileCreatedEventCount);
        }

        [TestMethod]
        public void DetectChangeEvents()
        {
            // Arrange
            var target = new Archiver(DocumentsPath);

            if (File.Exists(DocumentsPath + TestFile))
            {
                File.Delete(DocumentsPath + TestFile);
            }

            // Act
            File.WriteAllText(DocumentsPath + TestFile, "TestDrivenDesignDevelopment");

            Thread.Sleep(300);

            using (StreamWriter sw = new StreamWriter(new FileInfo(DocumentsPath + TestFile).OpenWrite()))
            {
                sw.WriteLine("Hello");
            }

            Thread.Sleep(300);

            // Assert
            Assert.AreEqual(2, target.FileChangedEventCount);
        }

        [TestMethod]
        public void DetectNewFileCreationAndChangeContent()
        {
            // Arrange
            var target = new Archiver(DocumentsPath);

            if (File.Exists(DocumentsPath + TestFile))
            {
                File.Delete(DocumentsPath + TestFile);
            }

            // Act
            File.WriteAllText(DocumentsPath + TestFile, "TestDrivenDesignDevelopment");

            Thread.Sleep(100);

            File.WriteAllText(DocumentsPath + TestFile, "TestDrivenDesignDevelopment2");

            Thread.Sleep(100);


            // Assert
            Assert.AreEqual(1, target.FileCreatedEventCount);
        }

        [TestMethod]
        public void DetectDeleteMoveCreationByCopy()
        {
            // Arrange
            var target = new Archiver(DocumentsPath);

            if (File.Exists(DocumentsPath + TestFile))
            {
                File.Delete(DocumentsPath + TestFile);
            }

            // Act
            File.WriteAllText(DocumentsPath + TestFile, "TestDrivenDesignDevelopment");

            Thread.Sleep(100);

            if (File.Exists(DocumentsPath + @"\test\test.txt"))
            {
                File.Delete(DocumentsPath + @"\test\test.txt");
            }

            File.Move(DocumentsPath + TestFile, DocumentsPath + @"\test\test.txt");

            Thread.Sleep(100);

            // Assert
            Assert.AreEqual(1, target.FileCreatedEventCount);
        }

        [TestMethod]
        public void DetectDeleteMoveCreationByCop2y()
        {
            // Arrange
            var target = new Archiver(DocumentsPath);

            if (File.Exists(DocumentsPath + TestFile))
            {
                File.Delete(DocumentsPath + TestFile);
            }

            // Act
            File.Create(DocumentsPath + TestFile);

            Thread.Sleep(100);

            // Assert
            Assert.AreEqual(1, target.FileCreatedEventCount);
        }
    }
}
