// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IdentifyAllItemsScript : Script, IScript, IScriptStore
{
    private IdentifyAllItemsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the identify all script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        if (!Game.ServiceHaggle(500, out int price))
        {
            if (price >= Game.Gold.IntValue)
            {
                Game.MsgPrint("You do not have the gold!");
            }
            else
            {
                Game.Gold.IntValue -= price;
                Game.SayComment_1();
                Game.PlaySound(SoundEffectEnum.StoreTransaction);
                Game.StorePrtGold();
                ExecuteScript();
                Game.MsgPrint("All your goods have been identified.");
            }
            Game.HandleStuff();
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
            Item? oPtr = Game.GetInventoryItem(i);
            if (oPtr == null)
            {
                continue;
            }
            oPtr.Factory.IsFlavorAware = true;
            oPtr.BecomeKnown();
            if (oPtr.Stompable())
            {
                string itemName = oPtr.GetFullDescription(true);
                Game.MsgPrint($"You destroy {itemName}.");
                int amount = oPtr.Count;
                Game.InvenItemIncrease(i, -amount);
                Game.InvenItemOptimize(i);
                i--;
            }
        }
    }
}
