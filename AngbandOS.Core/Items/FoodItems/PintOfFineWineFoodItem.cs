namespace AngbandOS.Core.Items;

[Serializable]
internal class PintOfFineWineFoodItem : FoodItem
{
    public PintOfFineWineFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PintOfFineWineFoodItemFactory>()) { }
}