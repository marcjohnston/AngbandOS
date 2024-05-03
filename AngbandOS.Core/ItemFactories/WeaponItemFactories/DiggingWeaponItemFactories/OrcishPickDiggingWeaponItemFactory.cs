// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OrcishPickDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private OrcishPickDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "Orcish Pick";

    public override int Cost => 300;
    public override int DamageDice => 1;
    public override int DamageSides => 3;
    public override string FriendlyName => "& Orcish Pick~";
    public override int LevelNormallyFound => 30;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (30, 4)
    };
    public override int InitialTypeSpecificValue => 2;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 150;
    public override Item CreateItem() => new Item(Game, this);
}
