using FakeXrmEasy;
using System.Collections.Generic;
using PowerApps.WorkflowExtensions.Maths;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests.Maths
{
    /// <summary>
    /// Tests the *Integers helper.
    /// </summary>
    public class IntegersTests
    {
        /// <summary>
        /// Tests the add helper.
        /// </summary>
        /// <param name="first">First number to be added.</param>
        /// <param name="second">Second number to be added.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, -1, -2)]
        [InlineData(-1, 1, 0)]
        public void Adds_Two_Numbers(int first, int second, int expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>() 
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<AddIntegers>(inputs);

            //Assert
            Assert.Equal(expected, (int)result["Result"]);
        }

        /// <summary>
        /// Tests the subtract helper.
        /// </summary>
        /// <param name="first">First number to be subtracted.</param>
        /// <param name="second">Second number to be subtracted.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(-1, -1, 0)]
        [InlineData(-1, 1, -2)]
        public void Subtracts_Two_Numbers(int first, int second, int expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<SubtractIntegers>(inputs);

            //Assert
            Assert.Equal(expected, (int)result["Result"]);
        }

        /// <summary>
        /// Tests the multiply helper.
        /// </summary>
        /// <param name="first">First number to be multiplied.</param>
        /// <param name="second">Second number to be multiplied.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, -1, 1)]
        [InlineData(-1, 1, -1)]
        public void Multiplies_Two_Numbers(int first, int second, int expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<MultiplyIntegers>(inputs);

            //Assert
            Assert.Equal(expected, (int)result["Result"]);
        }
    }
}
