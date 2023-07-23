// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class AmmunitionItem : Item
{
    public AmmunitionItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override bool IdentityCanBeSensed => true;
    public override int? GetBonusRealValue(int value)
    {
        if (BonusToHit + BonusDamage < 0)
            return null;

        int bonusValue = (BonusToHit + BonusDamage) * 5;
        if (DamageDice > Factory.Dd && DamageDiceSides == Factory.Ds)
        {
            bonusValue += (DamageDice - Factory.Dd) * DamageDiceSides * 5;
        }
        return bonusValue;
    }

    protected override void ApplyMagic(int level, int power, Store? store)
    {
        base.ApplyMagic(level, power, null);
        if (power > 1)
        {
            switch (SaveGame.Rng.DieRoll(12))
            {
                case 1:
                case 2:
                case 3:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfWounding;
                    break;
                case 4:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfFlame;
                    break;
                case 5:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfFrost;
                    break;
                case 6:
                case 7:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtAnimal;
                    break;
                case 8:
                case 9:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtEvil;
                    break;
                case 10:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfHurtDragon;
                    break;
                case 11:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfShocking;
                    break;
                case 12:
                    RareItemTypeIndex = RareItemTypeEnum.AmmoOfSlaying;
                    DamageDice++;
                    break;
            }
            while (SaveGame.Rng.RandomLessThan(10 * DamageDice * DamageDiceSides) == 0)
            {
                DamageDice++;
            }
            if (DamageDice > 9)
            {
                DamageDice = 9;
            }
        }
        else if (power < -1)
        {
            if (SaveGame.Rng.RandomLessThan(Constants.MaxDepth) < level)
            {
                RareItemTypeIndex = RareItemTypeEnum.AmmoOfBackbiting;
            }
        }
    }
    public override int? GetTypeSpecificRealValue(int value)
    {
        return ComputeTypeSpecificRealValue(value);
    }
}