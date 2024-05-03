// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NaivetyPotionItemFactory : PotionItemFactory
{
    private NaivetyPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Naivety";

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string FriendlyName => "Naivety";
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Naivety tries to reduce your wisdom
        return Game.TryDecreasingAbilityScore(Ability.Wisdom);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
