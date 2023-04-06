namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SorceryBookItem : BookItem
    {
        public SorceryBookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 7;
    }
}