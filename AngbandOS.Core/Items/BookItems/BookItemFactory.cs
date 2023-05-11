namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class BookItemFactory : ItemFactory
    {
        public BookItemFactory(SaveGame saveGame) : base(saveGame) { }
        /// <summary>
        /// Returns true for all books.
        /// </summary>
        public override bool EasyKnow => true;

        public abstract BaseRealm? ToRealm { get; }

        public abstract Spell[] Spells { get; }

        /// <summary>
        /// Returns true, if a book is a high level book; false, otherwise.  False is returned, by default.
        /// </summary>
        public virtual bool IsHighLevelBook => false;
    }
}
