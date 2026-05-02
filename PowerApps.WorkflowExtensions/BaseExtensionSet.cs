namespace PowerApps.WorkflowExtensions
{
    /// <summary>
    /// Base class for all extension sets. 
    /// </summary>
    public abstract class BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="helper">The WorkflowHelper for this extension set.</param>
        public BaseExtensionSet(WorkflowHelper helper)
        {
            Helper = helper;
        }

        // Properties

        protected WorkflowHelper Helper { get; set; }
    }
}
