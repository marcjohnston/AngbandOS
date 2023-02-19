namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class HardArmorItemClass : ArmourItemClass
    {
        public HardArmorItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.Body;
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<BodyInventorySlot>();
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.HardArmor;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Grey;

        /// <summary>
        /// Applies standard magic to hard armour.
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

        public override bool CanProvideSheathOfElectricity => true;

        public override bool CanProvideSheathOfFire => true;

        public override bool CanReflectBoltsAndArrows => true;
        public override int PackSort => 20;
    }
}
