// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SapphiresGoldItemFactory : GoldItemFactory
{
    private SapphiresGoldItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DollarSignSymbol);
    public override ColorEnum Color => ColorEnum.Blue;
    public override string Name => "sapphires";

    public override int GoldValue => 20;
    public override string FriendlyName => "sapphires";
    public override int LevelNormallyFound => 1;
    public override Item CreateItem() => new Item(Game, this);
}
