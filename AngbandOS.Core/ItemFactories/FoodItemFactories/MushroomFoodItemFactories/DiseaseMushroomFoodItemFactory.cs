// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DiseaseMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private DiseaseMushroomFoodItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CommaSymbol);
    public override string Name => "Disease";

    public override int Cost => 50;
    public override int DamageDice => 10;
    public override int DamageSides => 10;
    public override string FriendlyName => "Disease";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 1;
    public override bool Eat()
    {
        Game.PlaySound(SoundEffectEnum.Eat);
        Game.TakeHit(Game.DiceRoll(10, 10), "poisonous food.");
        Game.TryDecreasingAbilityScore(Ability.Strength);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
