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
    public AmmunitionItemFactory(Game game) : base(game) { }

    public override int GetBonusRealValue(Item item)
    {
        int bonusValue = (item.BonusHit + item.BonusDamage) * 5;
        if (item.DamageDice > DamageDice && item.DamageSides == DamageSides)
        {
            bonusValue += (item.DamageDice - DamageDice) * item.DamageSides * 5;
        }
        return bonusValue;
    }

    /// <summary>
    /// Ammunition items return a maximum number of 20 items that can be enchanted at one time.
    /// </summary>
    public override int EnchantmentMaximumCount => 20;

    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        base.EnchantItem(item, usedOkay, level, power);
        if (power > 1)
        {
            switch (Game.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfWoundingRareItem));
                    break;
                case 4:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfFlameRareItem));
                    break;
                case 5:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfFrostRareItem));
                    break;
                case 6:
                case 7:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfHurtAnimalRareItem));
                    break;
                case 8:
                case 9:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfHurtEvilRareItem));
                    break;
                case 10:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfHurtDragonRareItem));
                    break;
                case 11:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfShockingRareItem));
                    break;
                case 12:
                    item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfSlayingRareItem));
                    item.DamageDice++;
                    break;
            }
            while (Game.RandomLessThan(10 * item.DamageDice * item.DamageSides) == 0)
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
            if (Game.RandomLessThan(Constants.MaxDepth) < level)
            {
                item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(AmmoOfBackbitingRareItem));
            }
        }
    }
}
