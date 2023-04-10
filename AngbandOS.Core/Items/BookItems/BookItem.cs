namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        protected abstract string RealmName { get; }

        /// <summary>
        /// Returns the divine title for the book to be returned as the description.  The divine title defaults to the realm name with a "Magic" suffix.
        /// </summary>
        protected virtual string DivineTitle => $"{RealmName} Magic";

        public override string GetDescription(bool includeCountPrefix)
        {
            string name = SaveGame.Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? $"{Pluralize("Book", Count)} of {DivineTitle}" : $"{RealmName} {Pluralize("Spellbook", Count)}";
            name = $"{name} {Factory.FriendlyName}";
            return includeCountPrefix ? GetPrefixCount(true, name, Count, IsKnownArtifact) : name;
        }

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