namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class DeathBookItem : BookItem
    {
        public DeathBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Death";
    }
}