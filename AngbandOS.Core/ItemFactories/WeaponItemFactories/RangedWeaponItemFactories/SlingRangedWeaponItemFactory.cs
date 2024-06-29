// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlingRangedWeaponItemFactory : RangedWeaponItemFactory
{
    private SlingRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.Brown;
    public override string Name => "Sling";

    public override int Cost => 5;
    protected override string ItemClassName => nameof(SlingItemClass);
    protected override string? DescriptionSyntax => "Sling~";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 5;
    public override int MissileDamageMultiplier => 2;
    protected override string[]? AmmunitionItemFactoryNames => new string[]
    {
        nameof(IronShotAmmunitionItemFactory),
        nameof(RoundedPebbleShotAmmunitionItemFactory)
    };
}
