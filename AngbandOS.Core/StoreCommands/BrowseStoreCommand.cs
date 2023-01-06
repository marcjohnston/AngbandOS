namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseStoreCommand : BaseStoreCommand
    {
        public override char Key => 'b';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdBrowse(storeCommandEvent.SaveGame);
        }

        public static void DoCmdBrowse(SaveGame saveGame)
        {
            int spell;
            int spellIndex = 0;
            int[] spells = new int[64];
            // Make sure we can read
            if (saveGame.Player.Realm1 == 0 && saveGame.Player.Realm2 == 0)
            {
                saveGame.MsgPrint("You cannot read books!");
                return;
            }
            // Get a book to read if we don't already have one
            if (!saveGame.GetItem(out int itemIndex, "Browse which book? ", false, true, true, new UsableSpellBookItemFilter(saveGame)))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have no books that you can read.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Check that the book is useable by the player
            if (!saveGame.Player.ItemMatchesFilter(item, new UsableSpellBookItemFilter(saveGame)))
            {
                saveGame.MsgPrint("You can't read that.");
                return;
            }
            int bookSubCategory = item.ItemSubCategory;
            saveGame.HandleStuff();
            // Find all spells in the book and add them to the array
            for (spell = 0; spell < 32; spell++)
            {
                if ((GlobalData.BookSpellFlags[bookSubCategory] & (1u << spell)) != 0)
                {
                    spells[spellIndex++] = spell;
                }
            }
            // Save the screen and overprint the spells in the book
            saveGame.SaveScreen();
            saveGame.Player.PrintSpells(spells, spellIndex, 1, 20, item.BaseItemCategory.SpellBookToToRealm);
            saveGame.PrintLine("", 0, 0);
            // Wait for a keypress and re-load the screen
            saveGame.Print("[Press any key to continue]", 0, 23);
            saveGame.Inkey();
            saveGame.Load();
        }
    }
}
