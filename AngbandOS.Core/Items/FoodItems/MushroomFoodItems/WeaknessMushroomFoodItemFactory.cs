namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class WeaknessMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private WeaknessMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override string Name => "Weakness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 5;
    public override int Ds => 5;
    public override string FriendlyName => "Weakness";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Pval => 500;
    public override int? SubCategory => 6;
    public override int Weight => 1;

    public override bool Eat()
    {
        SaveGame.Player.TakeHit(Program.Rng.DiceRoll(6, 6), "poisonous food.");
        SaveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
        return true;
    }
    public override Item CreateItem() => new WeaknessMushroomFoodItem(SaveGame);
}
