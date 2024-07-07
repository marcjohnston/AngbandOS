// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RestoreManaPotionItemFactory : PotionItemFactory
{
    private RestoreManaPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Restore Mana";
    protected override string? DescriptionSyntax => "$Flavor$ Potion~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Potion~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Potion~ of $Name$";
    public override int Cost => 350;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override int LevelNormallyFound => 25;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (25, 1)
    };
    public override int Weight => 4;
    protected override (string, string?, int)? QuaffNoticeableScriptName => (nameof(RestoreManaScript), nameof(Mana10d10ProjectileFriendlyScript), 20);
}
