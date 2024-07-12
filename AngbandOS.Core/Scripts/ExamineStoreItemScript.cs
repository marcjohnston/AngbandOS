// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ExamineStoreItemScript : Script, IScriptStore
{
    private ExamineStoreItemScript(Game game) : base(game) { }

    /// <summary>
    /// Allows the selection of an item in the store and renders a detailed description of the item.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        if (storeCommandEvent.Store.StoreInventoryList.Count <= 0)
        {
            Game.MsgPrint(storeCommandEvent.Store.StoreFactory.NoStockMessage);
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
        if (oPtr.Spells != null)
        {
            ScreenBuffer savedScreen = Game.Screen.Clone();
            Game.PrintSpells(oPtr.Spells.ToArray(), 1, 20);
            Game.MsgClear();
            Game.Screen.Print("[Press any key to continue]", 0, 23);
            Game.Inkey();
            Game.Screen.Restore(savedScreen);
        }
        else
        {
            Game.MsgPrint("The spells in the book are unintelligible to you.");
            return;
        }
        if (!oPtr.IdentMental)
        {
            Game.MsgPrint("You have no special knowledge about that item.");
            return;
        }
        string oName = oPtr.GetFullDescription(true);
        Game.MsgPrint($"Examining {oName}...");
        if (!oPtr.IdentifyFully())
        {
            Game.MsgPrint("You see nothing special.");
        }
    }
}
