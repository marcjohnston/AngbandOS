namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PoisonMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private PoisonMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override string Name => "Poison";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Dd => 4;
    public override int Ds => 4;
    public override string FriendlyName => "Poison";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 5, 0, 0 };
    public override int Pval => 500;
    public override int? SubCategory => 0;
    public override int Weight => 1;

    public override bool Eat()
    {
        if (!(SaveGame.Player.HasPoisonResistance || SaveGame.Player.TimedPoisonResistance.TurnsRemaining != 0))
        {
            // Hagarg Ryonis may protect us from poison
            if (Program.Rng.DieRoll(10) <= SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (SaveGame.Player.TimedPoison.AddTimer(Program.Rng.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
    public override Item CreateItem() => new PoisonMushroomFoodItem(SaveGame);
}
