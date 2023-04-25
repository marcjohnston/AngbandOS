namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class MushroomFoodItem : FoodItem
    {
        public MushroomFoodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}