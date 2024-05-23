namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FoodItemClass : ItemClass
{
    private FoodItemClass(Game game) : base(game) { }
    public override string Name => "Food";
}
