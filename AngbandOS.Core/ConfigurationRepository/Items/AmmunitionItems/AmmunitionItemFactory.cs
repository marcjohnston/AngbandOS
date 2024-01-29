// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class AmmunitionItemFactory : WeaponItemFactory
{
    public AmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        int cost = item.Value();
        if (cost <= 5)
        {
            return item.MassRoll(5, 5);
        }
        if (cost <= 50)
        {
            return item.MassRoll(5, 5);
        }
        if (cost <= 500)
        {
            return item.MassRoll(5, 5);
        }
        return 0;
    }
    public override int? GetTypeSpecificRealValue(Item item, int value)
    {
        return item.ComputeTypeSpecificRealValue(value);
    }
    public override int? GetBonusRealValue(Item item, int value)
    {
        if (item.BonusToHit + item.BonusDamage < 0)
            return null;

        int bonusValue = (item.BonusToHit + item.BonusDamage) * 5;
        if (item.DamageDice > Dd && item.DamageDiceSides == Ds)
        {
            bonusValue += (item.DamageDice - Dd) * item.DamageDiceSides * 5;
        }
        return bonusValue;
    }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        base.ApplyMagic(item, level, power, null);
        if (power > 1)
        {
            switch (SaveGame.Rng.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfWounding;
                    break;
                case 4:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfFlame;
                    break;
                case 5:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfFrost;
                    break;
                case 6:
                case 7:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtAnimal;
                    break;
                case 8:
                case 9:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtEvil;
                    break;
                case 10:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtDragon;
                    break;
                case 11:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfShocking;
                    break;
                case 12:
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfSlaying;
                    item.DamageDice++;
                    break;
            }
            while (SaveGame.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
            {
                item.DamageDice++;
            }
            if (item.DamageDice > 9)
            {
                item.DamageDice = 9;
            }
        }
        else if (power < -1)
        {
            if (SaveGame.Rng.RandomLessThan(Constants.MaxDepth) < level)
            {
                item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfBackbiting;
            }
        }
    }

    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        if (!base.ItemsCanBeMerged(a, b))
        {
            return false;
        }
        if (!StatsAreSame(a, b))
        {
            return false;
        }
        return true;
    }
    public override int MakeObjectCount => SaveGame.Rng.DiceRoll(6, 7);
    public override int PercentageBreakageChance => 25;

    public override bool IsWeapon => true;
    public override bool CanBeFired => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;
}
