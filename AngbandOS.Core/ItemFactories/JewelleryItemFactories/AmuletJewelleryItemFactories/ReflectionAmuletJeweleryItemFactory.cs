// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ReflectionAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private ReflectionAmuletJeweleryItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DoubleQuoteSymbol);
    public override string Name => "Reflection";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 30000;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Reflection";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override bool Reflect => true;
    public override int Weight => 3;
    public override Item CreateItem() => new Item(Game, this);
}
