// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WeaknessPotionItemFactory : PotionItemFactory
{
    private WeaknessPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Weakness";

    public override int DamageDice => 3;
    public override int DamageSides => 12;
    public override string FriendlyName => "Weakness";
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Weakness tries to reduce your strength
        return Game.TryDecreasingAbilityScore(Ability.Strength);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
