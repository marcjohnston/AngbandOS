namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureBlindnessMushroomItem : MushroomItem
    {
        public CureBlindnessMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomCureBlindness>()) { }
    }
}