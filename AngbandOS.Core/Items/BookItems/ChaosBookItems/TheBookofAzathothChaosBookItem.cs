namespace AngbandOS.Core.Items
{
[Serializable]
    internal class TheBookofAzathothChaosBookItem : ChaosBookItem
    {
        public TheBookofAzathothChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ChaosBookTheBookofAzathoth>()) { }

        /// <summary>
        /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
        /// </summary>
        public override int ExperienceGainDivisorForDestroying => 1;
    }
}