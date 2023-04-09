namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        public BookItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }

        /// <summary>
        /// Returns true for all books.
        /// </summary>
        public override bool EasyKnow => true;

    }
}