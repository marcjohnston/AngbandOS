namespace AngbandOS.Core.Items;

[Serializable]
internal class DiseaseMushroomFoodItem : MushroomFoodItem
{
    public DiseaseMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DiseaseMushroomFoodItemFactory>()) { }
}