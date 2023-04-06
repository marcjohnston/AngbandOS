namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class MushroomItem : FoodItem
    {
        public MushroomItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}