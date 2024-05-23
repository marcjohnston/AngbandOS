// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DwarvenShovelDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private DwarvenShovelDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Dwarven Shovel";

    public override int Cost => 200;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    public override string CodedName => "& Dwarven Shovel~";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int InitialTypeSpecificValue => 3;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 120;
}
