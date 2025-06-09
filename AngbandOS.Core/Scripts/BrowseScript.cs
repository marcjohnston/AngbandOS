// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrowseScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private BrowseScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the browse script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the browse script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the browse script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Make sure we can read
        if (!Game.CanCastSpells)
        {
            Game.MsgPrint("You cannot read books!");
            return;
        }
        // Get a book to read if we don't already have one
        if (!Game.SelectItem(out Item? item, "Browse which book? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(IsUsableSpellBookItemFilter))))
        {
            Game.MsgPrint("You have no books that you can read.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Check that the book is useable by the player
        if (item.Spells == null)
        {
            Game.MsgPrint("You can't read that.");
            return;
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
    }
}
