// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CharismaAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private CharismaAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Charisma";
    protected override string? DescriptionSyntax => "$Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Amulet~ of $Name$";
    protected override string? BreaksDuringEnchantmentProbabilityExpression => "1/2";
    protected override (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]? EnchantmentBinders => new (int[]? Powers, bool? StoreStock, string[] ScriptNames)[]
    {
        (new int[] {-1, -2}, null, new string[] { nameof(BrokenAndCursedEnchantmentScript), nameof(PoorCharisma5BP1EnchantmentScript) }),
        (new int[] {0, 1, 2}, null, new string[] { nameof(BonusCharisma5BP1EnchantmentScript) }),
    };
    public override bool Cha => true;
    public override int Cost => 500;
    public override bool HideType => true;
    public override int LevelNormallyFound => 20;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (20, 1)
    };
    public override int Weight => 3;
}
