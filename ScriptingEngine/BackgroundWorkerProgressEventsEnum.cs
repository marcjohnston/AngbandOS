
namespace Big6Search.ScriptingEngine
{
    /// <summary>
/// Represents messages sent from the background thread to the main thread.
/// </summary>
/// <remarks></remarks>
    internal enum BackgroundWorkerProgressEventsEnum
    {
        ScriptComplete,
        RuntimeError,
        UnhandledException,
        MarshalToMainThread,
        Message,
        /// <summary>
    /// Represents a message sent from the background worker to the main thread to execute a routine from the main thread.
    /// </summary>
    /// <remarks></remarks>
        Invoke
    }
}