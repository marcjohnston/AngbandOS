namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardBiscuitFoodItemFactory : FoodItemFactory
{
    private HardBiscuitFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Hard Biscuit";

    public override int Cost => 1;
    public override string FriendlyName => "& Hard Biscuit~";
    public override int Pval => 500;
    public override int? SubCategory => 32;
    public override int Weight => 2;
    public override bool Eat()
    {
        SaveGame.MsgPrint("That tastes good.");
        return true;
    }

    public override void ApplyFlavourVisuals()
    {
        base.ApplyFlavourVisuals();
    }

    /// <summary>
    /// Returns true because biscuits vanish when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;

    public override Item CreateItem() => new HardBiscuitFoodItem(SaveGame);
}
