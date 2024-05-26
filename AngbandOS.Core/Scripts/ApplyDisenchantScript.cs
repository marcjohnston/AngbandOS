// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ApplyDisenchantScript : Script, IScript, ISuccessfulScript
{
    private ApplyDisenchantScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns a success result.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        // Select an inventory slot where items can be disenchanted.
        BaseInventorySlot? inventorySlot = Game.SingletonRepository.ToWeightedRandom<BaseInventorySlot>(_inventorySlot => _inventorySlot.CanBeDisenchanted).ChooseOrDefault();
        if (inventorySlot == null)
        {
            // There are no inventory slots capable of being disenchanted.
            return false;
        }

        // Select an item in the inventory slot to be disenchanted.
        int i = inventorySlot.WeightedRandom.ChooseOrDefault();
        Item? oPtr = Game.GetInventoryItem(i);

        // The chosen slot does not have an item to disenchant.
        if (oPtr == null)
        {
            return false;
        }
        if (oPtr.BonusHit <= 0 && oPtr.BonusDamage <= 0 && oPtr.BonusArmorClass <= 0)
        {
            return false;
        }
        string oName = oPtr.GetDescription(false);
        string s;
        if (oPtr.IsArtifact && Game.RandomLessThan(100) < 71)
        {
            s = oPtr.Count != 1 ? "" : "s";
            Game.MsgPrint($"Your {oName} ({i.IndexToLabel()}) resist{s} disenchantment!");
            return true;
        }
        if (oPtr.BonusHit > 0)
        {
            oPtr.BonusHit--;
        }
        if (oPtr.BonusHit > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.BonusHit--;
        }
        if (oPtr.BonusDamage > 0)
        {
            oPtr.BonusDamage--;
        }
        if (oPtr.BonusDamage > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.BonusDamage--;
        }
        if (oPtr.BonusArmorClass > 0)
        {
            oPtr.BonusArmorClass--;
        }
        if (oPtr.BonusArmorClass > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.BonusArmorClass--;
        }
        s = oPtr.Count != 1 ? "were" : "was";
        Game.MsgPrint($"Your {oName} ({i.IndexToLabel()}) {s} disenchanted!");
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
