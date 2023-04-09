namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        public BookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}