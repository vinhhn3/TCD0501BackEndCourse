using NUnit.Framework;

using TCD0501BackEndCourse.TestNinja;

namespace TCD0501BackEndCourse.UnitTests
{
    public class MathTest
    {
        Math _math;

        // Run only once
        [SetUp]
        public void Setup()
        {
            _math = new Math();
        }

        [Test]
        public void Sum_WhenCalled_ReturnSumOfTwoArguments()
        {
            // Arrange
            int a = 1;
            int b = 1;
            int expectedResult = 2;
            // Act
            int actualResult = _math.Sum(a, b);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(0, 1, -1)]
        [TestCase(2, 1, 1)]
        [TestCase(12, 3, 9)]
        [TestCase(8, -3, 11)]

        public void Substract_WhenCalled_ReturnSubstractionofTwoArguments(int a, int b, int expectedResult)
        {
            // Arrange

            // Act
            int actualResult = _math.Substract(a, b);
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}