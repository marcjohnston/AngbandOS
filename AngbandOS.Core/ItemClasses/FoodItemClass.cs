[Serializable]
internal class FoodItemClass : ItemClass
{
    private FoodItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Food";
}