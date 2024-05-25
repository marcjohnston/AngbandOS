// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CarlammasAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private CarlammasAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Carlammas";
    protected override string? DescriptionSyntax => "& $Flavor$ Amulet~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "& $Flavor$ Amulet~";
    protected override string? FlavorSuppressedDescriptionSyntax => "& Amulet~ of $Name$";
    public override int Cost => 60000;
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 50;
    public override int Weight => 3;
}
