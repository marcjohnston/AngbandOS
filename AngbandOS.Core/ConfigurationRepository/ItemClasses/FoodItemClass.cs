namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class FoodItemClass : ItemClass
{
    private FoodItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Food";
}