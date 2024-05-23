// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PickDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private PickDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Pick";

    public override int Cost => 50;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    public override string CodedName => "& Pick~";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 16)
    };
    public override int InitialTypeSpecificValue => 1;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 150;
}
