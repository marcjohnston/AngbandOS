
namespace Big6Search.ScriptingEngine
{
    public partial class DataValue
    {
        public object Value { get; set; }
        /// <summary>
  /// Returns true, if the data type is an integer or a double; false, otherwise.
  /// </summary>
  /// <returns></returns>
  /// <remarks></remarks>
        public bool IsNumeric()
        {
            return IsDouble() | IsInteger();
        }
        public virtual DataValue Add(DataValue value)
        {
            throw new RunTimeErrorScriptException("Addition is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue Subtract(DataValue value)
        {
            throw new RunTimeErrorScriptException("Subtraction is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue Multiply(DataValue value)
        {
            throw new RunTimeErrorScriptException("Multiplication is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue Divide(DataValue value)
        {
            throw new RunTimeErrorScriptException("Division is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsEqualTo(DataValue value)
        {
            throw new RunTimeErrorScriptException("Equality is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsNotEqualTo(DataValue value)
        {
            throw new RunTimeErrorScriptException("Equality is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsLessThan(DataValue value)
        {
            throw new RunTimeErrorScriptException("Magnitude comparison is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsGreaterThan(DataValue value)
        {
            throw new RunTimeErrorScriptException("Magnitude comparison is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsLessThanOrEqualTo(DataValue value)
        {
            throw new RunTimeErrorScriptException("Magnitude comparison is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue IsGreaterThanOrEqualTo(DataValue value)
        {
            throw new RunTimeErrorScriptException("Magnitude comparison is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue Or(DataValue value)
        {
            throw new RunTimeErrorScriptException("Or is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
        public virtual DataValue And(DataValue value)
        {
            throw new RunTimeErrorScriptException("And is not defined for " + GetType().Name + " and " + value.GetType().Name);
        }
    }
}