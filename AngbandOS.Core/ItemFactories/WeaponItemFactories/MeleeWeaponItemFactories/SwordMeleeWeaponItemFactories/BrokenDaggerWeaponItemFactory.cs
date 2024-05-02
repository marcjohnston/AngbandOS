// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class BrokenDaggerWeaponItemFactory : SwordWeaponItemFactory
{
    private BrokenDaggerWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(VerticalBarSymbol);
    public override ColorEnum Color => ColorEnum.Black;
    public override string Name => "Broken Dagger";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Broken Dagger~";
    public override bool ShowMods => true;
    public override int ToD => -4;
    public override int ToH => -2;
    public override int Weight => 5;
    public override Item CreateItem() => new Item(Game, this);
}
