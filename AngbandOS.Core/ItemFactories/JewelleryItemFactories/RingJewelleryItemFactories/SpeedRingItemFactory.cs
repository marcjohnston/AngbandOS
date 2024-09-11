// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpeedRingItemFactory : RingItemFactory
{
    private SpeedRingItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(EqualSignSymbol);
    public override string Name => "Speed";
    protected override string? DescriptionSyntax => "$Flavor$ Ring~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Ring~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Ring~ of $Name$";

    /// <summary>
    /// Returns a treasure rating of 25 for a ring of speed.
    /// </summary>
    public override int TreasureRating => 25;

    protected override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(BrokenAndCursedEnchantmentScript), nameof(PoorSpeed1D5P5EnchantmentScript) }),
        (new int[] {0, 1, 2}, null, new string[] { nameof(BonusSpeed1D5P5BEnchantmentScript) })
    };

    public override int Cost => 100000;
    public override bool HideType => true;
    public override int LevelNormallyFound => 80;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (80, 1)
    };
    public override bool Speed => true;
    public override int Weight => 2;

    public override bool KindIsGood => true;
}
