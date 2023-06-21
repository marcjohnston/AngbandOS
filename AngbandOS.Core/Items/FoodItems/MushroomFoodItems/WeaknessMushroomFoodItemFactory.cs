// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
    public override int Weight => 1;

    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffect.Eat);
        SaveGame.Player.TakeHit(Program.Rng.DiceRoll(6, 6), "poisonous food.");
        SaveGame.Player.TryDecreasingAbilityScore(Ability.Strength);
        return true;
    }
    public override Item CreateItem() => new WeaknessMushroomFoodItem(SaveGame);
}
