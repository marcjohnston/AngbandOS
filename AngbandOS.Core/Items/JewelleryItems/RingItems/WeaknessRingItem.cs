namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WeaknessRingItem : RingItem
    {
        public WeaknessRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingWeakness>()) { }
    }
}