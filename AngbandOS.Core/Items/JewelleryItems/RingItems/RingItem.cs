namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RingItem : JewelleryItem
    {
        public RingItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}