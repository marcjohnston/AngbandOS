namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LifeBookItem : BookItem
    {
        public LifeBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Life";
    }
}