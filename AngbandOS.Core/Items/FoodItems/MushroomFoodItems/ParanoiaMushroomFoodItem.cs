namespace AngbandOS.Core.Items;

[Serializable]
internal class ParanoiaMushroomFoodItem : MushroomFoodItem
{
    public ParanoiaMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ParanoiaMushroomFoodItemFactory>()) { }
}