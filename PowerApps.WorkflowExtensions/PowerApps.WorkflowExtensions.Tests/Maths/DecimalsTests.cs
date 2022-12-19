using FakeXrmEasy;
using System.Collections.Generic;
using PowerApps.WorkflowExtensions.Maths;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests.Maths
{
    /// <summary>
    /// Tests the *Decimals helper.
    /// </summary>
    public class DecimalsTests
    {
        /// <summary>
        /// Tests the add helper.
        /// </summary>
        /// <param name="first">First number to be added.</param>
        /// <param name="second">Second number to be added.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(1.0, 1.0, 2.0)]
        [InlineData(-1.1, -1.1, -2.2)]
        [InlineData(-1.0, 1.5, 0.5)]
        public void Adds_Two_Numbers(decimal first, decimal second, decimal expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>() 
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };
            
            //Act
            var result = fakedContext.ExecuteCodeActivity<AddDecimals>(inputs);

            //Assert
            Assert.Equal(expected, (decimal)result["Result"]);
        }

        /// <summary>
        /// Tests the subtract helper.
        /// </summary>
        /// <param name="first">First number to be subtracted.</param>
        /// <param name="second">Second number to be subtracted.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(1.0, 1.0, 0.0)]
        [InlineData(-1.1, -1.5, 0.4)]
        [InlineData(-1.0, 1.5, -2.5)]
        public void Subtracts_Two_Numbers(decimal first, decimal second, decimal expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<SubtractDecimals>(inputs);

            //Assert
            Assert.Equal(expected, (decimal)result["Result"]);
        }

        /// <summary>
        /// Tests the multiply helper.
        /// </summary>
        /// <param name="first">First number to be multiplied.</param>
        /// <param name="second">Second number to be multiplied.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(2.0, 2.0, 4.0)]
        [InlineData(-1.1, -1.5, 1.65)]
        [InlineData(-1.0, 1.5, -1.5)]
        public void Multiplies_Two_Numbers(decimal first, decimal second, decimal expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<MultiplyDecimals>(inputs);

            //Assert
            Assert.Equal(expected, (decimal)result["Result"]);
        }


        /// <summary>
        /// Tests the multiply helper.
        /// </summary>
        /// <param name="first">First number to be multiplied.</param>
        /// <param name="second">Second number to be multiplied.</param>
        /// <param name="expected">Expected result to be returned.</param>
        [Theory]
        [InlineData(8.5, 2.5, 3.4)]
        [InlineData(-8.5, -2.5, 3.4)]
        [InlineData(3.0, 2.0, 1.5)]
        [InlineData(3.0, -2.0, -1.5)]
        public void Divide_Two_Numbers(decimal first, decimal second, decimal expected)
        {
            //Arrange
            var fakedContext = new XrmFakedContext();
            var inputs = new Dictionary<string, object>()
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };

            //Act
            var result = fakedContext.ExecuteCodeActivity<DivideDecimals>(inputs);

            //Assert
            Assert.Equal(expected, (decimal)result["Result"]);
        }
    }
}
