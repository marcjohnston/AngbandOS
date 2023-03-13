namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PieceOfDwarfBreadFoodItem : FoodItem
    {
        public PieceOfDwarfBreadFoodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<FoodPieceOfDwarfBread>()) { }
    }
}