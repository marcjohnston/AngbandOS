// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IdentifyAllItemsScript : Script, IScript, ICastSpellScript, IStoreCommandScript
{
    private IdentifyAllItemsScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the identify all script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
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
        for (int i = 0; i < InventorySlotEnum.Total; i++)
        {
            Item? oPtr = Game.GetInventoryItem(i);
            if (oPtr == null)
            {
                continue;
            }
            oPtr.IsFlavorAware = true;
            oPtr.BecomeKnown();
            if (oPtr.Stompable)
            {
                string itemName = oPtr.GetFullDescription(true);
                Game.MsgPrint($"You destroy {itemName}.");
                int amount = oPtr.StackCount;
                oPtr.ModifyStackCount(-amount);
                Game.InvenItemOptimize(i);
                i--;
            }
        }
    }
}
