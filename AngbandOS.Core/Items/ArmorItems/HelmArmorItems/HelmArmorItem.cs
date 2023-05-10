namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HelmArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Head;
        public HelmArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }


        protected override void ApplyRandomGoodRareCharacteristics()
        {
            switch (Program.Rng.DieRoll(14))
            {
                case 1:
                case 2:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfIntelligence;
                    break;
                case 3:
                case 4:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfWisdom;
                    break;
                case 5:
                case 6:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfBeauty;
                    break;
                case 7:
                case 8:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfSeeing;
                    if (Program.Rng.DieRoll(7) == 1)
                    {
                        RandartItemCharacteristics.Telepathy = true;
                    }
                    break;
                case 9:
                case 10:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfLight;
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfInfravision;
                    break;
            }
        }


        protected override void ApplyRandomPoorRareCharacteristics()
        {
            switch (Program.Rng.DieRoll(7))
            {
                case 1:
                case 2:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfStupidity;
                    break;
                case 3:
                case 4:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfNaivety;
                    break;
                case 5:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfUgliness;
                    break;
                case 6:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfSickliness;
                    break;
                case 7:
                    RareItemTypeIndex = RareItemTypeEnum.HatOfTeleportation;
                    break;
            }
        }

        /// <summary>
        /// Applies standard magic to helms.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        protected override void ApplyMagic(int level, int power, Store? store)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(level, power, null);

                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        CreateRandart(false);
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics();
                    }
                }
                else if (power < -1)
                {
                    ApplyRandomPoorRareCharacteristics();
                }
            }
        }
    }
}