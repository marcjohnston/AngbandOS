namespace AngbandOS.Core.Items;

[Serializable]
internal class NaivetyMushroomFoodItem : MushroomFoodItem
{
    public NaivetyMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<NaivetyMushroomFoodItemFactory>()) { }
}