namespace AngbandOS.Core.Items;

[Serializable]
internal class CureConfusionMushroomFoodItem : MushroomFoodItem
{
    public CureConfusionMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CureConfusionMushroomFoodItemFactory>()) { }
}