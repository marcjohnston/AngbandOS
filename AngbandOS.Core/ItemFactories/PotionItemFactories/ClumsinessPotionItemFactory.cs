// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ClumsinessPotionItemFactory : PotionItemFactory
{
    private ClumsinessPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Clumsiness";

    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Clumsiness";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Clumsiness tries to reduce your dexterity
        return Game.TryDecreasingAbilityScore(Ability.Dexterity);
    }
    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
