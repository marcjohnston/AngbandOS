namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CeleanoFragmentTarotBookItem : TarotBookItem
    {
        public CeleanoFragmentTarotBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<TarotBookCeleanoFragments>()) { }

        /// <summary>
        /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
        /// </summary>
        public override int ExperienceGainDivisorForDestroying => 1;
    }
}