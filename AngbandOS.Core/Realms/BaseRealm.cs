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
    }
}
