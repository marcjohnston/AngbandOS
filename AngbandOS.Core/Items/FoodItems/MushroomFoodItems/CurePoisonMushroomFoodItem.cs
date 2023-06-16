namespace AngbandOS.Core.Items;

[Serializable]
internal class CurePoisonMushroomFoodItem : MushroomFoodItem
{
    public CurePoisonMushroomFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CurePoisonMushroomFoodItemFactory>()) { }
}