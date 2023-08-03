// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class ArmourItem : Item
{
    public ArmourItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override bool IdentityCanBeSensed => true;
    public override int? GetBonusRealValue(int value)
    {
        if (BonusArmorClass < 0)
            return null;

        return (BonusToHit + BonusDamage + BonusArmorClass) * 100;
    }

    protected void ApplyDragonscaleResistance()
    {
        do
        {
            if (SaveGame.Rng.DieRoll(4) == 1)
            {
                IArtifactBias artifactBias = null;
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(14) + 4);
            }
            else
            {
                IArtifactBias artifactBias = null;
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
            }
        } while (SaveGame.Rng.DieRoll(2) == 1);
    }

    /// <summary>
    /// Applies a good random rare characteristics to an item of armour.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomGoodRareCharacteristics()
    {
        switch (SaveGame.Rng.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfResistAcid;
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfResistLightning;
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfResistFire;
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfResistCold;
                break;
            case 17:
            case 18:
                IArtifactBias artifactBias = null;
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfResistance;
                if (SaveGame.Rng.DieRoll(4) == 1)
                {
                    RandartItemCharacteristics.ResPois = true;
                }
                ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
                break;
            case 19:
                CreateRandart(false);
                break;
            case 20:
            case 21:
                RareItemTypeIndex = RareItemTypeEnum.ArmourOfYith;
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to an item of armour.  Does nothing by default.  Various derived class may override
    /// this method and apply a random poor characteristic to the item.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomPoorRareCharacteristics()
    {
    }

    /// <summary>
    /// Applies a standard BonusArmourClass and IdentCursed to armour class items.  Derived items must call this base to have these
    /// standard characteristics applied, when needed.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        int toac1 = SaveGame.Rng.DieRoll(5) + GetBonusValue(5, level);
        int toac2 = GetBonusValue(10, level);
        if (power > 0)
        {
            BonusArmorClass += toac1;
            if (power > 1)
            {
                BonusArmorClass += toac2;
            }
        }
        else if (power < 0)
        {
            BonusArmorClass -= toac1;
            if (power < -1)
            {
                BonusArmorClass -= toac2;
            }
            if (BonusArmorClass < 0)
            {
                IdentCursed = true;
            }
        }
    }

    public override void ApplyRandartBonus()
    {
        BonusArmorClass += SaveGame.Rng.DieRoll(BonusArmorClass > 19 ? 1 : 20 - BonusArmorClass);
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
        if (IsKnown())
        {
            RefreshFlagBasedProperties();
            if (Factory.ShowMods || BonusToHit != 0 && BonusDamage != 0)
            {
                s += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";
            }
            else if (BonusToHit != 0)
            {
                s += $" ({GetSignedValue(BonusToHit)})";
            }
            else if (BonusDamage != 0)
            {
                s += $" ({GetSignedValue(BonusDamage)})";
            }

            // Add base armour class for all types of armour and when the base armour class is greater than zero.
            s += $" [{BaseArmorClass},{GetSignedValue(BonusArmorClass)}]";
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
        if (BonusArmorClass < 0)
        {
            return true;
        }
        return false;
    }
}