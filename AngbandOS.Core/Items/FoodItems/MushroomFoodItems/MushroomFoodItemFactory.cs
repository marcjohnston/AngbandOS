namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class MushroomFoodItemFactory : FoodItemFactory
    {
        public MushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { }
        public override bool HasFlavor => true;
    }
}
