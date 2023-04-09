namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        public BookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}