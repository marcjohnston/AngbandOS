namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AcidRingItem : RingItem
    {
        public AcidRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingAcid>()) { }
    }
}