
namespace Big6Search.ScriptingEngine
{
    public abstract class DropDownMenu : MenuItem
    {

        /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
        public virtual SubMenuItem[] Items
        {
            get
            {
                return null;
            }
        }
    }
}