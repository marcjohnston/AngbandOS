
namespace Big6Search.ScriptingEngine.RunTime
{
    /// <summary>
    /// Represents a message that is sent by the job to inform the application that a command is being executed.
    /// </summary>
    /// <remarks></remarks>
    public class RunTimeCommandExecuting : JobMessage
    {

        public readonly RunTimeObject RunTimeObject;
        public RunTimeCommandExecuting(RunTimeObject runTimeObject)
        {
            RunTimeObject = runTimeObject;
        }
    }
}