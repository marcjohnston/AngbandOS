// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class BowWeaponItem : WeaponItem
{
    /// <summary>
    /// Returns the factory that created this bow weapon item.
    /// </summary>
    public override BowWeaponItemFactory Factory => (BowWeaponItemFactory)base.Factory;

    public BowWeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    public override string GetDetailedDescription()
    {
        string basenm = "";
        RefreshFlagBasedProperties();
        int power = Factory.MissileDamageMultiplier;
        if (Factory.XtraMight)
        {
            power++;
        }
        basenm += $" (x{power})";
        if (IsKnown())
        {
            basenm += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";

            if (BaseArmorClass != 0)
            {
                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                basenm += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
            }
            else if (BonusArmorClass != 0)
            {
                // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                basenm += $" [{GetSignedValue(BonusArmorClass)}]";
            }
        }
        else if (BaseArmorClass != 0)
        {
            basenm += $" [{BaseArmorClass}]";
        }
        return basenm;
    }
}