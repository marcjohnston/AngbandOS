namespace AngbandOS.Core.Items;

[Serializable]
internal class CureSeriousWoundsMushroomFoodItem : MushroomFoodItem
{
    public CureSeriousWoundsMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CureSeriousWoundsMushroomFoodItemFactory>()) { }
}