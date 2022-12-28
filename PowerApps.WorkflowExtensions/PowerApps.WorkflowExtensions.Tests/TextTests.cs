using System.Collections.Generic;
using PowerApps.WorkflowExtensions.Tests;
using PowerApps.WorkflowExtensions.Text;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests.Text
{
    /// <summary>
    /// Tests the Text helpers.
    /// </summary>
    public class TextTests
    {
        [Theory]
        [InlineData("Foo bar. Foo. Bar. Foobar foobar.", "foobar", false, true)]
        [InlineData("Foo bar. Foo. Bar. Foobar.", "FOOBAR", true, true)]
        [InlineData("Foo bar. Foo.\r\nBar.\r\nFoobar.", "Foobar", false, true)]
        public void Contains(string source, string find, bool ignoreCase, bool expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source },
                { "Find", find },
                { "IgnoreCase", ignoreCase }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<Contains>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }

        [Theory]
        [InlineData("12345\r\n12345", 12)]
        [InlineData("Foo bar.", 8)]
        [InlineData("", 0)]
        public void CharacterCount(string source, int expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<CharacterCount>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }

        [Theory]
        [InlineData("Foo bar. Foo. Bar. Foobar foobar.", "foobar", "boofar", "Foo bar. Foo. Bar. Foobar boofar.")]
        [InlineData("Foo bar foo bar. FOO BAR.", "foo", "bar", "Foo bar bar bar. FOO BAR.")]
        [InlineData("12345", "6", "0", "12345")]
        public void Replace(string source, string find, string replace, string expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source },
                { "Find", find },
                { "ReplaceWith", replace }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<Replace>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }

        [Theory]
        [InlineData("FOO\r\nBAR", "foo\r\nbar")]
        [InlineData("foO\r\nBAr", "foo\r\nbar")]
        [InlineData("", "")]
        public void ToLower(string source, string expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<ToLower>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }

        [Theory]
        [InlineData("FOO\r\nBAR", "FOO\r\nBAR")]
        [InlineData("foO\r\nBAr", "FOO\r\nBAR")]
        [InlineData("", "")]
        public void ToUpper(string source, string expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<ToUpper>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }

        [Theory]
        [InlineData("  Foo    ", "Foo")]
        [InlineData(" Foobar", "Foobar")]
        [InlineData("Foobar ", "Foobar")]
        [InlineData("", "")]
        public void Trim(string source, string expected)
        {
            // Arrange
            var inputs = new Dictionary<string, object>
            {
                { "Source", source }
            };
            var builder = new WorkflowTestBuilder();
            builder.Setup<Trim>();

            // Act
            var outputs = builder.Invoke(inputs);

            // Assert
            Assert.Equal(expected, outputs["Output"]);
        }
    }
}
