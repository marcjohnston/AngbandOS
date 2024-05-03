// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GreatAxePolearmWeaponItemFactory : PolearmWeaponItemFactory
{
    private GreatAxePolearmWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(ForwardSlashSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string Name => "Great Axe";

    public override int Cost => 500;
    public override int Dd => 4;
    public override int Ds => 4;
    public override string FriendlyName => "& Great Axe~";
    public override int LevelNormallyFound => 40;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override bool ShowMods => true;
    public override int Weight => 230;
    public override Item CreateItem() => new Item(Game, this);
}
