namespace PowerApps.WorkflowExtensions.Maths
{
    /// <summary>
    /// Workflow extensions for maths related operations.
    /// </summary>
    public class MathsExtensionSet : BaseExtensionSet
    {
        // Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="worker">The worker for this collection of workflow extensions.</param>
        public MathsExtensionSet(WorkflowHelper worker): base(worker)
        {

        }

        // Workflows

        /// <summary>
        /// Adds two decimals together.
        /// </summary>
        /// <param name="first">The first decimal to be added.</param>
        /// <param name="second">The second decimal to be added.</param>
        /// <returns>The result of adding the two decimals together.</returns>
        public decimal AddDecimals(decimal first, decimal second)
        {
            return first + second;
        }

        /// <summary>
        /// Adds two doubles together.
        /// </summary>
        /// <param name="first">The first double to be added.</param>
        /// <param name="second">The second double to be added.</param>
        /// <returns>The result of adding the two doubles together.</returns>
        public double AddDoubles(double first, double second)
        {
            return first + second;
        }

        /// <summary>
        /// Adds two integers together.
        /// </summary>
        /// <param name="first">The first integer to be added.</param>
        /// <param name="second">The second integer to be added.</param>
        /// <returns>The result of adding the two integers together.</returns>
        public int AddIntegers(int first, int second)
        {
            return first + second;
        }

        /// <summary>
        /// Divides two decimals.
        /// </summary>
        /// <param name="first">The first decimal to be divided.</param>
        /// <param name="second">The second decimal to be divided.</param>
        /// <returns>The result of dividing the two decimals.</returns>
        public decimal DivideDecimals(decimal first, decimal second)
        {
            return first / second;
        }

        /// <summary>
        /// Divides two doubles.
        /// </summary>
        /// <param name="first">The first double to be divided.</param>
        /// <param name="second">The second double to be divided.</param>
        /// <returns>The result of dividing the two doubles.</returns>
        public double DivideDoubles(double first, double second)
        {
            return first / second;
        }

        /// <summary>
        /// Divides two integers.
        /// </summary>
        /// <param name="first">The first integer to be divided.</param>
        /// <param name="second">The second integer to be divided.</param>
        /// <returns>The result of dividing the two integers.</returns>
        public int DivideIntegers(int first, int second)
        {
            return first / second;
        }

        /// <summary>
        /// Multiplies two decimals.
        /// </summary>
        /// <param name="first">The first decimal to be multiplied.</param>
        /// <param name="second">The second decimal to be multiplied.</param>
        /// <returns>The result of multiplying the two decimals.</returns>
        public decimal MultiplyDecimals(decimal first, decimal second)
        {
            return first * second;
        }

        /// <summary>
        /// Multiplies two doubles.
        /// </summary>
        /// <param name="first">The first double to be multiplied.</param>
        /// <param name="second">The second double to be multiplied.</param>
        /// <returns>The result of multiplying the two doubles.</returns>
        public double MultiplyDoubles(double first, double second)
        {
            return first * second;
        }

        /// <summary>
        /// Multiplies two integers.
        /// </summary>
        /// <param name="first">The first integer to be multiplied.</param>
        /// <param name="second">The second integer to be multiplied.</param>
        /// <returns>The result of multiplying the two integers.</returns>
        public int MultiplyIntegers(int first, int second)
        {
            return first * second;
        }

        /// <summary>
        /// Subtracts two decimals.
        /// </summary>
        /// <param name="first">The first decimal to be subtracted.</param>
        /// <param name="second">The second decimal to be subtracted.</param>
        /// <returns>The result of subtracting the two decimals.</returns>
        public decimal SubtractDecimals(decimal first, decimal second)
        {
            return first - second;
        }

        /// <summary>
        /// Subtracts two doubles.
        /// </summary>
        /// <param name="first">The first double to be subtracted.</param>
        /// <param name="second">The second double to be subtracted.</param>
        /// <returns>The result of subtracting the two doubles.</returns>
        public double SubtractDoubles(double first, double second)
        {
            return first - second;
        }

        /// <summary>
        /// Subtracts two integers.
        /// </summary>
        /// <param name="first">The first integer to be subtracted.</param>
        /// <param name="second">The second integer to be subtracted.</param>
        /// <returns>The result of subtracting the two integers.</returns>
        public int SubtractIntegers(int first, int second)
        {
            return first - second;
        }
    }
}
