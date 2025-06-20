﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ApplyDisenchantScript : Script, IScript, ICastSpellScript, IEatOrQuaffScript
{
    private ApplyDisenchantScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the script and returns a success result.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Select an inventory slot where items can be disenchanted.
        WieldSlot? inventorySlot = Game.SingletonRepository.ToWeightedRandom<WieldSlot>(_inventorySlot => _inventorySlot.CanBeDisenchanted).ChooseOrDefault();
        if (inventorySlot == null)
        {
            // There are no inventory slots capable of being disenchanted.
            return IdentifiedResult.False;
        }

        // Select an item in the inventory slot to be disenchanted.
        int i = inventorySlot.WeightedRandom.ChooseOrDefault();
        Item? oPtr = Game.GetInventoryItem(i);

        // The chosen slot does not have an item to disenchant.
        if (oPtr == null)
        {
            return IdentifiedResult.False;
        }
        if (oPtr.EnchantmentItemProperties.BonusHit <= 0 && oPtr.EnchantmentItemProperties.BonusDamage <= 0 && oPtr.EnchantmentItemProperties.BonusArmorClass <= 0)
        {
            return IdentifiedResult.False;
        }
        string oName = oPtr.GetDescription(false);
        string s;
        if (oPtr.IsArtifact && Game.RandomLessThan(100) < 71)
        {
            s = oPtr.StackCount != 1 ? "" : "s";
            Game.MsgPrint($"Your {oName} ({inventorySlot.Label(oPtr)}) resist{s} disenchantment!");
            return IdentifiedResult.True;
        }
        if (oPtr.EnchantmentItemProperties.BonusHit > 0)
        {
            oPtr.EnchantmentItemProperties.BonusHit--;
        }
        if (oPtr.EnchantmentItemProperties.BonusHit > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EnchantmentItemProperties.BonusHit--;
        }
        if (oPtr.EnchantmentItemProperties.BonusDamage > 0)
        {
            oPtr.EnchantmentItemProperties.BonusDamage--;
        }
        if (oPtr.EnchantmentItemProperties.BonusDamage > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EnchantmentItemProperties.BonusDamage--;
        }
        if (oPtr.EnchantmentItemProperties.BonusArmorClass > 0)
        {
            oPtr.EnchantmentItemProperties.BonusArmorClass--;
        }
        if (oPtr.EnchantmentItemProperties.BonusArmorClass > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EnchantmentItemProperties.BonusArmorClass--;
        }
        s = oPtr.StackCount != 1 ? "were" : "was";
        Game.MsgPrint($"Your {oName} ({inventorySlot.Label(oPtr)}) {s} disenchanted!");
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        return IdentifiedResult.True;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }
}
