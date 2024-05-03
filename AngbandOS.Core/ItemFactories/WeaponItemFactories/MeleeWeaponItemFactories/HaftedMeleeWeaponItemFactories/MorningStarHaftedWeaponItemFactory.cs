// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MorningStarHaftedWeaponItemFactory : HaftedWeaponItemFactory
{
    private MorningStarHaftedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Morning Star";

    public override int Cost => 396;
    public override int DamageDice => 2;
    public override int DamageSides => 6;
    public override string FriendlyName => "& Morning Star~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 150;
    public override Item CreateItem() => new Item(Game, this);
}
