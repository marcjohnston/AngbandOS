
namespace Big6Search.ScriptingEngine
{

    /// <summary>
/// Represents a top-level menu.  Top-level menus are defined by add-in modules and can be installed in the IDE.  The Items property accepts both TopLevelMenuItems and AddInMenuItems.
/// </summary>
/// <remarks></remarks>
    public abstract class TopLevelMenu : AddInMenuItem
    {

        /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public abstract TopLevelMenuItem[] Items { get; }
    }
}