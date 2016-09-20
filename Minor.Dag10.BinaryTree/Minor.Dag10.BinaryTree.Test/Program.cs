using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minor.Dag10.BinaryTree.Test
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void CreateEmptyTree()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            int result = tree.Count;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CreateEmptyTreeAndAddFive()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            int result = tree.Count;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void CreateEmptyTreeAndAddFiveThenThree()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(3);
            int result = tree.Count;

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CreateEmptyTreeAndAddFiveThenThreeThenSeven()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(3);
            tree = tree.Add(7);
            int result = tree.Count;

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void DepthIs0ForEmptyTree()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            int result = tree.Depth;

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DepthIs1WithOneBranch()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            int result = tree.Depth;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DepthIs2WhenAddingFiveThenThreeThenSeven()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(3);
            tree = tree.Add(7);
            int result = tree.Depth;

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void CountIsOneAfterAddingDuplicateItem()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(5);
            int result = tree.Depth;

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TreeContainsNumber()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(10);
            tree = tree.Add(1);
            bool result = tree.Contains(1);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TreeDoesNotContainsNumber()
        {
            // Arrange
            MyBinaryTree<int> tree = MyBinaryTree<int>.Empty;

            // Act
            tree = tree.Add(5);
            tree = tree.Add(10);
            tree = tree.Add(1);
            bool result = tree.Contains(7);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
