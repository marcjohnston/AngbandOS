// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RibbedPlateHardArmorItemFactory : HardArmorItemFactory
{
    private RibbedPlateHardArmorItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(OpenBraceSymbol);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "Ribbed Plate Armor";

    public override int Ac => 28;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1500;
    public override int Dd => 2;
    public override int Ds => 4;
    public override string FriendlyName => "Ribbed Plate Armor~";
    public override int LevelNormallyFound => 50;
    public override int[] Locale => new int[] { 50, 0, 0, 0 };
    public override int ToH => -3;
    public override int Weight => 380;
    public override Item CreateItem() => new Item(Game, this);
}
