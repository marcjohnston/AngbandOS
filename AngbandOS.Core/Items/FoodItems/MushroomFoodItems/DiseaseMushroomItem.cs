namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DiseaseMushroomItem : MushroomItem
    {
        public DiseaseMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomDisease>()) { }
    }
}