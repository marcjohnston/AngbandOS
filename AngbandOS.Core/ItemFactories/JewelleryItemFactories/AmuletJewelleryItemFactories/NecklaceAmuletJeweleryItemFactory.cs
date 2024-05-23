// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class NecklaceAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private NecklaceAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Dwarves";

    public override int Cost => 75000;
    public override string CodedName => "& Necklace~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 70;
    public override int Weight => 3;
}
