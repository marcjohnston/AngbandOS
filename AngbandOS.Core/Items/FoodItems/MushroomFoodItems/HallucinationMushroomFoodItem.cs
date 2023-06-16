namespace AngbandOS.Core.Items;

[Serializable]
internal class HallucinationMushroomFoodItem : MushroomFoodItem
{
    public HallucinationMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<HallucinationMushroomFoodItemFactory>()) { }
}