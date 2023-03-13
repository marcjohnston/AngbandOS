namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BottleItem : Item
    {
        public BottleItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}