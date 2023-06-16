namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CurePoisonMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private CurePoisonMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override string Name => "Cure Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 60;
    public override string FriendlyName => "Cure Poison";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Pval => 500;
    public override int? SubCategory => 12;
    public override int Weight => 1;
    public override bool Eat()
    {
        if (SaveGame.Player.TimedPoison.ResetTimer())
        {
            return true;
        }
        return false;
    }
    public override Item CreateItem() => new CurePoisonMushroomFoodItem(SaveGame);
}
