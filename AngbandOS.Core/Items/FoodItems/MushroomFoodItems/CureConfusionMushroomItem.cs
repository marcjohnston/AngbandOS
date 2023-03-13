namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CureConfusionMushroomItem : MushroomItem
    {
        public CureConfusionMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomCureConfusion>()) { }
    }
}