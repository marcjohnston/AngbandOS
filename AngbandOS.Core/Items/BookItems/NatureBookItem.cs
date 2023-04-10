namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class NatureBookItem : BookItem
    {
        public NatureBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Nature";
    }
}