namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class WandItem : Item
    {
        public WandItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}