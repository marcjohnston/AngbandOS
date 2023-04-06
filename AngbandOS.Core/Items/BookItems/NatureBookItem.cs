namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class NatureBookItem : BookItem
    {
        public NatureBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 6;
    }
}