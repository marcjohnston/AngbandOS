namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        /// <summary>
        /// Returns a divisor to be used to compute the amount of experience gained when an applicable character class destroys the book.  Defaults to 4.
        /// </summary>
        public virtual int ExperienceGainDivisorForDestroying => 4;

        public abstract string RealmName { get; }

        /// <summary>
        /// Returns the divine title for the book to be returned as the description.  The divine title defaults to the realm name with a "Magic" suffix.
        /// </summary>
        public virtual string DivineTitle => $"{RealmName} Magic";

        public override string GetDescription(bool includeCountPrefix)
        {
            string name = SaveGame.Player.BaseCharacterClass.SpellCastingType.GetBookTitle(this);
            name = $"{name} {Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }

        public override BookItemFactory Factory => (BookItemFactory)base.Factory;

        public BookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 50)
            {
                return MassRoll(2, 3) + 1;
            }
            if (cost <= 500)
            {
                return MassRoll(1, 3) + 1;
            }
            return 0;
        }

    }
}