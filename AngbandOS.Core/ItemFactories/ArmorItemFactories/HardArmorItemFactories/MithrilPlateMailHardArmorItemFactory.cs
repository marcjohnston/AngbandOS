// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MithrilPlateMailHardArmorItemFactory : HardArmorItemFactory
{
    private MithrilPlateMailHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "Mithril Plate Mail";

    public override int Ac => 35;
    public override int Cost => 15000;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Mithril Plate Mail~";
    public override bool IgnoreAcid => true;
    public override int LevelNormallyFound => 60;
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int ToH => -3;
    public override int Weight => 300;
    public override Item CreateItem() => new Item(Game, this);
}
