namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PieceOfElvishWaybreadFoodItem : FoodItem
    {
        public PieceOfElvishWaybreadFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<PieceOfElvishWaybreadFoodItemFactory>()) { }
    }
}