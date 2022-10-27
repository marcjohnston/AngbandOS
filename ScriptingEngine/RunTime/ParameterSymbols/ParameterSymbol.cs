
namespace Big6Search.ScriptingEngine.RunTime
{
    #region ParameterSymbol - Represents an object that is passed to the CreateExpression method for a FunctionParser.
    /// <summary>
    /// Represents an object that is passed to the CreateExpression method for a FunctionParser.
    /// </summary>
    /// <remarks></remarks>
    public class ParameterSymbol : RunTimeObject
    {

        /// <summary>
        /// Creates a new parameter with no debug symbol information.
        /// </summary>
        /// <remarks></remarks>
        public ParameterSymbol() : this(null)
        {
        }
        /// <summary>
        /// Creates a new parameter with debug symbol information.
        /// </summary>
        /// <param name="debugSymbol"></param>
        /// <remarks></remarks>
        public ParameterSymbol(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
    }
    #endregion
}