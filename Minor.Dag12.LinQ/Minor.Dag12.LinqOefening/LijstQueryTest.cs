using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag12.LinqOefening.Test
{
    [TestClass]
    public class LijstQueryTest
    {
        #region comprehension syntax
        [TestMethod]
        public void SmallListContainsR()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Gert", "Rouke" };

            // Act
            var result = target.getFirstLettersThatContainR(list);

            // Assert
            var expected = new List<char>() { 'L', 'G', 'R' };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListContainsRWithNoResult()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Max"};

            // Act
            var result = target.getFirstLettersThatContainR(list);

            // Assert
            var expected = new List<char>() {};
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BigListContainsR()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            var result = target.getFirstLettersThatContainR();

            // Assert
            var expected = new List<char>() { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListStartsWithJOneResult()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery" };

            // Act
            var result = target.GetLengthOfNamesStartingWithJ(list);

            // Assert
            var expected = new List<int>() { 5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListStartsWithJNoResult()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars" };

            // Act
            var result = target.GetLengthOfNamesStartingWithJ(list);

            // Assert
            var expected = new List<int>() {  };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListStartsWithJDescendingOrder()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery", "Jan-Paul" };

            // Act
            var result = target.GetLengthOfNamesStartingWithJ(list);

            // Assert
            var expected = new List<int>() { 8 , 5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BigListStartsWithJDescendingOrder()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            var result = target.GetLengthOfNamesStartingWithJ();

            // Assert
            var expected = new List<int>() { 8, 6, 5, 5, 3 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListGroupedByNameLengthReturnsOne()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery" };

            // Act
            var result = target.GetListOfNumberOfNamesGroupedByNameLength(list);

            // Assert
            var expected = new List<int>() { 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListGroupedByNameLengthReturnsTwo()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Gert" };

            // Act
            var result = target.GetListOfNumberOfNamesGroupedByNameLength(list);

            // Assert
            var expected = new List<int>() { 2 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListGroupedByNameLengthAscendingOrder()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery", "Lars", "Gert", "Max" };

            // Act
            var result = target.GetListOfNumberOfNamesGroupedByNameLength(list);

            // Assert
            var expected = new List<int>() { 1, 2, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BigListGroupedByNameLength()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            var result = target.GetListOfNumberOfNamesGroupedByNameLength();

            // Assert
            var expected = new List<int>() { 4, 4, 6, 5, 3, 1, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListReturnsSmallestName()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Pim", "Gert" };

            // Act
            var result = target.GetListOfShortestNamesThatDontContainA(list);

            // Assert
            var expected = new List<string>() { "Pim" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void SmallListReturnsEmptyListWhenSmallestNameContainsA()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Al", "Pim" };

            // Act
            var result = target.GetListOfShortestNamesThatDontContainA(list);

            // Assert
            var expected = new List<string>() { };
            CollectionAssert.AreEqual(expected, result);
        }

        #endregion

        [TestMethod]
        public void ExtensionFindFirstLettersFromNames()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Lars" };

            // Act
            var result = target.ExtensionFindAllFirstLettersInNamesThatContainR(list);

            // Assert
            var expected = new List<char>() { 'L' };
            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ExtensionFindFirstLettersFromNamesThatHaveTheLetterR()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Lars", "Gert", "Max" };

            // Act
            var result = target.ExtensionFindAllFirstLettersInNamesThatContainR(list);

            // Assert
            var expected = new List<char>() { 'L', 'G' };
            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ExtensionFindFirstLettersFromNamesThatHaveTheLetterRCaseInsensitive()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Lars", "GeRt", "Max" };

            // Act
            var result = target.ExtensionFindAllFirstLettersInNamesThatContainR(list);

            // Assert
            var expected = new List<char>() { 'L', 'G' };
            CollectionAssert.AreEqual(expected, result);

        }

        [TestMethod]
        public void ExtensionFindFirstLettersFromNamesThatHaveTheLetterRCaseInsensitiveWithBigList()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            var result = target.ExtensionFindAllFirstLettersInNamesThatContainR();

            // Assert
            var expected = new List<char>() { 'R', 'M', 'M', 'R', 'R', 'W', 'J', 'R', 'G', 'L', 'J' };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionFindLengthFive()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Joery" };

            // Act
            List<int> result = target.ExtensionFindLengthOfNamesThatStartWithJ(list);

            // Assert
            var expected = new List<int>() { 5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionFindLengthEight()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Jan-Paul" };

            // Act
            List<int> result = target.ExtensionFindLengthOfNamesThatStartWithJ(list);

            // Assert
            var expected = new List<int>() { 8 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionFindLengthEightThenFive()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Jan-Paul", "Joery" };

            // Act
            List<int> result = target.ExtensionFindLengthOfNamesThatStartWithJ(list);

            // Assert
            var expected = new List<int>() { 8, 5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionFindLengthEightThenFiveDecendingOrder()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string> { "Joery", "Jan-Paul" };

            // Act
            List<int> result = target.ExtensionFindLengthOfNamesThatStartWithJ(list);

            // Assert
            var expected = new List<int>() { 8, 5 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionFindLengthWithBiggerListDecendingOrder()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            List<int> result = target.ExtensionFindLengthOfNamesThatStartWithJ();

            // Assert
            var expected = new List<int>() { 8, 6, 5, 5, 3 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameByLengthAndReturnCount()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery" };

            // Act
            List<int> result = target.GroupNameByLengthAndReturnCount(list);

            // Assert
            var expected = new List<int>() { 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameByLengthAndReturnCount2()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Joery", "Lars" };

            // Act
            List<int> result = target.GroupNameByLengthAndReturnCount(list);

            // Assert
            var expected = new List<int>() { 1, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameByLengthAndReturnCountOrderedByLengthAscending()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Max", "Gert", "Joery" };

            // Act
            List<int> result = target.GroupNameByLengthAndReturnCount(list);

            // Assert
            var expected = new List<int>() { 1, 2, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameByLengthAndReturnCountOrderedByLengthAscendingBigList()
        {
            // Arrange
            var target = new LijstQuery();

            // Act
            List<int> result = target.GroupNameByLengthAndReturnCount();

            // Assert
            var expected = new List<int>() { 4, 4, 6, 5, 3, 1, 1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameAndReturnListOfShortestNames()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Rob" };

            // Act
            List<string> result = target.GroupNameAndReturnListOfShortestNames(list);

            // Assert
            var expected = new List<string>() { "Rob" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameAndReturnNamesWithoutA()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Rob", "Max", "Gert", "Joery" };

            // Act
            List<string> result = target.GroupNameAndReturnListOfShortestNames(list);

            // Assert
            var expected = new List<string>() { "Rob" };
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExtensionGroupNameAndReturnEmptyListBecauseShortestNameContainsA()
        {
            // Arrange
            var target = new LijstQuery();
            var list = new List<string>() { "Lars", "Rob", "Max", "Gert", "Joery", "At" };

            // Act
            List<string> result = target.GroupNameAndReturnListOfShortestNames(list);

            // Assert
            var expected = new List<string>() {  };
            CollectionAssert.AreEqual(expected, result);
        }

    }
}
