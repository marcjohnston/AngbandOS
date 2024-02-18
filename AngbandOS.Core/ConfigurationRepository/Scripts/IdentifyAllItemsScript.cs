// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IdentifyAllItemsScript : Script, IScript, IStoreScript
{
    private IdentifyAllItemsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the identify all script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (!SaveGame.ServiceHaggle(500, out int price))
        {
            if (price >= SaveGame.Gold)
            {
                SaveGame.MsgPrint("You do not have the gold!");
            }
            else
            {
                SaveGame.Gold -= price;
                SaveGame.SayComment_1();
                SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                SaveGame.StorePrtGold();
                ExecuteScript();
                SaveGame.MsgPrint("All your goods have been identified.");
            }
            SaveGame.HandleStuff();
        }
    }

    /// <summary>
    /// Executes the identify all script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int i = 0; i < InventorySlot.Total; i++)
        {
            Item? oPtr = SaveGame.GetInventoryItem(i);
            if (oPtr == null)
            {
                continue;
            }
            oPtr.BecomeFlavorAware();
            oPtr.BecomeKnown();
            if (oPtr.Stompable())
            {
                string itemName = oPtr.Description(true, 3);
                SaveGame.MsgPrint($"You destroy {itemName}.");
                int amount = oPtr.Count;
                SaveGame.InvenItemIncrease(i, -amount);
                SaveGame.InvenItemOptimize(i);
                i--;
            }
        }
    }
}
