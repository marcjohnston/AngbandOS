using System;

namespace Big6Search.ScriptingEngine
{
    public abstract class AddIn
    {
        public abstract Guid Guid { get; }
        public virtual FactorParser[] FactorParsers
        {
            get
            {
                return null;
            }
        }
        public virtual CommandParser[] CommandParsers
        {
            get
            {
                return null;
            }
        }
        public virtual DataTypeParser[] DataTypeParsers
        {
            get
            {
                return null;
            }
        }
        public virtual string Title
        {
            get
            {
                return GetType().Name;
            }
        }
        public virtual string Description
        {
            get
            {
                return Title;
            }
        }
        public virtual AddInMenuItem[] AddInMenus
        {
            get
            {
                return null;
            }
        }
        protected event JobStoppedEventHandler JobStopped;

        protected delegate void JobStoppedEventHandler(RunTime.Job job);
        protected event BeforeJobStartEventHandler BeforeJobStart;

        protected delegate void BeforeJobStartEventHandler(RunTime.Job job);
        /// <summary>
    /// Fires the BeforeExecute event.  Called before the scripting engine executes a script.  Allows an add-in module to perform preexecute actions on the main-thread.
    /// </summary>
    /// <param name="job"></param>
    /// <remarks></remarks>
        public virtual void OnBeforeJobStart(RunTime.Job job)
        {
            BeforeJobStart?.Invoke(job);
        }
        public virtual void OnJobStopped(RunTime.Job job)
        {
            JobStopped?.Invoke(job);
        }
        public virtual void Unload()
        {
        }
    }
}