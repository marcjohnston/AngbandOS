namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SicknessMushroomItem : MushroomItem
    {
        public SicknessMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomSickness>()) { }
    }
}