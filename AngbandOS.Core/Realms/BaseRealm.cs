namespace AngbandOS.Core.Realms
{
    [Serializable]
    internal abstract class BaseRealm
    {
        protected SaveGame SavedGame { get; }
        protected BaseRealm(SaveGame savedGame)
        {
            SavedGame = savedGame;
        }

        /// <summary>
        /// Returns the deprecated Realm enumeration for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract Realm ID { get; }

        public abstract string[] Info { get; }

        public abstract string Name { get; }

        /// <summary>
        /// Returns the spell book item category that represents the realm.
        /// </summary>
        /// <param name="realm"> The realm of magic </param>
        /// <returns> The spell book item category </returns>
        public abstract ItemTypeEnum SpellBookItemCategory { get; }

    }
}
