// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LongBowWeaponItemFactory : BowWeaponItemFactory
{
    private LongBowWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(CloseBracketSymbol);
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Long Bow";

    public override int Cost => 120;
    public override string FriendlyName => "& Long Bow~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 40;
    public override int MissileDamageMultiplier => 3;
    public override ItemTypeEnum AmmunitionItemCategory => ItemTypeEnum.Arrow;
}
