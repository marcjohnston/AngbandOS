namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal abstract class BaseCharacterClass
    {
        protected SaveGame SavedGame { get; }
        protected BaseCharacterClass(SaveGame savedGame)
        {
            SavedGame = savedGame;
        }

        /// <summary>
        /// Returns the deprecated CharacterClass constant for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract int ID { get; }
    }
}
