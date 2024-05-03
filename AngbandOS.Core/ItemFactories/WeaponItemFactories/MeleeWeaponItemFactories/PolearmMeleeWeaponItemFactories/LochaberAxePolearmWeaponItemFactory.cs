// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LochaberAxePolearmWeaponItemFactory : PolearmWeaponItemFactory
{
    private LochaberAxePolearmWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ForwardSlashSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Lochaber Axe";

    public override int Cost => 750;
    public override int DamageDice => 3;
    public override int DamageSides => 8;
    public override string FriendlyName => "& Lochaber Axe~";
    public override int LevelNormallyFound => 45;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (45, 1)
    };
    public override bool ShowMods => true;
    public override int Weight => 250;
}
