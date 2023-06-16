namespace AngbandOS.Core.Items;

[Serializable]
internal class RestoringMushroomFoodItem : MushroomFoodItem
{
    public RestoringMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RestoringMushroomFoodItemFactory>()) { }
}