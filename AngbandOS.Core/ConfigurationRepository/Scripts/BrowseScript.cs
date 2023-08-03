// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BrowseScript : Script
{
    private BrowseScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // Make sure we can read
        if (!SaveGame.CanCastSpells)
        {
            SaveGame.MsgPrint("You cannot read books!");
            return false;
        }
        // Get a book to read if we don't already have one
        if (!SaveGame.SelectItem(out Item? item, "Browse which book? ", false, true, true, new UsableSpellBookItemFilter(SaveGame)))
        {
            SaveGame.MsgPrint("You have no books that you can read.");
            return false;
        }
        if (item == null)
        {
            return false;
        }
        // Check that the book is useable by the player
        if (!SaveGame.ItemMatchesFilter(item, new UsableSpellBookItemFilter(SaveGame)))
        {
            SaveGame.MsgPrint("You can't read that.");
            return false;
        }
        SaveGame.HandleStuff();

        // Save the screen and overprint the spells in the book
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        BookItemFactory book = (BookItemFactory)item.Factory;
        SaveGame.PrintSpells(book.Spells.ToArray(), 1, 20);
        SaveGame.Screen.PrintLine("", 0, 0);
        // Wait for a keypress and re-load the screen
        SaveGame.Screen.Print("[Press any key to continue]", 0, 23);
        SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);
        return false;
    }
}
