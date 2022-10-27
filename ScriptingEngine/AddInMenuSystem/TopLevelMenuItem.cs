
namespace Big6Search.ScriptingEngine
{
    public abstract class TopLevelMenuItem : DropDownMenu
    {

        #region TopLevelMenuText - Returns the text of the top level menu that this menu item will be placed in.  If this property returns nothing or the TopLevelMenu cannot be found, the installation of AddInMenuItem will fail.
        /// <summary>
    /// Returns the text of the top level menu that this menu item will be placed in.  If this property returns nothing or the TopLevelMenu cannot be found, the installation of AddInMenuItem will fail.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public abstract string TopLevelMenuText { get; }
        #endregion

    }
}