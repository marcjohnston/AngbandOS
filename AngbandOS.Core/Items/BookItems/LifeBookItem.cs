namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LifeBookItem : BookItem
    {
        public LifeBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 8;
    }
}