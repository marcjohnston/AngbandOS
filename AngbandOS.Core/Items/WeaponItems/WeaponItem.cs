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
    public override bool CanApplyBlowsBonus => true;
    public override bool CanApplyBonusArmorClassMiscPower => true;
    public override int? GetBonusRealValue(int value)
    {
        if (BonusToHit + BonusDamage < 0)
            return null;

        int bonusValue = 0;
        bonusValue += (BonusToHit + BonusDamage + BonusArmorClass) * 100;
        if (DamageDice > Factory.Dd && DamageDiceSides == Factory.Ds)
        {
            bonusValue += (DamageDice - Factory.Dd) * DamageDiceSides * 100;
        }
        return bonusValue;
    }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        if (power == 0)
        {
            return;
        }

        int tohit1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        int todam1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        int tohit2 = GetBonusValue(10, level);
        int todam2 = GetBonusValue(10, level);
        if (power > 0)
        {
            BonusToHit += tohit1;
            BonusDamage += todam1;
            if (power > 1)
            {
                BonusToHit += tohit2;
                BonusDamage += todam2;
            }
        }
        else if (power < 0)
        {
            BonusToHit -= tohit1;
            BonusDamage -= todam1;
            if (power < -1)
            {
                BonusToHit -= tohit2;
                BonusDamage -= todam2;
            }
            if (BonusToHit + BonusDamage < 0)
            {
                IdentCursed = true;
            }
        }
    }

    public override void ApplyRandartBonus()
    {
        BonusToHit += Program.Rng.DieRoll(BonusToHit > 19 ? 1 : 20 - BonusToHit);
        BonusDamage += Program.Rng.DieRoll(BonusDamage > 19 ? 1 : 20 - BonusDamage);
    }

    protected override bool FactoryCanAbsorbItem(Item other)
    {
        if (!IsKnown() || !other.IsKnown())
        {
            return false;
        }
        if (!StatsAreSame(other))
        {
            return false;
        }
        return true;
    }

    public override int? GetTypeSpecificRealValue(int value)
    {
        return ComputeTypeSpecificRealValue(value);
    }
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
                // Add base armour class for all types of armour and when the base armour class is greater than zero.
                s += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
            }
            else if (BonusArmorClass != 0)
            {
                // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                s += $" [{GetSignedValue(BonusArmorClass)}]";
            }
        }
        else if (BaseArmorClass != 0)
        {
            s += $" [{BaseArmorClass}]";
        }
        return s;
    }

    public override bool IsWorthless()
    {
        if (TypeSpecificValue < 0)
        {
            return true;
        }
        if (BonusToHit + BonusDamage < 0)
        {
            return true;
        }
        return false;
    }
}