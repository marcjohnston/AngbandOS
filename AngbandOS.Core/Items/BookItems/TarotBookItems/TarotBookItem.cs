namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class TarotBookItem : BookItem
    {
        public TarotBookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override string RealmName => "Tarot";
    }
}