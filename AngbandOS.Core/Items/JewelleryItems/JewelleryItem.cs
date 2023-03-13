namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class JewelleryItem : Item
    {
        public JewelleryItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}