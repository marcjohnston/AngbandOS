namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class PotionItem : Item
    {
        public PotionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}