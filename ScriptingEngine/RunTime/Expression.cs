
namespace Big6Search.ScriptingEngine.RunTime
{
    public abstract class Expression : RunTimeObject
    {

        #region Private, Protected & Friends
        protected abstract DataValue DoCompute(Job job);
        #endregion

        #region Compute - Computes the current value of an expression.
        /// <summary>
        /// Computes the current value of an expression and validates that the data type matches a specific data type.  If the result data type does not match a runtime exception is thrown.
        /// </summary>
        /// <typeparam name="t"></typeparam>
        /// <param name="job"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataValue Compute<t>(Job job, bool allowNothing) where t : DataValue
        {
            OnExecutingEvent(job);
            var result = DoCompute(job);
            if (result == null)
            {
                if (!allowNothing)
                {
                    throw new RunTimeErrorScriptException("Missing parameter value.");
                }
                else if (typeof(t).IsAssignableFrom(result.GetType()))
                {
                    return result;
                }
                else
                {
                    throw new RunTimeErrorScriptException("Invalid parameter value.");
                }
            }
            else if (typeof(t).IsAssignableFrom(result.GetType()))
            {
                return result;
            }
            else
            {
                throw new RunTimeErrorScriptException("Parameter value wrong type.");
            }
        }
        /// <summary>
        /// Computes the current value of an expression.
        /// </summary>
        /// <param name="job"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataValue Compute(Job job)
        {
            OnExecutingEvent(job);
            return DoCompute(job);
        }
        #endregion

        #region Public Constructors
        public Expression(DebugSymbol debugSymbol) : base(debugSymbol)
        {
        }
        #endregion

    }
}