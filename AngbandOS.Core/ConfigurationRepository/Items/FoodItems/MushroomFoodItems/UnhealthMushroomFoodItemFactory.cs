// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class UnhealthMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private UnhealthMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override string Name => "Unhealth";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 50;
    public override int Dd => 10;
    public override int Ds => 10;
    public override string FriendlyName => "Unhealth";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override int Pval => 500;
    public override int Weight => 1;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        SaveGame.TakeHit(SaveGame.Rng.DiceRoll(10, 10), "poisonous food.");
        SaveGame.TryDecreasingAbilityScore(Ability.Constitution);
        return true;
    }
    public override Item CreateItem() => new UnhealthMushroomFoodItem(SaveGame);
}
