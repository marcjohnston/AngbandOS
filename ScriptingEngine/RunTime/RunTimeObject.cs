using System.Diagnostics;

namespace Big6Search.ScriptingEngine.RunTime
{
    #region RunTimeObject - Implements a baseclass that is used to create runtime objects.
    /// <summary>
    /// Implements a baseclass that is used to create runtime objects.  Runtime objects implement debugging and other features like generating treenodes to construct TreeView objects.  Commands and expressions
    /// both implement runtime objects.  Runtime objects may implement different types of execution functions.  Derived classes should call the IndicateAsExecuting method when they are currently executing.  This
    /// allows the runtime object to perform debugging operations.
    /// </summary>
    /// <remarks></remarks>
    public abstract class RunTimeObject
    {
        protected virtual void OnExecutingEvent(Job job)
        {
            job.RaiseMessage(new RunTimeCommandExecuting(this));
        }
        /// <summary>
        /// Function overridden by derived classes to create a treenode representation of the runtime object.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public virtual ScriptTreeNode ToTreeNode()
        {
            return new ScriptTreeNode(this, GetType().Name);
        }
        public virtual object ToText()
        {
            return GetType().Name;
        }
        /// <summary>
        /// Returns the debug symbol for this runtime object.
        /// </summary>
        /// <remarks></remarks>
        public readonly DebugSymbol DebugSymbol;

        #region Public Constructors
        /// <summary>
        /// Creates a new RunTimeObject with optional debug symbol information.
        /// </summary>
        /// <param name="debugSymbol"></param>
        /// <remarks></remarks>
        public RunTimeObject(DebugSymbol debugSymbol)
        {
            Debug.Assert(!(debugSymbol == null), "No debug symbol specified for runtime object of type " + GetType().Name + ".");
            DebugSymbol = debugSymbol;
        }
        #endregion
    }
    #endregion
}