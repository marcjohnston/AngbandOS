
namespace Big6Search.ScriptingEngine
{
    /// <summary>
/// Represents an exception that is thrown by the scripting engine during the processing of a script.
/// </summary>
/// <remarks></remarks>
    public class RunTimeErrorScriptException : ScriptException
    {

        public RunTimeErrorScriptException(string message) : base(message)
        {
        }
    }
}