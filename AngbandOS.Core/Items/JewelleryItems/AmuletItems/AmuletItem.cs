namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class AmuletItem : JewelleryItem
    {
        public AmuletItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}