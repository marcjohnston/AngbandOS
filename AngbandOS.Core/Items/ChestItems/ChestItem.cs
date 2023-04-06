namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ChestItem : Item
    {
        public ChestItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 36;
    }
}