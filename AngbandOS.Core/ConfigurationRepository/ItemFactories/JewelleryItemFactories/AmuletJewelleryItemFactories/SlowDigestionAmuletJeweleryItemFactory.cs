// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlowDigestionAmuletJeweleryItemFactory : AmuletJeweleryItemFactory
{
    private SlowDigestionAmuletJeweleryItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(DoubleQuoteSymbol));
    public override string Name => "Slow Digestion";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 200;
    public override bool EasyKnow => true;
    public override string FriendlyName => "Slow Digestion";
    public override int LevelNormallyFound => 15;
    public override int[] Locale => new int[] { 15, 0, 0, 0 };
    public override bool SlowDigest => true;
    public override int Weight => 3;
    public override Item CreateItem() => new Item(SaveGame, this);
}
