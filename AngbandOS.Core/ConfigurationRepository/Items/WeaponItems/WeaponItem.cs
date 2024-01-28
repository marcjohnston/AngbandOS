// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class WeaponItem : Item
{
    public WeaponItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (RareItemTypeIndex != 0)
        {
            return 0;
        }
        if (cost <= 10)
        {
            return MassRoll(3, 5);
        }
        if (cost <= 100)
        {
            return MassRoll(3, 5);
        }
        return 0;
    }

    public override string GetDetailedDescription()
    {
        string s = "";
        s += $" ({DamageDice}d{DamageDiceSides})";
        if (IsKnown())
        {
            s += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";

            if (BaseArmorClass != 0)
            {
                // Add base armor class for all types of armor and when the base armor class is greater than zero.
                s += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
            }
            else if (BonusArmorClass != 0)
            {
                // This is not armor, only show bonus armor class, if it is not zero and we know about it.
                s += $" [{GetSignedValue(BonusArmorClass)}]";
            }
        }
        else if (BaseArmorClass != 0)
        {
            s += $" [{BaseArmorClass}]";
        }
        return s;
    }
}