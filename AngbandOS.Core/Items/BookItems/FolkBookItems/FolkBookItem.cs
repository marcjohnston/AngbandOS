namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FolkBookItem : BookItem
    {
        public FolkBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Folk";
    }
}