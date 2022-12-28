using PowerApps.WorkflowExtensions.Maths;
using System.Collections.Generic;
using Xunit;

namespace PowerApps.WorkflowExtensions.Tests
{
    /// <summary>
    /// Tests for the Maths extension helpers.
    /// </summary>
    public class MathsTests
    {
        [Theory]
        [InlineData(10.0, 1.0, 11.0)]
        [InlineData(10.5, 1.5, 12.0)]
        [InlineData(10.25, 1.1, 11.35)]
        public void AddDecimals(decimal first, decimal second, decimal expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<AddDecimals>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 11.0)]
        [InlineData(10.5, 1.5, 12.0)]
        [InlineData(10.25, 1.1, 11.35)]
        public void AddDoubles(double first, double second, double expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDouble", first },
                { "SecondDouble", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<AddDoubles>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10, 1, 11)]
        [InlineData(15, 20, 35)]
        public void AddIntegers(int first, int second, int expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<AddIntegers>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 9.0)]
        [InlineData(10.5, 1.5, 9.0)]
        [InlineData(10.25, 1.1, 9.15)]
        [InlineData(5.0, 10.0, -5.0)]
        public void SubtractDecimals(decimal first, decimal second, decimal expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<SubtractDecimals>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 9.0)]
        [InlineData(10.5, 1.5, 9.0)]
        [InlineData(10.25, 1.1, 9.15)]
        [InlineData(5.0, 10.0, -5.0)]
        public void SubtractDoubles(double first, double second, double expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDouble", first },
                { "SecondDouble", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<SubtractDoubles>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10, 1, 9)]
        [InlineData(10, 5, 5)]
        [InlineData(15, 20, -5)]
        public void SubtractIntegers(int first, int second, int expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<SubtractIntegers>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 10.0)]
        [InlineData(10.5, 1.5, 7.0)]
        [InlineData(10.25, 2.5, 4.1)]
        public void DivideDecimals(decimal first, decimal second, decimal expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<DivideDecimals>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 10.0)]
        [InlineData(10.5, 1.5, 7.0)]
        [InlineData(10.25, 2.5, 4.1)]
        public void DivideDoubles(double first, double second, double expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDouble", first },
                { "SecondDouble", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<DivideDoubles>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(15, 3, 5)]
        public void DivideIntegers(int first, int second, int expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<DivideIntegers>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 10.0)]
        [InlineData(10.5, 1.5, 15.75)]
        [InlineData(10.25, 2.5, 25.625)]
        [InlineData(100.00, 0, 0.00)]
        public void MultiplyDecimals(decimal first, decimal second, decimal expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDecimal", first },
                { "SecondDecimal", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<MultiplyDecimals>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10.0, 1.0, 10.0)]
        [InlineData(10.5, 1.5, 15.75)]
        [InlineData(10.25, 2.5, 25.625)]
        [InlineData(100.00, 0, 0.00)]
        public void MultiplyDoubles(double first, double second, double expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstDouble", first },
                { "SecondDouble", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<MultiplyDoubles>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }

        [Theory]
        [InlineData(10, 5, 50)]
        [InlineData(100, 0, 0)]
        [InlineData(15, 3, 45)]
        public void MultiplyIntegers(int first, int second, int expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "FirstInteger", first },
                { "SecondInteger", second }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<MultiplyIntegers>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Result"]);
        }
    }
}
