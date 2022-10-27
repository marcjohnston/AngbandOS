
namespace Big6Search.ScriptingEngine.RunTime
{
    /// <summary>
    /// Represents a message that is sent by the job to the application when a runtime error has occured.
    /// </summary>
    /// <remarks></remarks>
    public class RunTimeError : JobMessage
    {
        public readonly ScriptException ScriptException;
        public RunTimeError(ScriptException scriptException)
        {
            ScriptException = scriptException;
        }
    }
}