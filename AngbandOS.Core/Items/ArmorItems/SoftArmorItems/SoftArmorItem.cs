namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SoftArmorItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Body;
        public SoftArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

        /// <summary>
        /// Applies standard magic to soft armour.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public override void ApplyMagic(int level, int power)
        {
            if (power != 0)
            {
                // Apply the standard armour characteristics.
                base.ApplyMagic(level, power);

                if (power > 1)
                {
                    ApplyRandomGoodRareCharacteristics();
                }
            }
        }
    }
}