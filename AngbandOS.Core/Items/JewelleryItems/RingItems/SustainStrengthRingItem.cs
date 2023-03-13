namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SustainStrengthRingItem : RingItem
    {
        public SustainStrengthRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingSustainStrength>()) { }
    }
}