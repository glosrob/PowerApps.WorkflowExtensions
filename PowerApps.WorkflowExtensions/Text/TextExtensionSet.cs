using System;

namespace PowerApps.WorkflowExtensions.Calendar
{
    /// <summary>
    /// Workflow extensions for date related operations.
    /// </summary>
    public class TextExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public TextExtensionSet(WorkflowHelper worker): base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Gets the number of characters in text.
        /// </summary>
        /// <returns>The number of characters in the text block./returns>
        public int CharacterCount(string text)
        {
            return (text ?? string.Empty).Length;
        }

        /// <summary>
        /// Verifies whether text contains some other text.
        /// </summary>
        /// <param name="text">The text to try to find the text in.</param>
        /// <param name="find">The text to try to find.</param>
        /// <param name="ignoreCase">Whether to ignore the case of the text.</param>
        /// <returns>Whether the text was found.</returns>
        public bool Contains(string text, string find, bool ignoreCase)
        {
            return text.IndexOf(find, ignoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture) > 0;
        }

        /// <summary>
        /// Verifies whether text contains some other text.
        /// </summary>
        /// <param name="text">The text to try to find the text in.</param>
        /// <param name="find">The text to try to find.</param>
        /// <param name="replace">The replacement text.</param>
        /// <returns>The updated text.</returns>
        public string Replace(string text, string find, string replace)
        {
            return (text ?? string.Empty).Replace(find, replace);
        }

        /// <summary>
        /// Converts some text to be all lower case.
        /// </summary>
        /// <returns>The text converted to all lower case./returns>
        public string ToLower(string text)
        {
            return (text ?? string.Empty).ToLower();
        }

        /// <summary>
        /// Converts some text to be all upper case.
        /// </summary>
        /// <returns>The text converted to all upper case./returns>
        public string ToUpper(string text)
        {
            return (text ?? string.Empty).ToUpper();
        }

        /// <summary>
        /// Trims some text to remove all leading and trailing spaces.
        /// </summary>
        /// <returns>The trimmed text./returns>
        public string Trim(string text)
        {
            return (text ?? string.Empty).Trim();
        }
    }
}
