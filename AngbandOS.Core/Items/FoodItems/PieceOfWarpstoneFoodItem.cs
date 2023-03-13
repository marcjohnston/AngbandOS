namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PieceOfWarpstoneFoodItem : FoodItem
    {
        public PieceOfWarpstoneFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodPieceOfWarpstone>()) { }
    }
}