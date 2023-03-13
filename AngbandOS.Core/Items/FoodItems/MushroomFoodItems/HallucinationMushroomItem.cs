namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HallucinationMushroomItem : MushroomItem
    {
        public HallucinationMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomHallucination>()) { }
    }
}