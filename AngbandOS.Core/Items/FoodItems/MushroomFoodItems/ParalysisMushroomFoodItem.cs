namespace AngbandOS.Core.Items;

[Serializable]
internal class ParalysisMushroomFoodItem : MushroomFoodItem
{
    public ParalysisMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<ParalysisMushroomFoodItemFactory>()) { }
}