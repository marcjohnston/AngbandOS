// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TulwarWeaponItemFactory : SwordWeaponItemFactory
{
    private TulwarWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Tulwar";

    public override int Cost => 200;
    public override int DamageDice => 2;
    public override int DamageSides => 4;
    public override string FriendlyName => "& Tulwar~";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 100;
}
