namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class MushroomFoodItemClass : FoodItemClass
    {
        public MushroomFoodItemClass(SaveGame saveGame) : base(saveGame) { }
        public override bool HasFlavor => true;

    }
}
