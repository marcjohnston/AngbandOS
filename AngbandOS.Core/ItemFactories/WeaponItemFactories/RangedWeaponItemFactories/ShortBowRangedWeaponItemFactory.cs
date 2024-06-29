// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ShortBowRangedWeaponItemFactory : RangedWeaponItemFactory
{
    private ShortBowRangedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Short Bow";

    public override int Cost => 50;
    protected override string? DescriptionSyntax => "Short Bow~";
    public override int LevelNormallyFound => 3;
    protected override string ItemClassName => nameof(BowItemClass);
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 30;
    public override int MissileDamageMultiplier => 2;
    protected override string[]? AmmunitionItemFactoryNames => new string[]
    {
        nameof(WoodenArrowAmmunitionItemFactory),
        nameof(SeekerArrowAmmunitionItemFactory)
    };
}
