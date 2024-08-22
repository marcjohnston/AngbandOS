// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MagiAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private MagiAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "the Magi";
    protected override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";

    /// <summary>
    /// Returns a treasure rating of 25 for an amulet of the magi.
    /// </summary>
    public override int TreasureRating => 25;

    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (null, null, new string[] { nameof(BonusArmorClass1D5P5BEnchantmentScript), nameof(BonusSearchEnchantmentScript), nameof(BonusSlowDigest1In3EnchantmentScript) })
    };

    public override int Cost => 30000;
    public override bool FreeAct => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 4),
        (80, 3)
    };
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override int BonusArmorClass => 3;
    public override int Weight => 3;

    public override bool KindIsGood => true;
}
