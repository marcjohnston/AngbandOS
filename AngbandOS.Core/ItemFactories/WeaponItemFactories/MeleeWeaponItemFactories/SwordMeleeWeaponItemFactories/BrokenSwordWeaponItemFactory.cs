// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrokenSwordWeaponItemFactory : SwordWeaponItemFactory
{
    private BrokenSwordWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Broken Sword";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int Cost => 2;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "& Broken Sword~";
    public override bool ShowMods => true;
    public override int BonusDamage => -4;
    public override int BonusHit => -2;
    public override int Weight => 30;
    public override Item CreateItem() => new Item(Game, this);
}
