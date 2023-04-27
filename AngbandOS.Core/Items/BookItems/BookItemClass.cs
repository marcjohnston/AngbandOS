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

        public abstract BaseRealm? ToRealm { get; }
    }
}
