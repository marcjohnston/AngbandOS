namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HelmItemClass : ArmourItemClass
    {
        public HelmItemClass(SaveGame saveGame) : base(saveGame) { }
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<HeadInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Helm;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(14))
            {
                case 1:
                case 2:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfIntelligence;
                    break;
                case 3:
                case 4:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfWisdom;
                    break;
                case 5:
                case 6:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfBeauty;
                    break;
                case 7:
                case 8:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfSeeing;
                    if (Program.Rng.DieRoll(7) == 1)
                    {
                        item.RandartItemCharacteristics.Telepathy = true;
                    }
                    break;
                case 9:
                case 10:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfLight;
                    break;
                case 11:
                case 12:
                case 13:
                case 14:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfInfravision;
                    break;
            }
        }

        protected override void ApplyRandomPoorRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(7))
            {
                case 1:
                case 2:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfStupidity;
                    break;
                case 3:
                case 4:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfNaivety;
                    break;
                case 5:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfUgliness;
                    break;
                case 6:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfSickliness;
                    break;
                case 7:
                    item.RareItemTypeIndex = RareItemTypeEnum.HatOfTeleportation;
                    break;
            }
        }

        /// <summary>
        /// Applies standard magic to helms.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(item, level, power);

                if (power > 1)
                {
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        item.CreateRandart(false);
                    }
                    else
                    {
                        ApplyRandomGoodRareCharacteristics(item);
                    }
                }
                else if (power < -1)
                {
                    ApplyRandomPoorRareCharacteristics(item);
                }
            }
        }

        public override bool CanReflectBoltsAndArrows => true;
        public override int PackSort => 25;
    }
}
