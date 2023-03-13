namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ConfusionMushroomItem : MushroomItem
    {
        public ConfusionMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomConfusion>()) { }
    }
}