
namespace Big6Search.ScriptingEngine
{
    public abstract class SubMenuItem : MenuItem
    {
        /// <summary>
        /// Returns the text of the TopLevelMenuItem or JobMenuItem that this sub menu item will be placed in.  If this property returns nothing or the MenuItem cannot be found in the TopLevelMenu, the installation of SubMenuItem will fail.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public abstract string MenuItemText { get; }
    }
}
