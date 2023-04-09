namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class AmmunitionItemClass : WeaponItemClass
    {
        public AmmunitionItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

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
                    item.RareItemTypeIndex = RareItemTypeEnum.AmmoOfBackbiting;
                }
            }
        }

    }
}
