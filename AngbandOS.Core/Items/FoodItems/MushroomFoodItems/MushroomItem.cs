namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class MushroomItem : FoodItem
    {
        public MushroomItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    }
}