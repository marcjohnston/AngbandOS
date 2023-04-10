namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BookItemClass : ItemFactory
    {
        public BookItemClass(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Returns true for all books.
        /// </summary>
        public override bool EasyKnow => true;

        public static bool IsBook(ItemFactory itemClass)
        {
            return typeof(BookItemClass).IsAssignableFrom(itemClass.GetType());
        }

        public abstract BaseRealm? ToRealm { get; }
    }
}
