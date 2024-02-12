// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class AmmunitionItemFactory : WeaponItemFactory
{
    public AmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

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
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfWoundingRareItem));
                    break;
                case 4:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfFlameRareItem));
                    break;
                case 5:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfFrostRareItem));
                    break;
                case 6:
                case 7:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfHurtAnimalRareItem));
                    break;
                case 8:
                case 9:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfHurtEvilRareItem));
                    break;
                case 10:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfHurtDragonRareItem));
                    break;
                case 11:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfShockingRareItem));
                    break;
                case 12:
                    item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfSlayingRareItem));
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
                item.RareItem = SaveGame.SingletonRepository.RareItems.Get(nameof(AmmoOfBackbitingRareItem));
            }
        }
    }

    public override int MakeObjectCount => SaveGame.Rng.DiceRoll(6, 7);
    public override int PercentageBreakageChance => 25;

    public override bool IsWeapon => true;
    public override bool CanBeFired => true;
    public override bool IdentityCanBeSensed => true;
    public override bool GetsDamageMultiplier => true;
}
