using AngbandOS.StaticData;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class AmmunitionItemCategory : WeaponItemCategory
    {
        public override void ApplyMagic(Item item, int level, int power)
        {
            base.ApplyMagic(item, level, power);
            if (power > 1)
            {
                switch (Program.Rng.DieRoll(12))
                {
                    case 1:
                    case 2:
                    case 3:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfWounding;
                        break;
                    case 4:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFlame;
                        break;
                    case 5:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFrost;
                        break;
                    case 6:
                    case 7:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtAnimal;
                        break;
                    case 8:
                    case 9:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtEvil;
                        break;
                    case 10:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtDragon;
                        break;
                    case 11:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfShocking;
                        break;
                    case 12:
                        item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfSlaying;
                        item.DamageDice++;
                        break;
                }
                while (Program.Rng.RandomLessThan(10 * item.DamageDice * item.DamageDiceSides) == 0)
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
                if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                {
                    item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfBackbiting;
                }
            }
        }

    }
}
