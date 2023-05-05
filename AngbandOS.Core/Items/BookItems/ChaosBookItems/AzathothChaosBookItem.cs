namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AzathothChaosBookItem : ChaosBookItem
    {
        public AzathothChaosBookItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AzathothChaosBookItemFactory>()) { }

        /// <summary>
        /// Returns a divisor of 1 because this is the most powerful book for this realm of magic.  Destroying this book provides the most experience.
        /// </summary>
        public override int ExperienceGainDivisorForDestroying => 1;
    }
}