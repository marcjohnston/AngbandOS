namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class ShieldItemClass : ArmourItemClass
    {
        public ShieldItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.Arm;
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<ArmInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Shield;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBrown;

        /// <summary>
        /// Applies a good random rare characteristics to a shield.
        /// </summary>
        /// <param name="item"></param>
        protected override void ApplyRandomGoodRareCharacteristics(Item item)
        {
            switch (Program.Rng.DieRoll(23))
            {
                case 1:
                case 11:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistAcid;
                    break;
                case 2:
                case 3:
                case 4:
                case 12:
                case 13:
                case 14:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistLightning;
                    break;
                case 5:
                case 6:
                case 15:
                case 16:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistFire;
                    break;
                case 7:
                case 8:
                case 9:
                case 17:
                case 18:
                case 19:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistCold;
                    break;
                case 10:
                case 20:
                    IArtifactBias artifactBias = null;
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                    if (Program.Rng.DieRoll(4) == 1)
                    {
                        item.RandartItemCharacteristics.ResPois = true;
                    }
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistance;
                    break;
                case 21:
                case 22:
                    item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfReflection;
                    break;
                case 23:
                    item.CreateRandart(false);
                    break;
            }
        }

        /// <summary>
        /// Applies standard magic to shields.
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
                    ApplyRandomGoodRareCharacteristics(item);
                }
            }
        }

        public override bool CanReflectBoltsAndArrows => true;
    }
}
