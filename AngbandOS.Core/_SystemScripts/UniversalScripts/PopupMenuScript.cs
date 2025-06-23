// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PopupMenuScript : UniversalScript, IGetKey
{
    private PopupMenuScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the popup-menu script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        List<string> menuItems = new List<string>() { "Resume Game", "Save and Quit" };
        PopupMenu menu = new PopupMenu(menuItems);
        int result = menu.Show(Game);
        switch (result)
        {
            // Escape or Resume Game
            case -1:
            case 0:
                break;
            // Save and Quit
            case 1:
                Game.Playing = false; // TODO: Need to use event arguments
                break;
        }
    }
}
