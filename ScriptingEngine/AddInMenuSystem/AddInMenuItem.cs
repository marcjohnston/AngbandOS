
namespace Big6Search.ScriptingEngine
{
    /// <summary>
    /// Represents the minimum elements needed for a menu item.
    /// </summary>
    /// <remarks></remarks>
    public abstract class AddInMenuItem
    {
        public abstract string Text { get; }
        public virtual bool Visible
        {
            get
            {
                return true;
            }
        }
        public virtual bool Enabled
        {
            get
            {
                return true;
            }
        }
        public virtual void OnClick(IScriptEngineIDE ide)
        {
        }
    }
}
