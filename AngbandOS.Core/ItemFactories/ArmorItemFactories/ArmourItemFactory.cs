﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
/// <summary>
/// Represents armor items.  Boots, cloaks, crowns, dragon armor, gloves, hard armor, helm, shield and soft armor are all armor classes.
/// </summary>
internal abstract class ArmorItemFactory : ItemFactory
{
    public ArmorItemFactory(Game game) : base(game) { }

    public override int? GetTypeSpecificRealValue(Item item, int value)
    {
        return item.ComputeTypeSpecificRealValue(value);
    }

    public override string GetDetailedDescription(Item item)
    {
        string s = "";
        if (item.IsKnown())
        {
            item.RefreshFlagBasedProperties();
            if (ShowMods || item.BonusToHit != 0 && item.BonusDamage != 0)
            {
                s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
            }
            else if (item.BonusToHit != 0)
            {
                s += $" ({GetSignedValue(item.BonusToHit)})";
            }
            else if (item.BonusDamage != 0)
            {
                s += $" ({GetSignedValue(item.BonusDamage)})";
            }

            // Add base armor class for all types of armor and when the base armor class is greater than zero.
            s += $" [{item.BaseArmorClass},{GetSignedValue(item.BonusArmorClass)}]";
        }
        else if (item.BaseArmorClass != 0)
        {
            s += $" [{item.BaseArmorClass}]";
        }
        return s;
    }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 10)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 100)
        {
            return item.MassRoll(3, 5);
        }
        return 0;
    }

    public override void ApplyRandartBonus(Item item)
    {
        item.BonusArmorClass += Game.DieRoll(item.BonusArmorClass > 19 ? 1 : 20 - item.BonusArmorClass);
    }

    public override int? GetBonusRealValue(Item item, int value)
    {
        if (item.BonusArmorClass < 0)
            return null;

        return (item.BonusToHit + item.BonusDamage + item.BonusArmorClass) * 100;
    }

    public override bool IsWorthless(Item item)
    {
        if (item.TypeSpecificValue < 0)
        {
            return true;
        }
        if (item.BonusArmorClass < 0)
        {
            return true;
        }
        return false;
    }

    public void ApplyDragonscaleResistance(Item item)
    {
        do
        {
            if (Game.DieRoll(4) == 1)
            {
                IArtifactBias artifactBias = null;
                item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(14) + 4);
            }
            else
            {
                IArtifactBias artifactBias = null;
                item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
            }
        } while (Game.DieRoll(2) == 1);
    }

    /// <summary>
    /// Applies a good random rare characteristics to an item of armor.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomGoodRareCharacteristics(Item item)
    {
        switch (Game.DieRoll(21))
        {
            case 1:
            case 2:
            case 3:
            case 4:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfResistAcidRareItem));
                break;
            case 5:
            case 6:
            case 7:
            case 8:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfResistLightningRareItem));
                break;
            case 9:
            case 10:
            case 11:
            case 12:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfResistFireRareItem));
                break;
            case 13:
            case 14:
            case 15:
            case 16:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfResistColdRareItem));
                break;
            case 17:
            case 18:
                IArtifactBias artifactBias = null;
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfResistanceRareItem));
                if (Game.DieRoll(4) == 1)
                {
                    item.RandomArtifactItemCharacteristics.ResPois = true;
                }
                item.ApplyRandomResistance(ref artifactBias, Game.DieRoll(22) + 16);
                break;
            case 19:
                item.CreateRandomArtifact(false);
                break;
            case 20:
            case 21:
                item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(ArmorOfYithRareItem));
                break;
        }
    }

    /// <summary>
    /// Applies a poor random rare characteristics to an item of armor.  Does nothing by default.  Various derived class may override
    /// this method and apply a random poor characteristic to the item.
    /// </summary>
    /// <param name="item"></param>
    protected virtual void ApplyRandomPoorRareCharacteristics(Item item) { }

    /// <summary>
    /// Applies a standard BonusArmorClass and IdentCursed to armor class items.  Derived items must call this base to have these
    /// standard characteristics applied, when needed.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="level"></param>
    /// <param name="power"></param>
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        int toac1 = Game.DieRoll(5) + item.GetBonusValue(5, level);
        int toac2 = item.GetBonusValue(10, level);
        if (power > 0)
        {
            item.BonusArmorClass += toac1;
            if (power > 1)
            {
                item.BonusArmorClass += toac2;
            }
        }
        else if (power < 0)
        {
            item.BonusArmorClass -= toac1;
            if (power < -1)
            {
                item.BonusArmorClass -= toac2;
            }
            if (item.BonusArmorClass < 0)
            {
                item.IdentCursed = true;
            }
        }
    }

    public override bool HasQuality => true;
    public override bool IsArmor => true;
    public override bool IdentityCanBeSensed => true;
    public override bool IsWearable => true;
    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armor where the armor class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => ToA >= 0;
}