// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AntiTheftAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private AntiTheftAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Anti-Theft";

    public override bool AntiTheft => true;
    public override int Cost => 1000;
    public override string FriendlyName => "Anti-Theft";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 20;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int Weight => 3;
    public override Item CreateItem() => new Item(Game, this);
}
