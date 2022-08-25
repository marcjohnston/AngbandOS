using Cthangband.Commands;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseStoreCommand : IStoreCommand
    {
        public char Key => 'b';

        public bool RequiresRerendering => false;

        public string Description => "";

        public bool IsEnabled(Store store) => true;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdBrowse(saveGame);
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
            Inventory.ItemFilterUseableSpellBook = true;
            if (!saveGame.GetItem(out int itemIndex, "Browse which book? ", false, true, true))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have no books that you can read.");
                }
                Inventory.ItemFilterUseableSpellBook = false;
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Check that the book is useable by the player
            Inventory.ItemFilterUseableSpellBook = true;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("You can't read that.");
                Inventory.ItemFilterUseableSpellBook = false;
                return;
            }
            Inventory.ItemFilterUseableSpellBook = false;
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
            saveGame.Save();
            saveGame.Player.PrintSpells(spells, spellIndex, 1, 20, item.ItemType.BaseCategory.SpellBookToToRealm);
            saveGame.PrintLine("", 0, 0);
            // Wait for a keypress and re-load the screen
            saveGame.Print("[Press any key to continue]", 0, 23);
            saveGame.Inkey();
            saveGame.Load();
        }
    }
}
