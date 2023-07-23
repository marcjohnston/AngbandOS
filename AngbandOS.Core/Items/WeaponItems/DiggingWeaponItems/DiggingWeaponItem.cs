// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class DiggingWeaponItem : WeaponItem
{
    public override int WieldSlot => InventorySlot.Digger;
    public DiggingWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        base.ApplyMagic(level, power, null);
        if (power > 1)
        {
            RareItemTypeIndex = RareItemTypeEnum.WeaponOfDigging;
        }
        else if (power < -1)
        {
            TypeSpecificValue = 0 - (5 + SaveGame.Rng.DieRoll(5));
        }
        else if (power < 0)
        {
            TypeSpecificValue = 0 - TypeSpecificValue;
        }
    }
}