namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DragArmorItem : ArmourItem
    {
        public DragArmorItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int WieldSlot => InventorySlot.Body;
        public override int PackSort => 19;

        /// <summary>
        /// Applies special magic to dragon armour.
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

                if (SaveGame.Level != null)
                {
                    SaveGame.Level.TreasureRating += 30;
                }
            }
        }
    }
}