namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoringMushroomItem : MushroomItem
    {
        public RestoringMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomRestoring>()) { }
    }
}