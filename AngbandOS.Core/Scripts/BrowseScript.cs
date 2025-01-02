// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrowseScript : Script, IScript, IGameCommandScript, ISuccessByChanceScript, IScriptStore
{
    private BrowseScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the browse script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the browse script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public GameCommandResult ExecuteGameCommandScript()
    {
        ExecuteSuccessByChanceScript();
        return new GameCommandResult(false);
    }

    /// <summary>
    /// Executes the browse script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    /// <summary>
    /// Executes the activate script and returns true, if a book was rendered; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        // Make sure we can read
        if (!Game.CanCastSpells)
        {
            Game.MsgPrint("You cannot read books!");
            return false;
        }
        // Get a book to read if we don't already have one
        if (!Game.SelectItem(out Item? item, "Browse which book? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(IsUsableSpellBookItemFilter))))
        {
            Game.MsgPrint("You have no books that you can read.");
            return false;
        }
        if (item == null)
        {
            return false;
        }

        // Check that the book is useable by the player
        if (item.Spells == null)
        {
            Game.MsgPrint("You can't read that.");
            return false;
        }
        Game.HandleStuff();

        // Save the screen and overprint the spells in the book
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.PrintSpells(item.Spells.ToArray(), 1, 20);
        Game.MsgClear();
        // Wait for a keypress and re-load the screen
        Game.Screen.Print("[Press any key to continue]", 0, 23);
        Game.Inkey();
        Game.Screen.Restore(savedScreen);
        return true;
    }
}
