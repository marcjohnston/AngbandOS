// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ApplyDisenchantScript : EatOrQuaffUniversalScript, IGetKey
{
    private ApplyDisenchantScript(Game game) : base(game) {  }

    public virtual string Key => GetType().Name;
    public string GetKey => Key;
    public virtual void Bind() { }

    /// <summary>
    /// Executes the script and returns a success result.
    /// </summary>
    /// <returns></returns>
    public override IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // Select an inventory slot where items can be disenchanted.
        WieldSlot? inventorySlot = Game.SingletonRepository.ToWeightedRandom<WieldSlot>(_inventorySlot => _inventorySlot.CanBeDisenchanted).ChooseOrDefault();
        if (inventorySlot == null)
        {
            // There are no inventory slots capable of being disenchanted.
            return IdentifiedResultEnum.False;
        }

        // Select an item in the inventory slot to be disenchanted.
        int i = inventorySlot.WeightedRandom.ChooseOrDefault();
        Item? oPtr = Game.GetInventoryItem(i);

        // The chosen slot does not have an item to disenchant.
        if (oPtr == null)
        {
            return IdentifiedResultEnum.False;
        }
        if (oPtr.EffectivePropertySet.MeleeToHit <= 0 && oPtr.EffectivePropertySet.ToDamage <= 0 && oPtr.EffectivePropertySet.BonusArmorClass <= 0)
        {
            return IdentifiedResultEnum.False;
        }
        string oName = oPtr.GetDescription(false);
        string s;
        if (oPtr.IsArtifact && Game.RandomLessThan(100) < 71)
        {
            s = oPtr.StackCount != 1 ? "" : "s";
            Game.MsgPrint($"Your {oName} ({inventorySlot.Label(oPtr)}) resist{s} disenchantment!");
            return IdentifiedResultEnum.True;
        }
        if (oPtr.EffectivePropertySet.MeleeToHit > 0)
        {
            oPtr.EffectivePropertySet.MeleeToHit--;
        }
        if (oPtr.EffectivePropertySet.MeleeToHit > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EffectivePropertySet.MeleeToHit--;
        }
        if (oPtr.EffectivePropertySet.ToDamage > 0)
        {
            oPtr.EffectivePropertySet.ToDamage--;
        }
        if (oPtr.EffectivePropertySet.ToDamage > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EffectivePropertySet.ToDamage--;
        }
        if (oPtr.EffectivePropertySet.BonusArmorClass > 0)
        {
            oPtr.EffectivePropertySet.BonusArmorClass--;
        }
        if (oPtr.EffectivePropertySet.BonusArmorClass > 5 && Game.RandomLessThan(100) < 20)
        {
            oPtr.EffectivePropertySet.BonusArmorClass--;
        }
        s = oPtr.StackCount != 1 ? "were" : "was";
        Game.MsgPrint($"Your {oName} ({inventorySlot.Label(oPtr)}) {s} disenchanted!");
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        return IdentifiedResultEnum.True;
    }
}
