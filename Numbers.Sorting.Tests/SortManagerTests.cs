using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Numbers.Sorting.Tests
{
    [TestFixture]
    public class SortManagerTests
    {
        private ISortManager _sut;
        private Mock<IFileManager> _mockFileManager;

        [OneTimeSetUp]
        public void Init()
        {
            _mockFileManager = new Mock<IFileManager>();
            _sut = new SortManager(_mockFileManager.Object);

        }

        [Test]
        public void OnSort_WhenUnorderListofNumbers_ShouldReturnOrderedNumberList()
        {
            //Arrange
            string fileName = "aaav";
            List<string> input = new List<string> { "4", "7", "6", "11", "1", "3", "9", "14" };
            List<int> expected = new List<int> { 1, 3, 4, 6, 7, 9, 11, 14 };

            //Act
            _mockFileManager.Setup(x => x.ReadCsvFile(fileName)).Returns(input);
            var response = _sut.Sort(fileName);

            //Assert
            Assert.AreEqual(8, response.Count);
            Assert.AreEqual(expected, response);
        }

        [Test]
        public void OnSort_WhenUnorderListofNumbersWithNegativeNumbers_ShouldReturnOrderedNumberList()
        {

            string fileName = "inputNumbers.csv";
            List<string> input = new List<string> { "-2", "-1", "5", "6", "6", "7", "44", "200" };
            List<int> expected = new List<int> { -2, -1, 5, 6, 6, 7, 44, 200 };

            _mockFileManager.Setup(x => x.ReadCsvFile(fileName)).Returns(input);

            var response = _sut.Sort(fileName);


            Assert.AreEqual(8, response.Count);
            Assert.AreEqual(expected, response);
        }



        [TestCase(new string[] { "2", "1", "200", "6", "44", "7", "6", "5" }, new int[] { 1, 2, 5, 6, 6, 7, 44, 200 })]
        [TestCase(new string[] { "2", "1", "200", "A", "6", "44", "7", "6", "5" }, new int[] { 1, 2, 5, 6, 6, 7, 44, 200 })]
        public void OnShort_WhenGiveMultipleInputAsTestCases_ShouldReturneOrderdNumberOnly(string[] input, int[] expected)
        {
            string fileName = "inputNumbers.csv";
            List<string> numbers = input.ToList();

            _mockFileManager.Setup(x => x.ReadCsvFile(fileName)).Returns(numbers);

            var response = _sut.Sort(fileName);


            Assert.AreEqual(8, response.Count);
            Assert.AreEqual(expected, response);
        }

        [TestCaseSource(typeof(TestClassData), "SomeTestCases")]
        public void OnShort_WhenGiveMultipleInputInTestDataMethod_ShouldReturneOrderdNumberOnly(string[] input, int[] expected)
        {

            string fileName = "inputNumbers.csv";
            List<string> numbers = input.ToList();

            _mockFileManager.Setup(x => x.ReadCsvFile(fileName)).Returns(numbers);

            var response = _sut.Sort(fileName);


            Assert.AreEqual(8, response.Count);
            Assert.AreEqual(expected, response);
        }

        public class TestClassData
        {
            public static IEnumerable<TestCaseData> SomeTestCases
            {
                get
                {
                    yield return new TestCaseData(new string[] { "2", "1", "200", "6", "44", "7", "6", "5" }, new int[] { 1, 2, 5, 6, 6, 7, 44, 200 });
                    yield return new TestCaseData(new string[] { "2", "1", "200", "A", "6", "44", "7", "6", "5" }, new int[] { 1, 2, 5, 6, 6, 7, 44, 200 });
                }
            }
        }

    }
}
