namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StrengthRingItem : RingItem
    {
        public StrengthRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingStrength>()) { }
    }
}