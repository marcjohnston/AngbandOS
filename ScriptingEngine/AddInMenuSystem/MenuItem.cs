using System.Drawing;
using System.Windows.Forms;

namespace Big6Search.ScriptingEngine
{
    /// <summary>
    /// Represents a menu item that can be attached to a TopLevelMenu or a JobPopupMenu.
    /// </summary>
    /// <remarks></remarks>
    public abstract class MenuItem : AddInMenuItem
    {

        #region GroupNumber - Represents the index of the group in which the menu item should be placed.  Groups are placed in TopLevelMenus and JobPopupMenus numerically in order.  Separators are placed between groups automatically.
        /// <summary>
    /// Represents the index of the group in which the menu item should be placed.  Groups are placed in TopLevelMenus and JobPopupMenus numerically in order.  Separators are placed between groups automatically.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public virtual string Group
        {
            get
            {
                return null;
            }
        }
        #endregion
        public virtual Keys ShortcutKeys
        {
            get
            {
                return default;
            }
        }
        public virtual Image Image
        {
            get
            {
                return null;
            }
        }
    }
}
