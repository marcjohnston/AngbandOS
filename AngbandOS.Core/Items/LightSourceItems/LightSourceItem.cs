namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LightSourceItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Lightsource;
        public LightSourceItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 18;

        public override int PercentageBreakageChance => 50;

        /// <summary>
        /// Returns an intensity of 3, if the item is an artifact; otherwise, 0 is returned.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch()
        {
            if (FixedArtifact != null)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
    }
}