// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Gods;

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Allows the player to choose a quantity of items to convert into gold.
/// </summary>
[Serializable]
internal class AlchemyScript : Script, IScript, ICancellableScript
{
    private AlchemyScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script returning false, if the player cancels the selection or confirmation dialog; true, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        int amt = 1;
        bool force = Game.CommandArgument > 0;
        if (!Game.SelectItem(out Item? oPtr, "Turn which item to gold? ", false, true, true, null))
        {
            Game.MsgPrint("You have nothing to turn to gold.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        if (oPtr.Count > 1)
        {
            amt = Game.GetQuantity(oPtr.Count, true);
            if (amt <= 0)
            {
                return false;
            }
        }
        int oldNumber = oPtr.Count;
        oPtr.Count = amt;
        string oName = oPtr.GetFullDescription(true);
        oPtr.Count = oldNumber;
        if (!force)
        {
            if (!(oPtr.Value() < 1))
            {
                string outVal = $"Really turn {oName} to gold? ";
                if (!Game.GetCheck(outVal))
                {
                    return false;
                }
            }
        }
        if (oPtr.IsArtifact)
        {
            string feel = "special";
            Game.MsgPrint($"You fail to turn {oName} to gold!");
            if (oPtr.IsCursed() || oPtr.IsBroken())
            {
                feel = "terrible";
            }
            oPtr.Inscription = feel;
            oPtr.IdentSense = true;
            Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Set();
            return true;
        }
        int price = oPtr.RealValue();
        if (price <= 0)
        {
            Game.MsgPrint($"You turn {oName} to fool's gold.");
        }
        else
        {
            price /= 3;
            if (amt > 1)
            {
                price *= amt;
            }
            if (price > 30000)
            {
                price = 30000;
            }
            Game.MsgPrint($"You turn {oName} to {price} coins worth of gold.");
            Game.Gold.IntValue += price;
        }
        oPtr.ItemIncrease(-amt);
        oPtr.ItemDescribe();
        oPtr.ItemOptimize();
        return true;
    }

    /// <summary>
    /// Executes the cancellable script and disposes of the result.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteCancellableScript();
    }

}
