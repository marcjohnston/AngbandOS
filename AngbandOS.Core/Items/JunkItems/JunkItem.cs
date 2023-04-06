namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class JunkItem : Item
    {
        public JunkItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 38;
    }
}