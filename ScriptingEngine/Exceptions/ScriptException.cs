using System;

namespace Big6Search.ScriptingEngine
{
    /// <summary>
/// Represents a base class for all exceptions that are thrown by the scripting engine.
/// </summary>
/// <remarks></remarks>
    public abstract class ScriptException : Exception
    {

        public ScriptException(string message) : base(message)
        {
        }
    }
}