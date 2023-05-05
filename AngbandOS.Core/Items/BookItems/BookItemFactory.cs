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
    }
}
