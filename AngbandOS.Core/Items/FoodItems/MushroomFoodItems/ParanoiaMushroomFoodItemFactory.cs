namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ParanoiaMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private ParanoiaMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override string Name => "Paranoia";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Paranoia";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Pval => 500;
    public override int? SubCategory => 2;
    public override int Weight => 1;

    public override bool Eat()
    {
        if (!SaveGame.Player.HasFearResistance)
        {
            if (SaveGame.Player.TimedFear.AddTimer(Program.Rng.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
    public override Item CreateItem() => new ParanoiaMushroomFoodItem(SaveGame);
}
