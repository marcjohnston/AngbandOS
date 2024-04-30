// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AdamantiteGoldItemFactory : GoldItemFactory
{
    private AdamantiteGoldItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(DollarSignSymbol));
    public override ColorEnum Color => ColorEnum.Chartreuse;
    public override string Name => "adamantite";

    public override int GoldValue => 80;
    public override string FriendlyName => "adamantite";
    public override int LevelNormallyFound => 1;

    public override Item CreateItem() => new Item(Game, this);
}
