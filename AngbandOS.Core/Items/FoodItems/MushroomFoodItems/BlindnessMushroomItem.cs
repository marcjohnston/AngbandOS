namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BlindnessMushroomItem : MushroomItem
    {
        public BlindnessMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomBlindness>()) { }
    }
}