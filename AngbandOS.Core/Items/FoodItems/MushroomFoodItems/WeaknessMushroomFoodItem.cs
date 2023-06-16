namespace AngbandOS.Core.Items;

[Serializable]
internal class WeaknessMushroomFoodItem : MushroomFoodItem
{
    public WeaknessMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WeaknessMushroomFoodItemFactory>()) { }
}