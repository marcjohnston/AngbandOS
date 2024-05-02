// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GnomishShovelDiggingWeaponItemFactory : DiggingWeaponItemFactory
{
    private GnomishShovelDiggingWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.BrightGreen;
    public override string Name => "Gnomish Shovel";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "& Gnomish Shovel~";
    public override int LevelNormallyFound => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int InitialTypeSpecificValue => 2;
    public override bool ShowMods => true;
    public override bool Tunnel => true;
    public override int Weight => 60;
    public override Item CreateItem() => new Item(Game, this);
}
