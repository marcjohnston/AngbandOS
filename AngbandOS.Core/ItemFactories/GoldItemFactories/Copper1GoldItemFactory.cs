// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class Copper1GoldItemFactory : GoldItemFactory
{
    private Copper1GoldItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(DollarSignSymbol));
    public override ColorEnum Color => ColorEnum.Copper;
    public override string Name => "copper*";

    public override int Cost => 4;
    public override string FriendlyName => "copper";
    public override int LevelNormallyFound => 1;
    public override Item CreateItem() => new Item(Game, this);
}
