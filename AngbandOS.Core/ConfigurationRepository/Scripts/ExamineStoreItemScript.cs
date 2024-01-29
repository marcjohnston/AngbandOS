// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ExamineStoreItemScript : Script, IStoreScript
{
    private ExamineStoreItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows the selection of an item in the store and renders a detailed description of the item.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (storeCommandEvent.Store.StoreInventoryList.Count <= 0)
        {
            SaveGame.MsgPrint(storeCommandEvent.Store.StoreFactory.NoStockMessage);
            return;
        }
        int i = storeCommandEvent.Store.StoreInventoryList.Count - storeCommandEvent.Store.StoreTop;
        if (i > storeCommandEvent.Store.StoreFactory.PageSize)
        {
            i = storeCommandEvent.Store.StoreFactory.PageSize;
        }
        const string outVal = "Which item do you want to examine? ";
        if (!storeCommandEvent.Store.GetStock(out int item, outVal, 0, i - 1))
        {
            return;
        }
        item += storeCommandEvent.Store.StoreTop;
        Item oPtr = storeCommandEvent.Store.StoreInventoryList[item];
        BookItemFactory? bookItemFactory = oPtr.TryGetFactory<BookItemFactory>();
        if (bookItemFactory != null)
        {
            if (SaveGame.PrimaryRealm?.SpellBookItemCategory == oPtr.Category || SaveGame.SecondaryRealm?.SpellBookItemCategory == oPtr.Category)
            {
                DoStoreBrowse(oPtr);
            }
            else
            {
                SaveGame.MsgPrint("The spells in the book are unintelligible to you.");
                return;
            }
        }
        if (!oPtr.IdentMental)
        {
            SaveGame.MsgPrint("You have no special knowledge about that item.");
            return;
        }
        string oName = oPtr.Description(true, 3);
        SaveGame.MsgPrint($"Examining {oName}...");
        if (!oPtr.IdentifyFully())
        {
            SaveGame.MsgPrint("You see nothing special.");
        }
    }

    private void DoStoreBrowse(Item oPtr)
    {
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        BookItemFactory book = (BookItemFactory)oPtr.Factory;
        SaveGame.PrintSpells(book.Spells.ToArray(), 1, 20);
        SaveGame.Screen.PrintLine("", 0, 0);
        SaveGame.Screen.Print("[Press any key to continue]", 0, 23);
        SaveGame.Inkey();
        SaveGame.Screen.Restore(savedScreen);
    }
}
