namespace AngbandOS.Core.Items;

[Serializable]
internal class CureBlindnessMushroomFoodItem : MushroomFoodItem
{
    public CureBlindnessMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CureBlindnessMushroomFoodItemFactory>()) { }
}