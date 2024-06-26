// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class MithrilGoldItemFactory : ItemFactory
{
    private MithrilGoldItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(DollarSignSymbol);
    public override ColorEnum Color => ColorEnum.BrightBlue;
    public override string Name => "mithril";

    protected override string InitialGoldPiecesRollExpression => "2d40x4";
    public override int LevelNormallyFound => 1;
    protected override string ItemClassName => nameof(GoldItemClass);
    public override int PackSort => 0;
    public override bool IsIgnoredByMonsters => true;
}
