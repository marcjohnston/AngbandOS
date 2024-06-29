// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HeavyCrossbowRangedWeaponItemFactory : RangedWeaponItemFactory
{
    private HeavyCrossbowRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Heavy Crossbow";

    protected override string ItemClassName => nameof(CrossbowItemClass);
    public override int Cost => 300;
    protected override string? DescriptionSyntax => "Heavy Crossbow~";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 200;
    public override int MissileDamageMultiplier => 4;
    protected override string[]? AmmunitionItemFactoryNames => new string[]
    {
        nameof(SteelBoltAmmunitionItemFactory),
        nameof(SeekerBoltAmmunitionItemFactory)
    };
}
