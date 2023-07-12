// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class NaivetyMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private NaivetyMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CommaSymbol>();
    public override string Name => "Naivety";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override string FriendlyName => "Naivety";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Pval => 500;
    public override int Weight => 1;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        SaveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), "poisonous food.");
        SaveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
        return true;
    }
    public override Item CreateItem() => new NaivetyMushroomFoodItem(SaveGame);
}
