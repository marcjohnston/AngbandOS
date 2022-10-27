
namespace Big6Search.ScriptingEngine
{

    /// <summary>
/// 
/// </summary>
/// <remarks>
/// ScriptObjects are not expressions.  Their value is an expression, but they themselves are not.
/// </remarks>
    public class ScriptObject
    {
        public readonly string Name;
        public DataValue Value;
        public override string ToString()
        {
            return Value.ToString();
        }
        public ScriptObject(string name, DataValue value)
        {
            Name = name;
            Value = value;
        }
    }
}