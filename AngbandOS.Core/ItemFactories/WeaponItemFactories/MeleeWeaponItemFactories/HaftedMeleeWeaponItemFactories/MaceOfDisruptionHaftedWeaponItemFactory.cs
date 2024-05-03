// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MaceOfDisruptionHaftedWeaponItemFactory : HaftedWeaponItemFactory
{
    private MaceOfDisruptionHaftedWeaponItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(BackSlashSymbol);
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Mace of Disruption";

    public override int Cost => 4300;
    public override int Dd => 5;
    public override int Ds => 8;
    public override string FriendlyName => "& Mace~ of Disruption";
    public override int LevelNormallyFound => 80;
    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override bool ShowMods => true;
    public override bool SlayUndead => true;
    public override int Weight => 400;
    public override Item CreateItem() => new Item(Game, this);
}
