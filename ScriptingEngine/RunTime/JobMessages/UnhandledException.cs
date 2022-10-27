using System;

namespace Big6Search.ScriptingEngine.RunTime
{
    /// <summary>
    /// Represents a message that is sent by the job to the application when an unhandled exception has been thrown during execution.
    /// </summary>
    /// <remarks></remarks>
    public class UnhandledException : JobMessage
    {
        public readonly Exception Exception;
        public UnhandledException(Exception exception)
        {
            Exception = exception;
        }
    }
}