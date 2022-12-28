using System.Collections.Generic;
using PowerApps.WorkflowExtensions.Maths;
using Xunit;

namespace PowerApps.WorkfowExtensionsTests.Maths
{
    /// <summary>
    /// Tests the Text helpers.
    /// </summary>
    public class TextTests
    {
        ///// <summary>
        ///// Tests the replace helper.
        ///// </summary>
        ///// <param name="source">Source text to search.</param>
        ///// <param name="find">Text to find.</param>
        ///// <param name="replaceWith">Text to replace with.</param>
        ///// <param name="expected">Expected result to be returned.</param>
        //[Theory]
        //[InlineData("this is foo bar text", "foo", "bar", "this is bar bar text")]
        //[InlineData("this is foo\r\nbar text", "bar", "foo", "this is foo\r\nfoo text")]
        //public void Replace_Text(string source, string find, string replaceWith, string expected)
        //{
        //    ////Arrange
        //    //var fakedContext = new XrmFakedContext();
        //    //var inputs = new Dictionary<string, object>() 
        //    //{
        //    //    { "Source", source },
        //    //    { "Find", find },
        //    //    { "ReplaceWith", replaceWith }
        //    //};

        //    ////Act
        //    //var result = fakedContext.ExecuteCodeActivity<Replace>(inputs);

        //    ////Assert
        //    //Assert.Equal(expected, (string)result["Output"]);
        //}

        ///// <summary>
        ///// Tests the contains helper.
        ///// </summary>
        ///// <param name="source">Text to search within.</param>
        ///// <param name="find">The text to find.</param>
        ///// <param name="expected">Expected result to be returned.</param>
        //[Theory]
        //[InlineData("this is foo bar text", "foo", true)]
        //[InlineData("this is foo\r\nbar text", "foobar", false)]
        //public void Contains_Text(string source, string find, bool expected)
        //{
        //    ////Arrange
        //    //var fakedContext = new XrmFakedContext();
        //    //var inputs = new Dictionary<string, object>()
        //    //{
        //    //    { "Source", source },
        //    //    { "Find", find }
        //    //};

        //    ////Act
        //    //var result = fakedContext.ExecuteCodeActivity<Contains>(inputs);

        //    ////Assert
        //    //Assert.Equal(expected, (bool)result["Output"]);
        //}
    }
}
