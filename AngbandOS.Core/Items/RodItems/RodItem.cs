namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RodItem : Item
    {
        public RodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}